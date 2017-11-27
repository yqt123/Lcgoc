
CREATE TABLE IF NOT EXISTS `sys_controller_action` (
  `controller` varchar(40) COMMENT '控制器',
  `action` varchar(40) COMMENT '控制器',
  `name` varchar(40) CHARACTER SET utf8 COMMENT '方法名称',
  `allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT '时间',
  PRIMARY KEY(`controller`,`action`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
