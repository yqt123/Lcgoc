delimiter //
/*
创建或修改菜单
*/
DROP PROCEDURE IF EXISTS sp_CreateEditMenu;
CREATE PROCEDURE sp_CreateEditMenu(
IN incode varchar(20),		-- 编码
IN inicon varchar(20),		-- 图标
IN inname varchar(20) CHARACTER SET utf8,		-- 菜单标题
IN inallowused varchar(20),		-- 是否可用
IN inlevel varchar(20),		-- 等级
IN inpullRightContainer varchar(20) -- 右边显示数字
)
top:Begin
	
	INSERT INTO admin_menu (`code`,`icon`,`name`,`allowused`,`modifyDTM`,`level`,`pullRightContainer`) 
	VALUES (incode,inicon,inname,inallowused,NOW(),inlevel,inpullRightContainer)
	ON DUPLICATE KEY UPDATE `icon`=inicon,`name`=inname,`allowused`=inallowused,`modifyDTM`=NOW(),`level`=inlevel,`pullRightContainer`=inpullRightContainer; 
	
END;
//
delimiter ;
