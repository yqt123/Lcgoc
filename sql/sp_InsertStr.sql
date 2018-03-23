DROP PROCEDURE IF EXISTS sp_InsertStr;
CREATE PROCEDURE sp_InsertStr(
IN inTableName Varchar(50),
IN UserCase varchar(500) Charset utf8 Collate utf8_general_ci
)
BEGIN
	DECLARE startIdx INT default 0;
	DECLARE step INT default 100;

 	SET SESSION group_concat_max_len = 18446744073709551615;
	Set @tableName = inTableName;
	Set @Example = (select database());
	Set @UserCase = UserCase;

	Drop Temporary Table If EXISTS tmp_Columns;
		Create Temporary Table tmp_Columns(FieldName Varchar(100),DataType Varchar(50),FieldDescribe Varchar(100));
	Insert Into tmp_Columns(FieldName,DataType,FieldDescribe)
	Select COLUMN_NAME,DATA_TYPE,(Case When IsNULL(CHARACTER_MAXIMUM_LENGTH) = 1 Then 'varchar(50)' 
		When DATA_TYPE like '%text' Then Concat(DATA_TYPE,' Charset utf8 Collate utf8_general_ci')/*text 等类型不允许有长度*/
		Else Concat(DATA_TYPE,'(',Case When CHARACTER_MAXIMUM_LENGTH < 10 Then 10 Else CHARACTER_MAXIMUM_LENGTH End,') Charset utf8 Collate utf8_general_ci') End)
	From information_schema.columns 
	Where table_schema = @Example And TABLE_NAME = @tableName And EXTRA <> 'auto_increment'
	Order By COLUMN_NAME Asc;
	/*创建需导出内容临时表*/
	Drop Temporary Table If EXISTS tmp_filterData;
	Create Temporary Table tmp_filterData(ID int primary key auto_increment);
	Select GROUP_CONCAT(Concat('`',FieldName,'` ',FieldDescribe)) Into @Command
	From tmp_Columns;

	Set @CreateSql = Concat('Alter Table tmp_filterData Add(',@Command,')');
	PREPARE commands FROM @CreateSql;  
	EXECUTE commands;  
	DEALLOCATE PREPARE commands;
	/*创建需导出内容临时表end*/
	Select GROUP_CONCAT(Case When DataType In('smallint','tinyint','int','bigint') Then Concat('IFNULL(`',FieldName,'`,0) As ',`FieldName`)
	When DataType In ('decimal','double','float') Then Concat('IFNULL(`',FieldName,'`,0.0) As ',`FieldName`) 
	When DataType In ('date','datetime') Then Concat('IFNULL(`',FieldName,'`,''NULL'') As ',`FieldName`) 
	When DataType = 'bit' Then Concat('IFNULL(`',FieldName,'`,0) As ',`FieldName`)
	Else Concat('IFNULL(`',FieldName,'`,''NULL'') As `',`FieldName`,'`') End) Into @Str
	From tmp_Columns;

	Select GROUP_CONCAT('`',FieldName,'`') Into @FieldsList 
	From tmp_Columns;

	Set @Str = Concat(' Insert Into tmp_filterData(',@FieldsList,')'
		,Char(10),' Select ',@Str
		,char(10),' From ',@tableName,' '
		,char(10),@UserCase,';');
	PREPARE s1 FROM @Str;  
	EXECUTE s1;  
	DEALLOCATE PREPARE s1;


	Set @tmpFieldsList = '';
	Set @FieldName = '';
	Select Count(1) Into @RowCount From tmp_Columns;
	WHILE(EXISTS(SELECT 1 FROM tmp_Columns)) DO
		SELECT FieldName Into @FieldName FROM tmp_Columns ORDER BY FieldName Asc Limit 1;	
		Select Count(1) Into @RowCount From tmp_Columns;
		IF @RowCount = 1 Then
			Set @tmpFieldsList = Concat(@tmpFieldsList,'Case When `',@FieldName,'` = ''NULL'' Then ''NULL'' Else Replace(`',@FieldName,'`,'''''''','''''''''''') End');
		Else
			Set @tmpFieldsList = Concat(@tmpFieldsList,'Case When `',@FieldName,'` = ''NULL'' Then ''NULL'' Else Replace(`',@FieldName,'`,'''''''','''''''''''') End,'''''',''''''',Char(10),',');
		End IF;
		Delete FROM tmp_Columns Where FieldName = @FieldName;
	END WHILE;	

	Drop Temporary Table If EXISTS tmp_Insert;
	Create Temporary Table tmp_Insert(ID int primary key auto_increment,sqlValues LONGTEXT Charset utf8 Collate utf8_general_ci);

	Set @StrSQL = Concat('Insert Into tmp_Insert(sqlValues) Select Concat('''''''',',@tmpFieldsList,','''''''') From tmp_filterData;');

	PREPARE s1 FROM @StrSQL;  
	EXECUTE s1;  
	DEALLOCATE PREPARE s1;	
	
	Set @InsertCommand = '';
	Set @idx = 0;
	Select Count(1) Into @Count From tmp_Insert;
	Set @InsertCommand = '';
	Set @InsertSql = '';

 	WHILE(@Count > @idx * step) DO
		Set startIdx = @idx * step;
		Select GROUP_CONCAT('(',REPLACE(sqlValues,'''NULL''','NULL'),')',Char(10)) Into @InsertSql
		From(Select sqlValues From tmp_Insert Limit startIdx,step) A;

		Select Concat(@InsertCommand,' Insert Into `',@tableName,'`(',@FieldsList,')',Char(10)
		,' Values',REPLACE(REPLACE(@InsertSql,'''1''',1),'''0''',0),';',Char(10)) Into @InsertCommand;
		Set @idx = @idx + 1;
	END WHILE;
	
	Select Concat('Delete From `',@tableName,'` ',UserCase,';',Char(10),@InsertCommand);
	Drop Temporary Table If EXISTS tmp_Columns;
	Drop Temporary Table If EXISTS tmp_filterData;
	Drop Temporary Table If EXISTS tmp_Insert;
END