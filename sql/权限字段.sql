
CALL Add_Column (
	'admin_menu_detail_right',-- 表名,
	'View', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '0',-- 默认值,
  '查看权限' -- 备注
);

CALL Add_Column (
	'admin_menu_detail_right',-- 表名,
	'Add', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '0',-- 默认值,
  '新增权限' -- 备注
);

CALL Add_Column (
	'admin_menu_detail_right',-- 表名,
	'Delete', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '0',-- 默认值,
  '删除权限' -- 备注
);

CALL Add_Column (
	'admin_menu_detail_right',-- 表名,
	'Edit', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '0',-- 默认值,
  '修改权限' -- 备注
);
