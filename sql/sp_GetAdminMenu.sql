delimiter //
/*
获取主菜单
call sp_GetAdminMenu('U001',1,10,'','',@outtotal);
SELECT @outtotal;
*/
DROP PROCEDURE IF EXISTS sp_GetAdminMenu;
CREATE PROCEDURE sp_GetAdminMenu(
IN inuserId VARCHAR(20), -- 用户编码
IN inpageIndex INT,		-- 页码 从0开始
IN inpageSize INT,		-- 页面大小
IN incode varchar(20),		-- 菜单编码
IN inname varchar(20) CHARACTER SET utf8,		-- 菜单名字
Out outtotal INT -- 总行数
)
top:Begin
	DECLARE dstartRow INT;-- 开始行
	SET dstartRow=(inpageIndex)*inpageSize;
	SET outtotal=0;
	
	SELECT count(1) INTO outtotal from admin_menu where allowused=1;
	-- 没有用户查所有
	IF (IFNULL(inuserId,'')='') THEN
		SELECT a.`code`,a.`name`,a.icon,a.`level`,a.allowused,DATE_FORMAT(a.modifyDTM,'%Y-%m-%d %H:%i:%s') modifyDTM,a.pullRightContainer
		from admin_menu a
		where (ifnull(incode,'')='' OR a.`code`=incode)
		and (ifnull(inname,'')='' OR a.`name`=inname)
		-- and a.allowUsed=1
		ORDER BY a.`level` ASC
		LIMIT dstartRow,inpageSize;
	ELSE
		SELECT DISTINCT a.`code`,a.`name`,a.icon,a.`level`,a.allowused,DATE_FORMAT(a.modifyDTM,'%Y-%m-%d %H:%i:%s') modifyDTM,a.pullRightContainer
		from admin_menu a
		LEFT JOIN admin_menu_detail b On a.`code`=b.`code` and b.allowused=1
		LEFT JOIN sys_controller_action_role c on b.area=c.area and b.controller=c.controller and b.action=c.action and c.allowused=1
		LEFT JOIN user_role d On c.roleId=d.roleId and d.allowused=1
		where (ifnull(incode,'')='' OR a.`code`=incode)
		and (ifnull(inname,'')='' OR a.`name`=inname)
		and a.allowUsed=1
		and (ISNULL(d.userId)=1 OR d.userId=@userId)
		ORDER BY a.`level` ASC
		LIMIT dstartRow,inpageSize;
		
	END IF;
	
END;
//
delimiter ;
