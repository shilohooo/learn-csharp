using Microsoft.EntityFrameworkCore;

namespace RawSQLQueries;

/// <summary>
/// 数据上下文
/// </summary>
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=RawSQLQueriesDemo;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }
}