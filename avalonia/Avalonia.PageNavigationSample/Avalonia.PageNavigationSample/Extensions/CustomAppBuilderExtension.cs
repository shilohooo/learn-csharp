using Microsoft.Extensions.Hosting;

namespace Avalonia.PageNavigationSample.Extensions;

/// <summary>
/// </summary>
public static class CustomAppBuilderExtension
{
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaAppWithDi()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddMainWindow();
                services.AddServices();
                services.AddViewModels();
            })
            .Build();
        ServiceLocator.Host = host;

        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}