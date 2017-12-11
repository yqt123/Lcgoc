CALL Add_Column (
	'user',-- 表名,
	'IsSuperuser', -- 字段名,
	'TINYINT(1)', -- 字段类型,
  '1',-- 允许为空,
  '0',-- 默认值,
  '是否超级管理员' -- 备注
);
