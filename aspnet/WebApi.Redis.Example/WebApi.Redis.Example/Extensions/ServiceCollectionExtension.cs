using WebApi.Redis.Example.Repository;
using WebApi.Redis.Example.Services;

namespace WebApi.Redis.Example.Extensions;

/// <summary>
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    ///     Add repositories to container
    /// </summary>
    /// <param name="service"></param>
    public static void AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IRedisRepository, RedisRepository>();
    }

    /// <summary>
    ///     Add services to container
    /// </summary>
    /// <param name="service"></param>
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<IRedisService, RedisService>();
    }
}