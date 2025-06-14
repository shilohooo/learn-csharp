using Avalonia.PageNavigationSample.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.PageNavigationSample.Extensions;

/// <summary>
///     依赖注入
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     注入通用服务
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<INavigationService, DefaultNavigationService>();
        serviceCollection.AddSingleton<ThemeService>();
        serviceCollection.AddSingleton<MainWindowService>();

        return serviceCollection;
    }
}