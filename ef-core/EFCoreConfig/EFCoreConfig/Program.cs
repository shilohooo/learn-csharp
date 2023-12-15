using Microsoft.Extensions.Configuration;

namespace EFCoreConfig;

/// <summary>
/// c# ef core 配置示例
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        using var context = new ConfigTestContext(GetAppConfig());
        // 创建数据库
        context.Database.EnsureCreated();
    }

    /// <summary>
    /// 获取应用配置信息
    /// </summary>
    /// <returns>配置对象</returns>
    private static IConfiguration GetAppConfig()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", true, true)
            .Build();
    }
}