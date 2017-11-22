CREATE TABLE IF NOT EXISTS `crm_weixin_log` (
  `guid` varchar(50) COMMENT '全局唯一',
  `openId` varchar(50) COMMENT '微信用户OpenID',
  `myUserName` varchar(50) COMMENT'公众号',
  `domain` varchar(50) COMMENT'域名',
  `Type` varchar(40) COMMENT '操作类型',
  `request` varchar(2000) CHARACTER SET utf8 COMMENT'请求',
  `response` varchar(2000) CHARACTER SET utf8 COMMENT'返回',
  `startTime` varchar(40) COMMENT '开始时间',
  `endTime` varchar(40) COMMENT '结束时间',
  PRIMARY KEY(`guid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;