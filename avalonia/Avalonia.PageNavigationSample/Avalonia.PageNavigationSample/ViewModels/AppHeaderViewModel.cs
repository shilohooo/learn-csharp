using System;
using Avalonia.PageNavigationSample.Constants;
using Avalonia.PageNavigationSample.Messages;
using Avalonia.PageNavigationSample.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.PageNavigationSample.ViewModels;

/// <summary>
///     顶部控件的 view model
/// </summary>
public partial class AppHeaderViewModel : ViewModelBase, IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>
{
    private readonly Lazy<IMainWindowService> _mainWindowService;

    [ObservableProperty] private bool _isDarkMode = true;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MaximizeToggleButtonIcon))]
    private bool _isMaximized;

    public AppHeaderViewModel(Lazy<IMainWindowService> mainWindowService)
    {
        _mainWindowService = mainWindowService;
        IsMaximized = _mainWindowService.Value.IsMaximized;
        WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this);
        WeakReferenceMessenger.Default.Register<MainWindowStateChangedMessage>(this);
    }

    /// <summary>
    ///     应用图标名称
    /// </summary>
    public static IconName AppIcon => IconName.ComputerRounded;

    /// <summary>
    ///     窗口最小化按钮图标名称
    /// </summary>
    public static IconName MinimizeButtonIcon => IconName.HorizontalRuleRounded;

    /// <summary>
    ///     窗口最大化切换图标名称
    /// </summary>
    public IconName MaximizeToggleButtonIcon =>
        IsMaximized ? IconName.FullscreenExitRounded : IconName.FullscreenRounded;

    /// <summary>
    ///     退出按钮图标名称
    /// </summary>
    public static IconName ExitButtonIcon => IconName.CloseRounded;

    public void Receive(MainWindowStateChangedMessage message)
    {
        IsMaximized = message.Value;
    }

    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    #region Commands

    [RelayCommand]
    private void Minimize()
    {
        _mainWindowService.Value.Minimize();
    }

    [RelayCommand]
    private void Maximize()
    {
        _mainWindowService.Value.Maximize();
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService.Value.Close();
    }

    #endregion
}