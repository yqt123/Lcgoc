CREATE TABLE IF NOT EXISTS `role` (
  `roleId` BIGINT auto_increment COMMENT '自增ID',
  `name` varchar(50) CHARACTER SET utf8 COMMENT'角色名称',
  `remark` varchar(200) CHARACTER SET utf8 COMMENT'角色备注',
  `allowused` TINYINT(1) COMMENT '是否可用',
  `modifyDTM` Datetime DEFAULT NOW() COMMENT '时间',
  PRIMARY KEY(`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
