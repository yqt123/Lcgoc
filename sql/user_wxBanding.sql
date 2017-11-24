CREATE TABLE IF NOT EXISTS `user_wxBanding` (
  `userId` varchar(20) COMMENT '用户编号',
  `appnum` varchar(40) COMMENT '公众号',
  `openid` varchar(40) COMMENT '用户OpenID',
  `wxImage` varchar(100) COMMENT '微信头像',
  `modifyDTM` Datetime COMMENT '修改时间',	
  `allowused` TINYINT(1) COMMENT '是否可用',
  PRIMARY KEY(`userId`,`appnum`,`openid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;