CREATE TABLE IF NOT EXISTS `admin_menu_detail_right` (
  `userId` varchar(20) COMMENT '�û����',
  `controller` varchar(40) COMMENT '������',
  `action` varchar(40) COMMENT '����',
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`userId`,`controller`,`action`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
