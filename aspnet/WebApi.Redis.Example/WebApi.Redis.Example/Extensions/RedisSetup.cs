using Microsoft.Extensions.Logging.Console;
using StackExchange.Redis;
using WebApi.Redis.Example.Extensions.Logging;

namespace WebApi.Redis.Example.Extensions;

/// <summary>
///     StackExchange.Redis Setup
/// </summary>
public static class RedisSetup
{
    /// <summary>
    ///     Add redis connection to container
    /// </summary>
    /// <param name="service"></param>
    /// <param name="configuration"></param>
    public static void AddRedis(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddSingleton<IConnectionMultiplexer>(_ =>
            ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]!,
                options =>
                {
                    options.LoggerFactory = LoggerFactory.Create(builder =>
                    {
                        builder.AddConsole(loggerOptions =>
                                loggerOptions.FormatterName = CustomConsoleLoggingFormatter.FormatterName)
                            .AddConsoleFormatter<CustomConsoleLoggingFormatter, ConsoleFormatterOptions>();
                    });
                }));
    }
}