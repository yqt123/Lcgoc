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
	'varchar(50)', -- �ֶ�����,
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