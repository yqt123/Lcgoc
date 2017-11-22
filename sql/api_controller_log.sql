CREATE TABLE IF NOT EXISTS `api_controller_log` (
	`id` BIGINT auto_increment COMMENT '自增ID',
  `code` varchar(20) COMMENT 'API编码',
  `request` varchar(2000) CHARACTER SET utf8 COMMENT'请求',
  `response` varchar(2000) CHARACTER SET utf8 COMMENT'返回',
  `startTime` varchar(40) COMMENT '开始时间',
  `endTime` varchar(40) COMMENT '结束时间',
  `state` TINYINT(1) COMMENT '状态',
  PRIMARY KEY(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;