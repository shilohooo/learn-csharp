-- 插入测试数据
use TestTenantA
go

insert into T_User(Nickname)
values (N'张三'),
       (N'李四'),
       (N'王五')
go

use TestTenantB
go

insert into T_Book(Name, Author)
values (N'BookName1', N'张三'),
       (N'BookName2', N'李四'),
       (N'BookName3', N'王五')
go