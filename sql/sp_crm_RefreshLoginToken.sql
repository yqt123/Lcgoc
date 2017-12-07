delimiter //
/*
ˢ�µ�¼ƾ֤
*/
DROP PROCEDURE IF EXISTS sp_crm_RefreshLoginToken;
CREATE PROCEDURE sp_crm_RefreshLoginToken(
IN inidentity varchar(20),		-- ���
IN intoken varchar(20),		-- ƾ֤
IN inip varchar(20),		-- ip
IN inuserAgent varchar(20)		-- ���ƾ֤
)
top:Begin

	INSERT INTO crm_loginToken(identity,token) 
	VALUE(inidentity,intoken) ON DUPLICATE KEY UPDATE identity= inidentity,token=intoken,modifyDTM=NOW();
	
	INSERT INTO crm_loginToken_log(identity,userAgent,ip,token)
	VALUE(inidentity,inuserAgent,inip,intoken);

END;
//
delimiter ;
