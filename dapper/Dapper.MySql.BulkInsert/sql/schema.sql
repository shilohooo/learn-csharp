create database if not exists dapper_test;

use dapper_test;

create table if not exists t_user(
    id bigint primary key auto_increment comment 'ID',
    username varchar(255) comment '用户名',
    email  varchar(255) comment '电子邮箱',
    address varchar(255) comment '家庭住址',
    age int comment '年龄'
) comment '用户信息表';