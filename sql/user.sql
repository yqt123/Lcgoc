CREATE TABLE IF NOT EXISTS `user` (
  `userId` varchar(20) COMMENT '�û����',
  `userName` varchar(40) CHARACTER SET utf8 COMMENT '�û���',
  `mobile` varchar(20) COMMENT '�ֻ�����',
  `email` varchar(40) COMMENT '����',
  `password` varchar(32) COMMENT '����',
	`nick` varchar(40) CHARACTER SET utf8 COMMENT '�ǳ�',
  `sex` INT(1) COMMENT '�Ա�',
  `realName` varchar(40) CHARACTER SET utf8 COMMENT '��ʵ����',
  `birthday` varchar(12) COMMENT '����',
	`image` varchar(40) COMMENT '�û�ͷ��',
	`registerTime` Datetime DEFAULT NOW() COMMENT 'ʱ��',
	`lastLoginTime` Datetime DEFAULT NOW() COMMENT '����¼ʱ��',
  `modifyDTM` Datetime COMMENT '�޸�ʱ��',	
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  PRIMARY KEY(`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;