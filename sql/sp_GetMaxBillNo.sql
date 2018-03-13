delimiter //
/*
��ȡ��󵥺�
CALL sp_GetMaxBillNo('Q','5');

*/
DROP PROCEDURE IF EXISTS sp_GetMaxBillNo;
CREATE PROCEDURE sp_GetMaxBillNo(
IN inprefix varchar(20),		-- ǰ׺
IN inlength int		-- ��ˮ�ų���
)
top:Begin
	DECLARE ddate VARCHAR(20);
	DECLARE dmaxindex INT;
	SET ddate=DATE_FORMAT(NOW(),'%Y%m%d');
	
	INSERT INTO indexnumbers (date,`index`) VALUES (ddate,1)
	ON DUPLICATE KEY UPDATE `index`=`index`+1;
	
	SELECT CONCAT(inprefix,ddate,lpad(`index`,inlength,'0')) FROM indexnumbers where date=ddate;
	
END;
//
delimiter ;

