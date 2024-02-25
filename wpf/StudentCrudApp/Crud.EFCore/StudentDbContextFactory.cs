using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Crud.EFCore;

/// <summary>
/// 学生数据上下文工厂
/// </summary>
public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    /// <summary>
    /// 创建数据上下文对象
    /// </summary>
    /// <param name="args">参数</param>
    /// <returns></returns>
    public StudentDbContext CreateDbContext(string[]? args = null)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
        // TrustServerCertificate=true 强制客户端在不验证的情况下信任证书
        optionsBuilder.UseSqlServer(
            @"Server=.; Database=StudentCrudApp; Trusted_Connection=True; TrustServerCertificate=true");
        return new StudentDbContext(optionsBuilder.Options);
    }
}