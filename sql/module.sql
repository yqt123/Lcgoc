/*
模块化
*/
CREATE TABLE IF NOT EXISTS `module` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `moduleName` varchar(50) CHARACTER SET utf8 COMMENT'模块名称',
  `queryApiUrl` varchar(50) COMMENT '查询接口',
  `minimumCountColumns` varchar(20) COMMENT '最小显示列表数',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`moduleCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块化操作功能
*/
CREATE TABLE IF NOT EXISTS `module_actions` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `actionCode` varchar(20) COMMENT '执行编码',
  `actionName` varchar(50) CHARACTER SET utf8 COMMENT'操作名称',
  `exeProcedure` varchar(20) COMMENT '执行存储过程',
  `glyphicon` varchar(20) COMMENT '按钮字体图标',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  `exeTableName` varchar(20) COMMENT '执行数据库表',
  `sorting` varchar(50) COMMENT '排序字段',
  PRIMARY KEY(`moduleCode`,`actionCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块化查询条件
*/
CREATE TABLE IF NOT EXISTS `module_actions_query` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `actionCode` varchar(20) COMMENT '执行编码',
  `queryCode` varchar(20) COMMENT '查询编码',
  `queryName` varchar(50) CHARACTER SET utf8 COMMENT'查询名称',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  PRIMARY KEY(`moduleCode`,`actionCode`,`queryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块化显示列
*/
CREATE TABLE IF NOT EXISTS `module_actions_columns` (
  `moduleCode` varchar(20) COMMENT '模块编码',
  `actionCode` varchar(20) COMMENT '执行编码',
  `columnCode` varchar(20) COMMENT '列编码',
  `columnName` varchar(50) CHARACTER SET utf8 COMMENT'列名称',
	`inAdd` TINYINT(1) COMMENT '在新增中显示',
	`inEdit` TINYINT(1) COMMENT '在编辑中显示',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  `level` INT COMMENT '排序',
  PRIMARY KEY(`moduleCode`,`actionCode`,`columnCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块执行队列
*/
CREATE TABLE IF NOT EXISTS `module_queue` (
  `queueCode` varchar(20) COMMENT '队列编号',
  `describe` varchar(50) CHARACTER SET utf8 COMMENT'描述',
	`allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime COMMENT '时间',
  `moduleCode` varchar(20) COMMENT '模块编号',
  `actionCode` varchar(20) COMMENT '执行编号',
  `userId` varchar(20) COMMENT '用户编号',
  PRIMARY KEY(`queueCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
模块执行队列明细
*/
CREATE TABLE IF NOT EXISTS `module_queue_detail` (
  `queueCode` varchar(20) COMMENT '队列编号',
  `sequence` varchar(20) COMMENT '序号',
  `id` varchar(50) COMMENT '字段ID',
  `value` varchar(400) CHARACTER SET utf8 COMMENT '字段值'
  PRIMARY KEY(`queueCode`,`sequence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
