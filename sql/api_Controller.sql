CREATE TABLE IF NOT EXISTS `api_Controller` (
  `code` varchar(20) COMMENT 'API����',
  `describe` varchar(200) CHARACTER SET utf8 COMMENT'����',
  `dll` varchar(20) COMMENT'ְλ',
  `fullClass` varchar(20) COMMENT'�绰',
  `allowUsed` tinyint(1) COMMENT'�Ƿ����',
	`modifyDTM` Datetime DEFAULT NOW() COMMENT '����ʱ��',
  PRIMARY KEY(`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;