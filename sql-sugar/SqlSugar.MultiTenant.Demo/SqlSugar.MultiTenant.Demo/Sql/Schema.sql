use master
go

-- 创建数据库 TestTenantA
if db_id(N'TestTenantA') is not null
    drop database TestTenantA
go

create database TestTenantA collate Chinese_PRC_CI_AS
go

-- 创建测试表
use TestTenantA
go

if exists (select *
           from sys.tables
           where name = 'T_User')
    drop table T_User
go

create table T_User
(
    Id       bigint primary key identity (1,1),
    Nickname nvarchar(255) not null,
)
go

-- 创建数据库 TestTenantB
if db_id(N'TestTenantB') is not null
    drop database TestTenantB
go

create database TestTenantB collate Chinese_PRC_CI_AS
go

-- 创建测试表
use TestTenantB
go

if exists (select *
           from sys.tables
           where name = 'T_Book')
    drop table T_Book
go

create table T_Book
(
    Id     bigint primary key identity (1,1),
    Name   nvarchar(255) not null,
    Author nvarchar(255) not null,
)
go