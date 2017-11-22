CREATE TABLE IF NOT EXISTS `api_Controller` (
  `code` varchar(20) COMMENT 'API编码',
  `describe` varchar(200) CHARACTER SET utf8 COMMENT'描述',
  `dll` varchar(20) COMMENT'职位',
  `fullClass` varchar(20) COMMENT'电话',
  `allowUsed` tinyint(1) COMMENT'是否可用',
	`modifyDTM` Datetime DEFAULT NOW() COMMENT '创建时间',
  PRIMARY KEY(`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;