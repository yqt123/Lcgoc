CREATE TABLE IF NOT EXISTS `sys_controller` (
  `controller` varchar(40) COMMENT '������',
  `name` varchar(40) CHARACTER SET utf8 COMMENT '����������',
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`controller`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;