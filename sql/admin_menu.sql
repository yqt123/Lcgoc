
CREATE TABLE IF NOT EXISTS `admin_menu` (
  `code` varchar(20) COMMENT '�˵�����',
  `icon` varchar(20) COMMENT'����ͼ��',
  `name` varchar(500) CHARACTER SET utf8 COMMENT'��������',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  `level` INT COMMENT '����',
  PRIMARY KEY(`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `admin_menu_detail` (
  `code` varchar(20) COMMENT '�˵�����',
  `sequence` INT COMMENT '���',
  `name` varchar(200) CHARACTER SET utf8 COMMENT'��������',
  `area` varchar(40) COMMENT '����',
  `controller` varchar(40) COMMENT '������',
  `action` varchar(40) COMMENT '����',
  `ajaxlink` TINYINT(1) COMMENT '�Ƿ��첽����',
  `allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  `level` INT COMMENT '����',
  PRIMARY KEY(`code`,`sequence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
