CREATE TABLE IF NOT EXISTS `user` (
  `userId` varchar(20) COMMENT '用户编号',
  `userName` varchar(40) CHARACTER SET utf8 COMMENT '用户名',
  `mobile` varchar(20) COMMENT '手机号码',
  `email` varchar(40) COMMENT '邮箱',
  `password` varchar(32) COMMENT '密码',
	`nick` varchar(40) CHARACTER SET utf8 COMMENT '昵称',
  `sex` INT(1) COMMENT '性别',
  `realName` varchar(40) CHARACTER SET utf8 COMMENT '真实姓名',
  `birthday` varchar(12) COMMENT '生日',
	`image` varchar(40) COMMENT '用户头像',
	`registerTime` Datetime DEFAULT NOW() COMMENT '时间',
	`lastLoginTime` Datetime DEFAULT NOW() COMMENT '最后登录时间',
  `modifyDTM` Datetime COMMENT '修改时间',	
  `allowused` TINYINT(1) COMMENT '是否可用',
  PRIMARY KEY(`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;