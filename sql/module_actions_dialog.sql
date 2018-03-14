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
