delimiter //
/*
�������޸Ĳ˵�
*/
DROP PROCEDURE IF EXISTS sp_CreateEditMenu;
CREATE PROCEDURE sp_CreateEditMenu(
IN incode varchar(20),		-- ����
IN inicon varchar(20),		-- ͼ��
IN inname varchar(20) CHARACTER SET utf8,		-- �˵�����
IN inallowused varchar(20),		-- �Ƿ����
IN inlevel varchar(20),		-- �ȼ�
IN inpullRightContainer varchar(20) -- �ұ���ʾ����
)
top:Begin
	
	INSERT INTO admin_menu (`code`,`icon`,`name`,`allowused`,`modifyDTM`,`level`,`pullRightContainer`) 
	VALUES (incode,inicon,inname,inallowused,NOW(),inlevel,inpullRightContainer)
	ON DUPLICATE KEY UPDATE `icon`=inicon,`name`=inname,`allowused`=inallowused,`modifyDTM`=NOW(),`level`=inlevel,`pullRightContainer`=inpullRightContainer; 
	
END;
//
delimiter ;
