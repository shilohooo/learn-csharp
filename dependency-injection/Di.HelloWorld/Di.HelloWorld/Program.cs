using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Di.HelloWorld;

/// <summary>
/// 依赖注入示例
/// </summary>
internal class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        // 注册托管服务
        builder.Services.AddHostedService<Worker>();
        // 注册单例服务，指定要注册的服务接口与对应的实现类
        // 可以更改为其他实现类，而无需修改 Worker 类的代码
        builder.Services.AddSingleton<IMessageWriter, LoggingMessageWriter>();

        using var host = builder.Build();
        host.Run();
    }
}