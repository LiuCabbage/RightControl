/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : rightcontrol

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-06-20 10:26:33
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_action
-- ----------------------------
DROP TABLE IF EXISTS `t_action`;
CREATE TABLE `t_action` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `ActionCode` varchar(20) DEFAULT NULL COMMENT '操作编码',
  `ActionName` varchar(40) DEFAULT NULL COMMENT '操作名称',
  `Position` int(11) DEFAULT NULL COMMENT '显示位置（1：表单内，2：表单右上）',
  `Icon` varchar(30) DEFAULT NULL COMMENT '图标',
  `Method` varchar(20) DEFAULT NULL COMMENT '方法名称',
  `Remark` varchar(50) DEFAULT NULL COMMENT '说明',
  `OrderBy` int(4) DEFAULT NULL COMMENT '排序号',
  `Status` bit(1) DEFAULT NULL COMMENT '状态',
  `CreateOn` datetime DEFAULT NULL COMMENT '创建时间',
  `UpdateOn` datetime DEFAULT NULL COMMENT '更新时间',
  `CreateBy` int(4) DEFAULT NULL COMMENT '创建者',
  `UpdateBy` int(4) DEFAULT NULL COMMENT '更新者',
  `ClassName` varchar(30) DEFAULT NULL COMMENT '样式名称',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='操作表';

-- ----------------------------
-- Records of t_action
-- ----------------------------
INSERT INTO `t_action` VALUES ('1', 'Add', '添加', '1', 'icon-add', 'Add', null, '0', '', '2019-02-28 14:44:33', '2019-06-15 23:32:07', '0', '1', null);
INSERT INTO `t_action` VALUES ('2', 'edit', '编辑', '0', 'icon-bianji', 'edit', null, '0', '', '2019-02-28 14:44:36', '2019-02-28 14:45:21', '0', '0', null);
INSERT INTO `t_action` VALUES ('3', 'detail', '查看', '0', 'icon-chakan', 'detail', null, '0', '', '2019-02-28 14:44:39', '2019-02-28 14:45:24', '0', '0', 'layui-btn-normal');
INSERT INTO `t_action` VALUES ('4', 'del', '删除', '0', 'icon-guanbi', 'del', null, '0', '', '2019-02-28 14:44:42', '2019-02-28 14:45:27', '0', '0', 'layui-btn-danger');
INSERT INTO `t_action` VALUES ('5', 'reset', '重置密码', '0', 'icon-reset', 'reset', null, '0', '', '2019-02-28 14:44:45', '2019-06-15 23:34:55', '0', '1', 'layui-btn-warm');
INSERT INTO `t_action` VALUES ('6', 'assign', '分配权限', '0', 'icon-jiaoseguanli', 'assign', null, '0', '', '2019-02-28 14:44:48', '2019-02-28 14:45:34', '0', '0', null);
INSERT INTO `t_action` VALUES ('7', 'BatchDel', '批量删除', '1', 'icon-shanchu', 'BatchDel', null, '0', '', '2019-06-15 23:34:15', '0001-01-01 00:00:00', '1', '0', null);
INSERT INTO `t_action` VALUES ('8', 'menu_action', '菜单权限', '0', 'icon-setting-permissions', 'menu_action', null, '0', '', '2019-06-17 17:00:29', '0001-01-01 00:00:00', '1', '0', null);

