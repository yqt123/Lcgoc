CREATE TABLE IF NOT EXISTS `sys_controller_action_role` (
  `area` varchar(40) COMMENT '����',
  `controller` varchar(40) COMMENT '������',
  `action` varchar(40) COMMENT '������',
  `roleId` varchar(20) COMMENT'��ɫID',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`controller`,`action`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
