/*
ģ�黯
*/
CREATE TABLE IF NOT EXISTS `module` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `moduleName` varchar(50) CHARACTER SET utf8 COMMENT'ģ������',
  `queryApiUrl` varchar(20) COMMENT '��ѯ�ӿ�',
  `minimumCountColumns` varchar(20) COMMENT '��С��ʾ�б���',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`moduleCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ�黯��ѯ����
*/
CREATE TABLE IF NOT EXISTS `module_query` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `queryCode` varchar(20) COMMENT '��ѯ����',
  `queryName` varchar(50) CHARACTER SET utf8 COMMENT'��ѯ����',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`moduleCode`,`queryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ�黯��������
*/
CREATE TABLE IF NOT EXISTS `module_actions` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `actionCode` varchar(20) COMMENT '��ѯ����',
  `actionName` varchar(50) CHARACTER SET utf8 COMMENT'��������',
  `glyphicon` varchar(20) COMMENT '��ť����ͼ��',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`moduleCode`,`actionCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ�黯��ʾ��
*/
CREATE TABLE IF NOT EXISTS `module_columns` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `columnCode` varchar(20) COMMENT '�б���',
  `columnName` varchar(50) CHARACTER SET utf8 COMMENT'������',
	`inAdd` TINYINT(1) COMMENT '����������ʾ',
	`inEdit` TINYINT(1) COMMENT '�ڱ༭����ʾ',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`moduleCode`,`columnCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ��ִ�ж���
*/
CREATE TABLE IF NOT EXISTS `module_queue` (
  `userId` varchar(20) COMMENT '�û����',
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `actionCode` varchar(20) COMMENT '��������',
  `id` varchar(50) COMMENT '�ֶ�ID',
  `value` varchar(400) CHARACTER SET utf8 COMMENT '�ֶ�ֵ',
  PRIMARY KEY(`userId`,`moduleCode`,`actionCode`,`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

