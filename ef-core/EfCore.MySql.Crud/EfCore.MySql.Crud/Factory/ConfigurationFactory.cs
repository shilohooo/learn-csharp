using Microsoft.Extensions.Configuration;

namespace EfCore.MySql.Crud.Factory;

/// <summary>
/// 配置工厂
/// </summary>
public static class ConfigurationFactory
{
    /// <summary>
    /// JSON 配置文件名称
    /// </summary>
    private const string ConfigFileName = "appsettings.json";

    /// <summary>
    /// 从JSON文件中构建配置对象
    /// </summary>
    /// <returns>配置对象</returns>
    public static IConfiguration BuildConfigFromJsonFile()
    {
        return new ConfigurationBuilder()
            .AddJsonFile(ConfigFileName, false, true)
            .Build();
    }
}