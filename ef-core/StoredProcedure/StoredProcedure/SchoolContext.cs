using Microsoft.EntityFrameworkCore;

namespace StoredProcedure;

/// <summary>
/// 数据上下文
/// </summary>
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=StoredProcedureDemo;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connStr);
    }
}