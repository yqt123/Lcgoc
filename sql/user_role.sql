CREATE TABLE IF NOT EXISTS `user_role` (
  `userId` varchar(20) COMMENT'�û�ID',
  `roleId` varchar(20) COMMENT'��ɫID',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
