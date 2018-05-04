CREATE TABLE IF NOT EXISTS `scheduleJob` (
  `id` BIGINT NOT NULL auto_increment COMMENT '自增ID',
  `sched_name` varchar(50) NOT NULL COMMENT '调度作业',
  `job_name` varchar(50) NOT NULL COMMENT '作业名称',
  `writeDBLog` TINYINT NOT NULL COMMENT '是否写数据库日志',
  `writeTxtLog` TINYINT NOT NULL COMMENT '是否写本地日志',
  `allowused` TINYINT DEFAULT NULL COMMENT '1有效0无效',
  PRIMARY KEY (`sched_name`,`job_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_details` (
  `id` BIGINT NOT NULL auto_increment COMMENT '自增ID',
  `sched_name` varchar(50) NOT NULL COMMENT '调度作业',
  `job_name` varchar(50) NOT NULL COMMENT '作业名',
  `job_group` varchar(200) NULL COMMENT '作业主',
  `job_class_name` varchar(250) NULL COMMENT '作业类名',
  `is_durable` TINYINT NULL COMMENT '是否可用',
  `description` varchar(250) NULL CHARACTER SET utf8 COMMENT '描述',
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  PRIMARY KEY (`sched_name`,`job_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_details_triggers` (
  `id` BIGINT NOT NULL auto_increment COMMENT '自增ID',
  `sched_name` varchar(200) NOT NULL COMMENT '调度作业',
  `job_name` varchar(200) NOT NULL COMMENT '作业名',
  `trigger_name` varchar(200) NOT NULL COMMENT '触发器名称',
  `trigger_group` varchar(200) NOT NULL COMMENT '触发器组',
  `job_group` varchar(200) NULL COMMENT '作业组',
  `cronexpression` varchar(250) NULL COMMENT '作业启动设置',
  `trigger_type` varchar(500) NULL COMMENT '触发类型',
  `repeat_count` int(5) NULL COMMENT '重复次数',
  `repeat_interval` int(5) NULL COMMENT '重复间隔',
  `startTime` datetime DEFAULT NULL COMMENT '作业开始时间',
  `endTime` datetime DEFAULT NULL COMMENT '作业结束时间',
  `description` varchar(250) NULL CHARACTER SET utf8 COMMENT '描述',
  PRIMARY KEY (`sched_name`,`job_name`,`trigger_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_log` (
  `sched_logId` BIGINT NOT NULL auto_increment,
  `sched_name` varchar(200) NOT NULL COMMENT '调度作业',
  `job_name` varchar(200) NOT NULL COMMENT '作业名',
  `success` TINYINT NULL COMMENT '是否成功',
  `update_time` datetime DEFAULT NULL COMMENT '更新时间时间',
  `description` varchar(250) NULL CHARACTER SET utf8 COMMENT '描述',
  PRIMARY KEY (`sched_logID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_apiLog` (
  `apiLogId` BIGINT NOT NULL auto_increment,
  `apiID` varchar(200) NOT NULL COMMENT '接口ID',
  `apiName` varchar(200) NOT NULL COMMENT '接口名称',
  `post` varchar(4000) NULL CHARACTER SET utf8,
  `get` varchar(4000) NULL CHARACTER SET utf8,
  `state` TINYINT NULL COMMENT '调用状态',
  `remark` varchar(300) NULL CHARACTER SET utf8,
  `modifyDTM` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  PRIMARY KEY (`apiLogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

