CREATE TABLE IF NOT EXISTS `role` (
  `roleId` BIGINT auto_increment COMMENT '����ID',
  `name` varchar(50) CHARACTER SET utf8 COMMENT'��ɫ����',
  `remark` varchar(200) CHARACTER SET utf8 COMMENT'��ɫ��ע',
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
