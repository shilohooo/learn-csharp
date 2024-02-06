using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Di.HelloWorld;

/// <summary>
/// 依赖注入示例，Host 会自动实例化该类
/// </summary>
/// <param name="logger">将通过构造函数自动注入的依赖项，该依赖项的实例由 DI 容器创建</param>
public class Worker(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {Time}", DateTime.Now);
            await Task.Delay(1_000, stoppingToken);
        }
    }
}