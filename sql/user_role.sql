CREATE TABLE IF NOT EXISTS `user_role` (
  `id` BIGINT auto_increment COMMENT '����ID',
  `userId` varchar(20) COMMENT'�û�ID',
  `roleId` varchar(20) COMMENT'��ɫID',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
