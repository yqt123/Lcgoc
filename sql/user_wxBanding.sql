CREATE TABLE IF NOT EXISTS `user_wxBanding` (
  `userId` varchar(20) COMMENT '�û����',
  `appnum` varchar(40) COMMENT '���ں�',
  `openid` varchar(40) COMMENT '�û�OpenID',
  `wxImage` varchar(100) COMMENT '΢��ͷ��',
  `modifyDTM` Datetime COMMENT '�޸�ʱ��',	
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  PRIMARY KEY(`userId`,`appnum`,`openid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;