CREATE TABLE IF NOT EXISTS `admin_menu_detail_right` (
  `userId` varchar(20) COMMENT '用户编号',
  `controller` varchar(40) COMMENT '控制器',
  `action` varchar(40) COMMENT '方法',
  `allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`userId`,`controller`,`action`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
