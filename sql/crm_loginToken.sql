/*
��¼ƾ֤
*/
CREATE TABLE IF NOT EXISTS `crm_loginToken` (
  `identity` varchar(40) COMMENT '�û����',
  `token` varchar(100) COMMENT '���ƾ֤',
  `modifyDTM` Datetime COMMENT '�޸�ʱ��',
  PRIMARY KEY(`identity`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
��¼ƾ֤��־
*/
CREATE TABLE IF NOT EXISTS `crm_loginToken_log` (
	`id` BIGINT auto_increment COMMENT '����ID',
  `identity` varchar(40) COMMENT '�û����',
	`userAgent` varchar(20) COMMENT '�����豸',
	`ip` varchar(20) COMMENT '��¼ip',
	`token` varchar(20) COMMENT '���ƾ֤',
  `modifyDTM` Datetime COMMENT '�޸�ʱ��',
  PRIMARY KEY(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
