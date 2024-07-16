namespace SqlSugar.HelloWorld;

/// <summary>
/// SqlSugar Hello World
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // 创建数据库对象（每次都会 new 保证线程安全）
        var db = new SqlSugarClient(
            new ConnectionConfig
            {
                // 数据库连接字符串
                // Sql Server
                ConnectionString = "server=127.0.0.1,1433;uid=sa;pwd=Lxl1998!;database=SqlSugarTest",
                // 数据库类型
                DbType = DbType.SqlServer,
                // 是否自动关闭连接
                IsAutoCloseConnection = true,
            },
            db =>
            {
                db.Aop.OnLogExecuting = (sql, parameters) =>
                {
                    // 获取原生 SQL
                    Console.WriteLine(UtilMethods.GetNativeSql(sql, parameters));
                    // 获取无参数化 SQL，对性能有影响，调试的时候用
                    // Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer, sql, parameters));
                };
            }
        );
        // 建库，目前不支持达梦和 Oracle
        // db.DbMaintenance.CreateDatabase();
        // 建表
        // db.CodeFirst.InitTables<Student>();
        // 查询所有记录
        int? age = null;
        var students = db.Queryable<Student>()
            // 添加查询条件
            .Where(student => "bruce".Equals(student.Name))
            .WhereIF(age is not null, student => age.Equals(student.Age))
            .ToList();
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}