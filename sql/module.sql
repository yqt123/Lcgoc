/*
模块化
*/
CREATE TABLE IF NOT EXISTS `module` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `moduleName` varchar(50) CHARACTER SET utf8 COMMENT'模块名称',
  `queryApiUrl` varchar(20) COMMENT '查询接口',
  `minimumCountColumns` varchar(20) COMMENT '最小显示列表数',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`moduleCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块化查询条件
*/
CREATE TABLE IF NOT EXISTS `module_query` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `queryCode` varchar(20) COMMENT '查询编码',
  `queryName` varchar(50) CHARACTER SET utf8 COMMENT'模块名称',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`moduleCode`,`queryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块化操作功能
*/
CREATE TABLE IF NOT EXISTS `module_actions` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `actionCode` varchar(20) COMMENT '查询编码',
  `actionName` varchar(50) CHARACTER SET utf8 COMMENT'模块名称',
  `glyphicon` varchar(20) COMMENT '按钮字体图标',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`moduleCode`,`actionCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块化显示列
*/
CREATE TABLE IF NOT EXISTS `module_columns` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `columnCode` varchar(20) COMMENT '列编码',
  `columnName` varchar(50) CHARACTER SET utf8 COMMENT'模块名称',
	`inAdd` TINYINT(1) COMMENT '在新增中显示',
	`inEdit` TINYINT(1) COMMENT '在编辑中显示',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`moduleCode`,`columnCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
