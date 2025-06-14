using Avalonia.PageNavigationSample.Messages;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.PageNavigationSample.Services;

/// <summary>
///     主题管理服务
/// </summary>
public class ThemeService
{
    /// <summary>
    ///     当前主题是否为深色主题
    /// </summary>
    public bool IsDarkMode { get; private set; } = true;

    /// <summary>
    ///     切换主题
    /// </summary>
    public void ToggleTheme()
    {
        IsDarkMode = !IsDarkMode;
        WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(IsDarkMode));
        if (Application.Current is null) return;

        Application.Current.RequestedThemeVariant = IsDarkMode ? ThemeVariant.Dark : ThemeVariant.Light;
    }
}