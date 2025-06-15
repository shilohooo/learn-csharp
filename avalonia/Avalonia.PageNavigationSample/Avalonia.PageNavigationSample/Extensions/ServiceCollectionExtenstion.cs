using Avalonia.PageNavigationSample.Services;
using Avalonia.PageNavigationSample.Services.Impl;
using Avalonia.PageNavigationSample.ViewModels;
using Avalonia.PageNavigationSample.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.PageNavigationSample.Extensions;

/// <summary>
///     依赖注入
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     注入主窗口
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddMainWindow(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MainWindow>();
    }

    /// <summary>
    ///     注入通用服务
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<INavigationService, DefaultNavigationService>();
        serviceCollection.AddSingleton<IThemeService, ThemeService>();
        serviceCollection.AddSingleton<IMainWindowService, MainWindowService>();
    }

    /// <summary>
    ///     注入 View Model
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViewModels(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<MainWindowViewModel>();
        serviceCollection.AddTransient<AppHeaderViewModel>();
        serviceCollection.AddTransient<MenuItemViewModel>();

        // page view model
        serviceCollection.AddTransient<HomeViewModel>();
        serviceCollection.AddTransient<AboutViewModel>();
    }
}