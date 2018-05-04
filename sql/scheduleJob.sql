CREATE TABLE IF NOT EXISTS `scheduleJob` (
  `id` BIGINT NOT NULL auto_increment COMMENT '����ID',
  `sched_name` varchar(50) NOT NULL COMMENT '������ҵ',
  `job_name` varchar(50) NOT NULL COMMENT '��ҵ����',
  `writeDBLog` TINYINT NOT NULL COMMENT '�Ƿ�д���ݿ���־',
  `writeTxtLog` TINYINT NOT NULL COMMENT '�Ƿ�д������־',
  `allowused` TINYINT DEFAULT NULL COMMENT '1��Ч0��Ч',
  PRIMARY KEY (`sched_name`,`job_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_details` (
  `id` BIGINT NOT NULL auto_increment COMMENT '����ID',
  `sched_name` varchar(50) NOT NULL COMMENT '������ҵ',
  `job_name` varchar(50) NOT NULL COMMENT '��ҵ��',
  `job_group` varchar(200) NULL COMMENT '��ҵ��',
  `job_class_name` varchar(250) NULL COMMENT '��ҵ����',
  `is_durable` TINYINT NULL COMMENT '�Ƿ����',
  `description` varchar(250) NULL CHARACTER SET utf8 COMMENT '����',
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  PRIMARY KEY (`sched_name`,`job_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_details_triggers` (
  `id` BIGINT NOT NULL auto_increment COMMENT '����ID',
  `sched_name` varchar(200) NOT NULL COMMENT '������ҵ',
  `job_name` varchar(200) NOT NULL COMMENT '��ҵ��',
  `trigger_name` varchar(200) NOT NULL COMMENT '����������',
  `trigger_group` varchar(200) NOT NULL COMMENT '��������',
  `job_group` varchar(200) NULL COMMENT '��ҵ��',
  `cronexpression` varchar(250) NULL COMMENT '��ҵ��������',
  `trigger_type` varchar(500) NULL COMMENT '��������',
  `repeat_count` int(5) NULL COMMENT '�ظ�����',
  `repeat_interval` int(5) NULL COMMENT '�ظ����',
  `startTime` datetime DEFAULT NULL COMMENT '��ҵ��ʼʱ��',
  `endTime` datetime DEFAULT NULL COMMENT '��ҵ����ʱ��',
  `description` varchar(250) NULL CHARACTER SET utf8 COMMENT '����',
  PRIMARY KEY (`sched_name`,`job_name`,`trigger_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_log` (
  `sched_logId` BIGINT NOT NULL auto_increment,
  `sched_name` varchar(200) NOT NULL COMMENT '������ҵ',
  `job_name` varchar(200) NOT NULL COMMENT '��ҵ��',
  `success` TINYINT NULL COMMENT '�Ƿ�ɹ�',
  `update_time` datetime DEFAULT NULL COMMENT '����ʱ��ʱ��',
  `description` varchar(250) NULL CHARACTER SET utf8 COMMENT '����',
  PRIMARY KEY (`sched_logID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `scheduleJob_apiLog` (
  `apiLogId` BIGINT NOT NULL auto_increment,
  `apiID` varchar(200) NOT NULL COMMENT '�ӿ�ID',
  `apiName` varchar(200) NOT NULL COMMENT '�ӿ�����',
  `post` varchar(4000) NULL CHARACTER SET utf8,
  `get` varchar(4000) NULL CHARACTER SET utf8,
  `state` TINYINT NULL COMMENT '����״̬',
  `remark` varchar(300) NULL CHARACTER SET utf8,
  `modifyDTM` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  PRIMARY KEY (`apiLogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

