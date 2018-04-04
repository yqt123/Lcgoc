delimiter //
/*
CALL sp_ModuleActionPost('U001','Q2018022600002');
*/
DROP PROCEDURE IF EXISTS sp_ModuleActionPost;
CREATE PROCEDURE sp_ModuleActionPost(
IN inuserId varchar(20),		-- 编码
IN inqueueCode varchar(20)		-- 队列编号
)
COMMENT '模块提交执行过程'
top:Begin
	DECLARE dmoduleCode VARCHAR(20) default '';
	DECLARE dactionCode VARCHAR(20) default '';
	DECLARE dexeTableName VARCHAR(20) default '';
	DECLARE dmodlueActionType VARCHAR(20) default '';
	DECLARE dids VARCHAR(250) default '';-- 字段
	DECLARE dvalues VARCHAR(500) default '';-- 字段值
	
	SELECT moduleCode,actionCode INTO dmoduleCode,dactionCode 
	FROM module_queue where queueCode=inqueueCode;
	
	SELECT exeTableName,modlueActionType INTO dexeTableName,dmodlueActionType
	FROM module_actions where moduleCode=dmoduleCode and actionCode=dactionCode;
	
	SET @sqlstr='';
	-- 统一处理的方法
	IF dmodlueActionType='add' THEN
		
		SET @sqlstr=CONCAT('INSERT INTO ',dexeTableName,'(');
		
		SELECT GROUP_CONCAT('`',`id`,'`') INTO dids from module_queue_detail where queueCode=inqueueCode GROUP BY queueCode;
		
		SET @sqlstr=CONCAT(@sqlstr,dids,')VALUES(');
		
		SELECT GROUP_CONCAT(
		case mac.typeof when 'bool' then (case d.`value` when 'true' then '1' else '0' end)
		else CONCAT('''',d.`value`,'''') end
		) INTO dvalues 
		from module_queue_detail d
		LEFT JOIN module_queue m On m.queueCode=d.queueCode
		LEFT JOIN module_actions_columns mac ON m.moduleCode=mac.moduleCode and m.actionCode=mac.actionCode and d.id=mac.columnCode
		where d.queueCode=inqueueCode GROUP BY queueCode;
				
		SET @sqlstr=CONCAT(@sqlstr,dvalues,');');
		
	ELSEIF dmodlueActionType='edit' THEN
		
		SET @sqlstr=CONCAT('UPDATE ',dexeTableName,' set ');
		
		SELECT GROUP_CONCAT('`',`id`,'`','=',
		case mac.typeof when 'bool' then (case d.`value` when 'true' then '1' else '0' end)
		else CONCAT('''',d.`value`,'''') end
		) INTO dids
		from module_queue_detail d
		LEFT JOIN module_queue m On m.queueCode=d.queueCode
		LEFT JOIN module_actions_columns mac ON m.moduleCode=mac.moduleCode and m.actionCode=mac.actionCode and d.id=mac.columnCode
		where d.queueCode=inqueueCode and d.keyword=0;
		
		SET @sqlstr=CONCAT(@sqlstr,dids,' where ');
		
		SELECT GROUP_CONCAT('`',`id`,'`','=',
		case mac.typeof when 'bool' then (case d.`value` when 'true' then '1' else '0' end)
		else CONCAT('''',d.`value`,'''') end
		separator ' and ') INTO dvalues
		from module_queue_detail d
		LEFT JOIN module_queue m On m.queueCode=d.queueCode
		LEFT JOIN module_actions_columns mac ON m.moduleCode=mac.moduleCode and m.actionCode=mac.actionCode and d.id=mac.columnCode		
		where d.queueCode=inqueueCode and d.keyword=1;
		
		SET @sqlstr=CONCAT(@sqlstr,dvalues);
		
	ELSEIF dmodlueActionType='delete' THEN
		SET @sqlstr=CONCAT('delete from ',dexeTableName,' where ');
		
		SELECT GROUP_CONCAT('`',`id`,'`','=','''',`value`,'''' separator ' and ') INTO dvalues
		from module_queue_detail where queueCode=inqueueCode;
		
		SET @sqlstr=CONCAT(@sqlstr,dvalues);
		
	END IF;
-- 	SELECT dmodlueActionType,dexeTableName,@sqlstr;
	if(@sqlstr>'') THEN
		PREPARE stmt FROM @sqlstr; 
		EXECUTE stmt; 
	END IF;
END;
//
delimiter ;
