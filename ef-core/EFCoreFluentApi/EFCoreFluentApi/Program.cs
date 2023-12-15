namespace EFCoreFluentApi;

/// <summary>
/// C# EF Core 使用 Fluent API 进行相关配置
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        using var ctx = new FluentApiConfigContext();
        ctx.Database.EnsureCreated();
    }
}