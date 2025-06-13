using System.Linq;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.PageNavigationSample.ViewModels;
using Avalonia.PageNavigationSample.Views;

namespace Avalonia.PageNavigationSample;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        RegisterAllViews();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            var mainWindow = new MainWindow();
            var vm = new MainWindowViewModel(mainWindow);
            vm.CurrentMenu = vm.Menus[0];
            mainWindow.DataContext = vm;
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    /// <summary>
    ///     注册所有页面视图
    /// </summary>
    private static void RegisterAllViews()
    {
        ViewLocator.Register<MainWindowViewModel, MainWindow>();
        ViewLocator.Register<HomeViewModel, HomeView>();
        ViewLocator.Register<AboutViewModel, AboutView>();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove) BindingPlugins.DataValidators.Remove(plugin);
    }
}