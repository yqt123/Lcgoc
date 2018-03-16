CREATE TABLE IF NOT EXISTS `Sys_State` (
  `StateFixFlag` varchar(50) NOT NULL,
  `StateId` int(11) NOT NULL,
  `CNStateName` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `TWStateName` varchar(100)  CHARACTER SET utf8 DEFAULT NULL,
  `ENStateName` varchar(100)  CHARACTER SET utf8 DEFAULT NULL,
  `StateType` varchar(50) DEFAULT NULL,
  `Remark` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `AllowUsed` bit(1) DEFAULT NULL,
  PRIMARY KEY (`StateFixFlag`,`StateId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;