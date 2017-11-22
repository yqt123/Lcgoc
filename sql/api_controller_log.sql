CREATE TABLE IF NOT EXISTS `api_controller_log` (
	`id` BIGINT auto_increment COMMENT '����ID',
  `code` varchar(20) COMMENT 'API����',
  `request` varchar(2000) CHARACTER SET utf8 COMMENT'����',
  `response` varchar(2000) CHARACTER SET utf8 COMMENT'����',
  `startTime` varchar(40) COMMENT '��ʼʱ��',
  `endTime` varchar(40) COMMENT '����ʱ��',
  `state` TINYINT(1) COMMENT '״̬',
  PRIMARY KEY(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;