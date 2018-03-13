
CREATE TABLE IF NOT EXISTS `indexnumbers` (
  `date` varchar(20) COMMENT '日期',
  `index` INT COMMENT '最大项',
  PRIMARY KEY(`date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
