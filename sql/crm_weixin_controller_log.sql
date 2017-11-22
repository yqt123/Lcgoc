/*
微信请求日志
*/
CREATE TABLE IF NOT EXISTS `crm_weixin_controller_log` (
  `guid` varchar(50) COMMENT '全局唯一',
  `signature` varchar(50) COMMENT '微信加密签名',
  `timestamp` varchar(20) COMMENT'时间戳',
  `nonce` varchar(20) COMMENT'随机数',
  `openid` varchar(50) COMMENT '微信OpenID',
  `url` varchar(2000) CHARACTER SET utf8 COMMENT'Post地址',
  `msg_signature` varchar(50) COMMENT '内容加密签名',
  `msg` varchar(2000) CHARACTER SET utf8 COMMENT'传入内容,可能加密',
  `res` varchar(200) CHARACTER SET utf8 COMMENT'传入处理结果',
	`modifyDTM` Datetime DEFAULT NOW() COMMENT '创建时间',
  PRIMARY KEY(`guid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;