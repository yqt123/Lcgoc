CREATE TABLE IF NOT EXISTS `access_token` (
  `appId` varchar(20) COMMENT '�������û�Ψһƾ֤',
  `appSecret` varchar(50) COMMENT '�������û�Ψһƾ֤��Կ����appsecret',
  `token` varchar(50) COMMENT '��ȡ����ƾ֤',
  `expiresIn` INT COMMENT 'ƾ֤��Чʱ�䣬��λ����',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT 'ʱ��',
  PRIMARY KEY(`appid`,`AppSecret`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
