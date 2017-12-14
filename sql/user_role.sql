CREATE TABLE IF NOT EXISTS `user_role` (
  `userId` varchar(20) COMMENT'用户ID',
  `roleId` varchar(20) COMMENT'角色ID',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT '时间',
  PRIMARY KEY(`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
