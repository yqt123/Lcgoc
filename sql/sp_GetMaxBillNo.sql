delimiter //
/*
获取最大单号
CALL sp_GetMaxBillNo('Q','5');

*/
DROP PROCEDURE IF EXISTS sp_GetMaxBillNo;
CREATE PROCEDURE sp_GetMaxBillNo(
IN inprefix varchar(20),		-- 前缀
IN inlength int		-- 流水号长度
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

