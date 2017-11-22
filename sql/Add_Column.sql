DROP PROCEDURE IF EXISTS Add_Column;
-- call Add_Column('表名','列名','varchar(50)',0,'','comment');
CREATE PROCEDURE Add_Column(
IN TName varchar(50),
IN FieldName varchar(50),
IN FieldType varchar(50),
IN CanNull int,/*是否允许为空.0不允许 1允许 */
IN DefalutVal varchar(50),/*默认值*/
IN CommentVal text Charset utf8 Collate utf8_general_ci/*备注*/
)
BEGIN
	IF ISNULL(DefalutVal) Or LENGTH(DefalutVal) = 0 THEN
		Set @DefalutVal = '';
	ELSE
		Set @DefalutVal = Concat(' default ',DefalutVal);
	End IF;
	IF ISNULL(CanNull) = 1 OR CanNull = 1 THEN
		Set @CanNull = ' NULL';
	ELSE
		Set @CanNull = ' Not Null';
	End IF;
	IF ISNULL(CommentVal) Or LENGTH(CommentVal) = 0 THEN
		Set @CommentVal = '';
	ELSE
		Set @CommentVal = Concat(' COMMENT ''',CommentVal,'''');
	End IF;
	/*取得当前实例*/
	Set @Example = (select database());
	IF Not EXISTS (SELECT 1 FROM Information_Schema.Columns WHERE TABLE_SCHEMA = @Example And TABLE_NAME = TName AND Column_Name = FieldName) Then 
			Set @StrSql = Concat('ALTER TABLE `',TName,'` ADD COLUMN `',FieldName,'` ',FieldType,@DefalutVal,@CanNull,@CommentVal,';');
	ELSE 
			Set @StrSql = 'Select ''field exists''';
	END IF;
	PREPARE s1 FROM @StrSql;  
	EXECUTE s1;  
	DEALLOCATE PREPARE s1;
END;
