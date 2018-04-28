CREATE TABLE IF NOT EXISTS `access_token` (
  `appId` varchar(20) COMMENT '第三方用户唯一凭证',
  `appSecret` varchar(50) COMMENT '第三方用户唯一凭证密钥，即appsecret',
  `token` varchar(50) COMMENT '获取到的凭证',
  `expiresIn` INT COMMENT '凭证有效时间，单位：秒',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT '时间',
  PRIMARY KEY(`appid`,`AppSecret`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
