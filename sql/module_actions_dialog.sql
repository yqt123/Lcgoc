CALL Add_Column (
	'module_actions',-- ����,
	'dialog', -- �ֶ���,
	'TINYINT(1)', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '������ʾ' -- ��ע
);

CALL Add_Column (
	'module',-- ����,
	'tableHeight', -- �ֶ���,
	'int', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '����' -- ��ע
);

CALL Add_Column (
	'module_actions',-- ����,
	'apiUrl', -- �ֶ���,
	'varchar(100)', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  'ִ�з����ӿ�' -- ��ע
);

CALL Add_Column (
	'module_actions_columns',-- ����,
	'keyword', -- �ֶ���,
	'TINYINT(1)', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '����' -- ��ע
);

CALL Add_Column (
	'module_actions_query',-- ����,
	'level', -- �ֶ���,
	'INT', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '����' -- ��ע
);
CALL Add_Column (
	'module_queue_detail',-- ����,
	'keyword', -- �ֶ���,
	'TINYINT', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '0',-- Ĭ��ֵ,
  '����' -- ��ע
);

CALL Add_Column (
	'module_actions',-- ����,
	'level', -- �ֶ���,
	'INT', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '����' -- ��ע
);

CALL Add_Column (
	'module_actions_columns',-- ����,
	'typeof', -- �ֶ���,
	'varchar(20)', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '��������' -- ��ע
);

CALL Add_Column (
	'module_actions_columns',-- ����,
	'glyphicon', -- �ֶ���,
	'varchar(50)', -- �ֶ�����,
  '1',-- ����Ϊ��,
  '',-- Ĭ��ֵ,
  '����ʾͼ��' -- ��ע
);