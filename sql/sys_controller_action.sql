
CREATE TABLE IF NOT EXISTS `sys_controller_action` (
  `controller` varchar(40) COMMENT '������',
  `action` varchar(40) COMMENT '������',
  `name` varchar(40) CHARACTER SET utf8 COMMENT '��������',
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`controller`,`action`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
