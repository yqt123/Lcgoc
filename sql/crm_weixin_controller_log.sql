/*
΢��������־
*/
CREATE TABLE IF NOT EXISTS `crm_weixin_controller_log` (
  `guid` varchar(50) COMMENT 'ȫ��Ψһ',
  `signature` varchar(50) COMMENT '΢�ż���ǩ��',
  `timestamp` varchar(20) COMMENT'ʱ���',
  `nonce` varchar(20) COMMENT'�����',
  `openid` varchar(50) COMMENT '΢��OpenID',
  `url` varchar(2000) CHARACTER SET utf8 COMMENT'Post��ַ',
  `msg_signature` varchar(50) COMMENT '���ݼ���ǩ��',
  `msg` varchar(2000) CHARACTER SET utf8 COMMENT'��������,���ܼ���',
  `res` varchar(200) CHARACTER SET utf8 COMMENT'���봦����',
	`modifyDTM` Datetime DEFAULT NOW() COMMENT '����ʱ��',
  PRIMARY KEY(`guid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;