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
	'varchar(100)', -- 字段类型,
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

CALL Add_Column (
	'module_actions_query',-- 表名,
	'level', -- 字段名,
	'INT', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '排序' -- 备注
);
CALL Add_Column (
	'module_queue_detail',-- 表名,
	'keyword', -- 字段名,
	'TINYINT', -- 字段类型,
  '1',-- 允许为空,
  '0',-- 默认值,
  '主键' -- 备注
);

CALL Add_Column (
	'module_actions',-- 表名,
	'level', -- 字段名,
	'INT', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '排序' -- 备注
);

CALL Add_Column (
	'module_actions_columns',-- 表名,
	'typeof', -- 字段名,
	'varchar(20)', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '数据类型' -- 备注
);

CALL Add_Column (
	'module_actions_columns',-- 表名,
	'glyphicon', -- 字段名,
	'varchar(50)', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '列显示图标' -- 备注
);