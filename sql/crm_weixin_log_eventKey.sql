CALL Add_Column (
	'crm_weixin_log',-- 表名,
	'eventKey', -- 字段名,
	'varchar(50)', -- 字段类型,
  '1',-- 允许为空,
  '',-- 默认值,
  '事件关键字' -- 备注
);