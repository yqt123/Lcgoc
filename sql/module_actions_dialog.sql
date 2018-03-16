CALL Add_Column (
	'module_actions',-- 表名,
	'dialog', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '弹窗显示' -- 备注
);

CALL Add_Column (
	'module',-- 表名,
	'tableHeight', -- 字段名,
	'int', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '表格高' -- 备注
);

CALL Add_Column (
	'module_actions',-- 表名,
	'apiUrl', -- 字段名,
	'varchar(50)', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '执行方法接口' -- 备注
);

CALL Add_Column (
	'module_actions_columns',-- 表名,
	'keyword', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '主键' -- 备注
);