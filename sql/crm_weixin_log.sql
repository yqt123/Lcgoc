CREATE TABLE IF NOT EXISTS `crm_weixin_log` (
  `guid` varchar(50) COMMENT 'ȫ��Ψһ',
  `openId` varchar(50) COMMENT '΢���û�OpenID',
  `myUserName` varchar(50) COMMENT'���ں�',
  `domain` varchar(50) COMMENT'����',
  `Type` varchar(40) COMMENT '��������',
  `request` varchar(2000) CHARACTER SET utf8 COMMENT'����',
  `response` varchar(2000) CHARACTER SET utf8 COMMENT'����',
  `startTime` varchar(40) COMMENT '��ʼʱ��',
  `endTime` varchar(40) COMMENT '����ʱ��',
  PRIMARY KEY(`guid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;