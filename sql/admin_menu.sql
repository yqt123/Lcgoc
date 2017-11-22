CREATE TABLE IF NOT EXISTS `admin_menu` (
  `code` varchar(20) COMMENT '菜单编码',
  `icon` varchar(20) COMMENT'标题图标',
  `name` varchar(500) CHARACTER SET utf8 COMMENT'标题名称',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` date COMMENT '时间',
  PRIMARY KEY(`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `admin_menu_detail` (
  `code` varchar(20) COMMENT '菜单编码',
  `sequence` INT COMMENT '序号',
  `name` varchar(200) CHARACTER SET utf8 COMMENT'标题名称',
  `url` varchar(40) COMMENT '链接',
  `ajaxlink` TINYINT(1) COMMENT '是否异步请求',
  `allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` date COMMENT '时间',
  PRIMARY KEY(`code`,`sequence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;