-- ----------------------------
-- Table structure for t_log
-- ----------------------------
DROP TABLE IF EXISTS `t_log`;
CREATE TABLE `t_log` (
  `Id` int(4) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `LogType` varchar(20) DEFAULT NULL COMMENT '日志类型',
  `UserName` varchar(20) DEFAULT NULL COMMENT '用户名称',
  `RealName` varchar(20) DEFAULT NULL COMMENT '操作账户',
  `ModuleName` varchar(20) DEFAULT NULL COMMENT '日志模块',
  `Description` varchar(200) DEFAULT NULL COMMENT '日志描述',
  `CreateOn` datetime DEFAULT NULL COMMENT '创建日期',
  `IPAddress` varchar(20) DEFAULT NULL COMMENT 'IP地址',
  `IPAddressName` varchar(100) DEFAULT NULL COMMENT 'IP所在地',
  `Status` bit(1) DEFAULT NULL COMMENT '状态',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8 COMMENT='日志表';

-- ----------------------------
-- Records of t_log
-- ----------------------------
INSERT INTO `t_log` VALUES ('1', 'Login', 'admin', '超级管理员', '系统登录', '登录成功', '2019-06-15 22:56:18', '192.168.1.2', '本地局域网', '');
INSERT INTO `t_log` VALUES ('2', 'Login', 'admin', '超级管理员', '系统登录', '登录成功', '2019-06-15 23:11:59', '192.168.1.2', '本地局域网', '');
INSERT INTO `t_log` VALUES ('3', 'Exit', 'admin', '超级管理员', null, '安全退出系统', '2019-06-15 23:12:04', '192.168.1.2', '本地局域网', '');

-- ----------------------------
-- Table structure for t_menu
-- ----------------------------
DROP TABLE IF EXISTS `t_menu`;
CREATE TABLE `t_menu` (
  `Id` int(4) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `MenuName` varchar(20) DEFAULT NULL COMMENT '菜单名称',
  `MenuUrl` varchar(60) DEFAULT NULL COMMENT '菜单地址',
  `MenuIcon` varchar(30) DEFAULT NULL COMMENT '菜单图标',
  `OrderNo` tinyint(4) DEFAULT '0' COMMENT '排序号',
  `ParentId` int(4) DEFAULT '0' COMMENT '父菜单',
  `Status` bit(1) DEFAULT NULL COMMENT '状态',
  `CreateOn` datetime DEFAULT NULL COMMENT '创建时间',
  `UpdateOn` datetime DEFAULT NULL COMMENT '修改时间',
  `CreateBy` int(4) DEFAULT NULL COMMENT '创建者',
  `UpdateBy` int(4) DEFAULT NULL COMMENT '编辑者',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COMMENT='菜单表';

-- ----------------------------
-- Records of t_menu
-- ----------------------------
INSERT INTO `t_menu` VALUES ('1', '权限管理', null, 'icon-setting-permissions', '0', '0', '', '2019-02-28 15:03:14', '2019-06-17 17:11:25', '0', '1');
INSERT INTO `t_menu` VALUES ('2', '菜单管理', '/permissions/menu', 'icon-caidan', '1', '1', '', '2019-02-28 15:03:20', '2019-02-28 15:03:23', '0', '0');
INSERT INTO `t_menu` VALUES ('3', '角色管理', '/permissions/role', 'icon-jiaoseguanli', '2', '1', '', '2019-02-28 15:03:25', '2019-02-28 15:03:29', '0', '0');
INSERT INTO `t_menu` VALUES ('4', '用户管理', '/permissions/user', 'icon-yonghu', '3', '1', '', '2019-02-28 15:03:32', '2019-02-28 15:03:35', '0', '0');
INSERT INTO `t_menu` VALUES ('5', '操作管理', '/permissions/action', 'icon-shezhi', '4', '1', '', '2019-02-28 15:03:39', '2019-02-28 15:03:43', '0', '0');
INSERT INTO `t_menu` VALUES ('6', '系统设置', null, 'icon-xitong', '0', '0', '', '2019-02-28 15:03:46', '2019-02-28 15:03:48', '0', '0');
INSERT INTO `t_menu` VALUES ('7', '网站设置', '/sysset/website', 'icon-ditu', '1', '6', '', '2019-02-28 15:03:51', '2019-02-28 15:03:53', '0', '0');
INSERT INTO `t_menu` VALUES ('8', '基本资料', '/SysSet/info', 'icon-jibenziliao', '2', '6', '', '2019-02-28 15:03:56', '2019-02-28 15:03:58', '0', '0');
INSERT INTO `t_menu` VALUES ('9', '修改密码', '/SysSet/password', 'icon-xiugaimima', '3', '6', '', '2019-02-28 15:04:02', '2019-02-28 15:04:05', '0', '0');
INSERT INTO `t_menu` VALUES ('10', '日志管理', '/SysSet/Log', 'icon-xitongrizhi', '4', '6', '', '2019-02-28 15:04:07', '2019-02-28 15:04:10', '0', '0');

-- ----------------------------
-- Table structure for t_menu_action
-- ----------------------------
DROP TABLE IF EXISTS `t_menu_action`;
CREATE TABLE `t_menu_action` (
  `MenuId` int(11) DEFAULT NULL COMMENT '菜单ID',
  `ActionId` int(11) DEFAULT NULL COMMENT '操作ID',
  UNIQUE KEY `idx_MenuId_ActionId` (`MenuId`,`ActionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='菜单操作表';

-- ----------------------------
-- Records of t_menu_action
-- ----------------------------
INSERT INTO `t_menu_action` VALUES ('2', '1');
INSERT INTO `t_menu_action` VALUES ('2', '2');
INSERT INTO `t_menu_action` VALUES ('2', '4');
INSERT INTO `t_menu_action` VALUES ('2', '8');
INSERT INTO `t_menu_action` VALUES ('3', '1');
INSERT INTO `t_menu_action` VALUES ('3', '2');
INSERT INTO `t_menu_action` VALUES ('3', '3');
INSERT INTO `t_menu_action` VALUES ('3', '4');
INSERT INTO `t_menu_action` VALUES ('3', '6');
INSERT INTO `t_menu_action` VALUES ('4', '1');
INSERT INTO `t_menu_action` VALUES ('4', '2');
INSERT INTO `t_menu_action` VALUES ('4', '3');
INSERT INTO `t_menu_action` VALUES ('4', '4');
INSERT INTO `t_menu_action` VALUES ('4', '5');
INSERT INTO `t_menu_action` VALUES ('5', '1');
INSERT INTO `t_menu_action` VALUES ('5', '2');
INSERT INTO `t_menu_action` VALUES ('5', '3');
INSERT INTO `t_menu_action` VALUES ('5', '4');
INSERT INTO `t_menu_action` VALUES ('10', '4');
INSERT INTO `t_menu_action` VALUES ('10', '7');

-- ----------------------------
-- Table structure for t_menu_role_action
-- ----------------------------
DROP TABLE IF EXISTS `t_menu_role_action`;
CREATE TABLE `t_menu_role_action` (
  `MenuId` int(11) DEFAULT NULL COMMENT '菜单ID',
  `RoleId` int(11) DEFAULT NULL COMMENT '角色ID',
  `ActionId` int(11) DEFAULT NULL COMMENT '操作ID',
  UNIQUE KEY `idx_RoleId_MenuId` (`MenuId`,`RoleId`,`ActionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='菜单角色表';

-- ----------------------------
-- Records of t_menu_role_action
-- ----------------------------
INSERT INTO `t_menu_role_action` VALUES ('1', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('1', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('2', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('2', '1', '1');
INSERT INTO `t_menu_role_action` VALUES ('2', '1', '2');
INSERT INTO `t_menu_role_action` VALUES ('2', '1', '4');
INSERT INTO `t_menu_role_action` VALUES ('2', '1', '8');
INSERT INTO `t_menu_role_action` VALUES ('2', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('3', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('3', '1', '1');
INSERT INTO `t_menu_role_action` VALUES ('3', '1', '2');
INSERT INTO `t_menu_role_action` VALUES ('3', '1', '3');
INSERT INTO `t_menu_role_action` VALUES ('3', '1', '4');
INSERT INTO `t_menu_role_action` VALUES ('3', '1', '6');
INSERT INTO `t_menu_role_action` VALUES ('3', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('3', '3', '3');
INSERT INTO `t_menu_role_action` VALUES ('4', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('4', '1', '1');
INSERT INTO `t_menu_role_action` VALUES ('4', '1', '2');
INSERT INTO `t_menu_role_action` VALUES ('4', '1', '3');
INSERT INTO `t_menu_role_action` VALUES ('4', '1', '4');
INSERT INTO `t_menu_role_action` VALUES ('4', '1', '5');
INSERT INTO `t_menu_role_action` VALUES ('4', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('4', '3', '3');
INSERT INTO `t_menu_role_action` VALUES ('5', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('5', '1', '1');
INSERT INTO `t_menu_role_action` VALUES ('5', '1', '2');
INSERT INTO `t_menu_role_action` VALUES ('5', '1', '3');
INSERT INTO `t_menu_role_action` VALUES ('5', '1', '4');
INSERT INTO `t_menu_role_action` VALUES ('5', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('5', '3', '3');
INSERT INTO `t_menu_role_action` VALUES ('6', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('6', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('7', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('7', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('8', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('8', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('9', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('9', '3', '0');
INSERT INTO `t_menu_role_action` VALUES ('10', '1', '0');
INSERT INTO `t_menu_role_action` VALUES ('10', '1', '4');
INSERT INTO `t_menu_role_action` VALUES ('10', '1', '7');
INSERT INTO `t_menu_role_action` VALUES ('10', '3', '0');

-- ----------------------------
-- Table structure for t_role
-- ----------------------------
DROP TABLE IF EXISTS `t_role`;
CREATE TABLE `t_role` (
  `Id` int(4) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `RoleCode` varchar(20) DEFAULT NULL COMMENT '角色编码',
  `RoleName` varchar(30) DEFAULT NULL COMMENT '角色名称',
  `Remark` varchar(50) DEFAULT NULL COMMENT '角色描述',
  `Status` bit(1) DEFAULT NULL COMMENT '状态(1:有效，0：无效）',
  `CreateOn` datetime DEFAULT NULL COMMENT '创建时间',
  `UpdateOn` datetime DEFAULT NULL COMMENT '更新时间',
  `CreateBy` int(4) DEFAULT NULL COMMENT '创建者',
  `UpdateBy` int(4) DEFAULT NULL COMMENT '修改者',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='角色表';

-- ----------------------------
-- Records of t_role
-- ----------------------------
INSERT INTO `t_role` VALUES ('1', 'SysAdmin', '超级管理员', null, '', '2019-02-28 15:34:59', '2019-02-28 15:35:03', '0', '0');
INSERT INTO `t_role` VALUES ('2', 'GeneralAdmin', '普通管理员', null, '', '2019-02-28 15:35:09', '2019-02-28 15:35:06', '0', '0');
INSERT INTO `t_role` VALUES ('3', 'GeneralUser', '用户', null, '', '2019-02-28 15:35:13', '2019-02-28 15:35:15', '0', '0');

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `Id` int(4) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `UserName` varchar(20) DEFAULT NULL COMMENT '用户名（登录）',
  `RealName` varchar(20) DEFAULT NULL COMMENT '姓名',
  `PassWord` char(32) DEFAULT NULL COMMENT '密码',
  `RoleId` int(4) DEFAULT NULL COMMENT '角色ID',
  `Status` bit(1) DEFAULT NULL COMMENT '状态',
  `CreateOn` datetime DEFAULT NULL COMMENT '创建时间',
  `UpdateOn` datetime DEFAULT NULL COMMENT '修改时间',
  `CreateBy` int(4) DEFAULT NULL COMMENT '创建者',
  `UpdateBy` int(4) DEFAULT NULL COMMENT '修改者',
  `Gender` tinyint(4) DEFAULT NULL COMMENT '性别（0：男，1：女）',
  `Phone` varchar(11) DEFAULT NULL COMMENT '手机',
  `Email` varchar(30) DEFAULT NULL COMMENT '邮箱',
  `Remark` varchar(50) DEFAULT NULL COMMENT '备注',
  `HeadShot` varchar(50) DEFAULT NULL COMMENT '头像',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', 'admin', '超级管理员', 'e10adc3949ba59abbe56e057f20f883e', '1', '', '2019-02-28 16:18:52', '2019-06-20 09:53:05', '0', '1', '1', '11111111111', '123456@qq.com', '最高权限', '/Upload/img/502.jpg');
INSERT INTO `t_user` VALUES ('2', 'test', '普通管理员', 'e10adc3949ba59abbe56e057f20f883e', '2', '', '2019-02-28 16:21:31', '2019-02-28 16:21:34', '0', '0', '1', '178899573', '123456@qq.com', '普通权限', '');
INSERT INTO `t_user` VALUES ('3', 'user', '用户', 'e10adc3949ba59abbe56e057f20f883e', '3', '', '2019-02-28 16:22:15', '2019-02-28 16:22:19', '0', '0', '1', '178899573', '123456@qq.com', '低级权限', null);
