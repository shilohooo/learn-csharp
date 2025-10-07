if db_id('DapperTest') is null
    begin
        create database DapperTest collate Chinese_PRC_CI_AS;
    end
go

if object_id('T_User', 'U') is null
    begin
        create table T_User
        (
            Id       bigint identity
                constraint PK_T_User
                    primary key,
            Name     nvarchar(50) not null,
            Age      int,
            Birthday datetime
        );
    end
go