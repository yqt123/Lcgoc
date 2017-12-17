CREATE TABLE IF NOT EXISTS `sys_controller_action_role` (
  `area` varchar(40) COMMENT '区域',
  `controller` varchar(40) COMMENT '控制器',
  `action` varchar(40) COMMENT '控制器',
  `roleId` varchar(20) COMMENT'角色ID',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT '时间',
  PRIMARY KEY(`controller`,`action`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
