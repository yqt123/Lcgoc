/*
ģ�黯
*/
CREATE TABLE IF NOT EXISTS `module` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `moduleName` varchar(50) CHARACTER SET utf8 COMMENT'ģ������',
  `queryApiUrl` varchar(50) COMMENT '��ѯ�ӿ�',
  `minimumCountColumns` varchar(20) COMMENT '��С��ʾ�б���',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`moduleCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ�黯��������
*/
CREATE TABLE IF NOT EXISTS `module_actions` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `actionCode` varchar(20) COMMENT 'ִ�б���',
  `actionName` varchar(50) CHARACTER SET utf8 COMMENT'��������',
  `exeProcedure` varchar(20) COMMENT 'ִ�д洢����',
  `glyphicon` varchar(20) COMMENT '��ť����ͼ��',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  `exeTableName` varchar(20) COMMENT 'ִ�����ݿ��',
  `sorting` varchar(50) COMMENT '�����ֶ�',
  PRIMARY KEY(`moduleCode`,`actionCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ�黯��ѯ����
*/
CREATE TABLE IF NOT EXISTS `module_actions_query` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `actionCode` varchar(20) COMMENT 'ִ�б���',
  `queryCode` varchar(20) COMMENT '��ѯ����',
  `queryName` varchar(50) CHARACTER SET utf8 COMMENT'��ѯ����',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  PRIMARY KEY(`moduleCode`,`actionCode`,`queryCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ�黯��ʾ��
*/
CREATE TABLE IF NOT EXISTS `module_actions_columns` (
  `moduleCode` varchar(20) COMMENT 'ģ�����',
  `actionCode` varchar(20) COMMENT 'ִ�б���',
  `columnCode` varchar(20) COMMENT '�б���',
  `columnName` varchar(50) CHARACTER SET utf8 COMMENT'������',
	`inAdd` TINYINT(1) COMMENT '����������ʾ',
	`inEdit` TINYINT(1) COMMENT '�ڱ༭����ʾ',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  `level` INT COMMENT '����',
  PRIMARY KEY(`moduleCode`,`actionCode`,`columnCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ��ִ�ж���
*/
CREATE TABLE IF NOT EXISTS `module_queue` (
  `queueCode` varchar(20) COMMENT '���б��',
  `describe` varchar(50) CHARACTER SET utf8 COMMENT'����',
	`allowused` TINYINT(1) COMMENT '�Ƿ����',
  `modifyDTM` Datetime COMMENT 'ʱ��',
  `moduleCode` varchar(20) COMMENT 'ģ����',
  `actionCode` varchar(20) COMMENT 'ִ�б��',
  `userId` varchar(20) COMMENT '�û����',
  PRIMARY KEY(`queueCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*
ģ��ִ�ж�����ϸ
*/
CREATE TABLE IF NOT EXISTS `module_queue_detail` (
  `queueCode` varchar(20) COMMENT '���б��',
  `sequence` varchar(20) COMMENT '���',
  `id` varchar(50) COMMENT '�ֶ�ID',
  `value` varchar(400) CHARACTER SET utf8 COMMENT '�ֶ�ֵ'
  PRIMARY KEY(`queueCode`,`sequence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
