
/*
登录凭证
*/
CREATE TABLE IF NOT EXISTS `crm_loginToken` (
  `identity` varchar(40) COMMENT '用户身份',
  `token` varchar(100) COMMENT '身份凭证',
  `createDate` Datetime DEFAULT NOW() COMMENT '创建时间',
  `ExpiresDays` INT COMMENT '有效天数',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT '修改时间',
  PRIMARY KEY(`identity`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
登录凭证日志
*/
CREATE TABLE IF NOT EXISTS `crm_loginToken_log` (
	`id` BIGINT auto_increment COMMENT '自增ID',
  `identity` varchar(40) COMMENT '用户身份',
	`userAgent` varchar(150) COMMENT '代理设备',
	`ip` varchar(20) COMMENT '登录ip',
	`token` varchar(100) COMMENT '身份凭证',
  `modifyDTM` Datetime COMMENT '修改时间',
  PRIMARY KEY(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
