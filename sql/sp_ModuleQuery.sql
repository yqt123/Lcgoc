delimiter //
/*
模块查询
CALL sp_ModuleQuery('U001','Q2018022600001');

*/
DROP PROCEDURE IF EXISTS sp_ModuleQuery;
CREATE PROCEDURE sp_ModuleQuery(
IN inuserId varchar(20),		-- 编码
IN inqueueCode varchar(20)		-- 队列编号
)
top:Begin
	DECLARE dmoduleCode VARCHAR(20);
	DECLARE dactionCode VARCHAR(20);
	DECLARE dexeTableName VARCHAR(20);
	DECLARE dsorting VARCHAR(20);

	SELECT moduleCode,actionCode INTO dmoduleCode,dactionCode 
	FROM module_queue where queueCode=inqueueCode;
	
	SELECT exeTableName,sorting INTO dexeTableName,dsorting
	FROM module_actions where moduleCode=dmoduleCode and actionCode=dactionCode;
	
	SET @sqlstr='SELECT ';
	SET @columnCode='';
	SELECT group_concat(columnCode) INTO @columnCode
	FROM module_actions_columns where moduleCode=dmoduleCode and actionCode=dactionCode and actionCode=dactionCode
	GROUP BY moduleCode;
	
	SET @sqlstr=CONCAT(@sqlstr,@columnCode,' from ',dexeTableName);
	if(dsorting>'')THEN
		SET @sqlstr=CONCAT(@sqlstr,' ORDER BY ',dsorting);
	END IF;

	PREPARE stmt FROM @sqlstr; 
	EXECUTE stmt; 
	
END;
//
delimiter ;
