using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.PageNavigationSample.Constants;
using Avalonia.PageNavigationSample.Models;
using Avalonia.PageNavigationSample.Services;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.PageNavigationSample.ViewModels;

/// <summary>
///     主窗口 vm
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService = new DefaultNavigationService();
    private readonly Window? _window;

    /// <summary>
    ///     当前选中的菜单项
    /// </summary>
    [ObservableProperty] private MenuItemViewModel? _currentMenu;

    /// <summary>
    ///     当前主题是否为暗色主题
    /// </summary>
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(SettingsButtonIcon))]
    private bool _isDarkMode = true;

    /// <summary>
    ///     当前是否全屏
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(MaximizeToggleButtonIcon))]
    [NotifyPropertyChangedFor(nameof(MainWindowPadding))]
    private bool _isMaximized;

    /// <summary>
    ///     侧边栏导航区域展开状态
    /// </summary>
    [ObservableProperty] private bool _isSidebarOpened = true;

    #region Constructors

    public MainWindowViewModel(Window? window)
    {
        _window = window;
        if (_window is null) return;

        IsMaximized = _window.WindowState == WindowState.Maximized;
        _window.PropertyChanged += (_, e) =>
        {
            if (e.Property.Name != nameof(Window.WindowState)) return;

            IsMaximized = _window.WindowState == WindowState.Maximized;
        };
        _navigationService.CurrentPageChanged += (_, _) => { OnPropertyChanged(nameof(CurrentPage)); };
        _navigationService.NavigateTo(typeof(HomeViewModel));
    }

    #endregion

    /// <summary>
    ///     主窗口内边距
    /// </summary>
    public Thickness MainWindowPadding => IsMaximized ? new Thickness(8) : new Thickness(0);

    /// <summary>
    ///     当前页面对应的视图模型
    /// </summary>
    public ViewModelBase? CurrentPage => _navigationService.CurrentPage;

    /// <summary>
    ///     系统设置图标名称
    /// </summary>
    public static IconName SettingsButtonIcon => IconName.SettingsRounded;

    /// <summary>
    ///     菜单折叠图标名称
    /// </summary>
    public static IconName SidebarToggleButtonIcon => IconName.MenuRounded;

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

    /// <summary>
    ///     菜单列表
    /// </summary>
    public ObservableCollection<MenuItemViewModel> Menus { get; } =
    [
        new(new MenuItemModel { Title = "主页", Icon = IconName.Home, ViewType = typeof(HomeViewModel) })
            { IsActive = true },
        new(new MenuItemModel { Title = "关于", Icon = IconName.InfoRounded, ViewType = typeof(AboutViewModel) })
    ];


    /// <summary>
    ///     动态切换主题
    /// </summary>
    /// <param name="value">当时是否为暗色主题</param>
    partial void OnIsDarkModeChanged(bool value)
    {
        if (Application.Current is null) return;

        Application.Current.RequestedThemeVariant = value ? ThemeVariant.Dark : ThemeVariant.Light;
    }

    #region Commands

    [RelayCommand]
    private void ToggleTheme(string value)
    {
        IsDarkMode = bool.Parse(value);
    }

    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarOpened = !IsSidebarOpened;
    }


    [RelayCommand]
    private void Navigate(MenuItemViewModel? clickMenu)
    {
        if (clickMenu is null || clickMenu.IsActive) return;

        clickMenu.IsActive = true;
        CurrentMenu = clickMenu;

        foreach (var menuItemViewModel in Menus)
        {
            if (menuItemViewModel == clickMenu) continue;

            menuItemViewModel.IsActive = false;
        }


        _navigationService.NavigateTo(clickMenu.ViewType);
    }

    [RelayCommand]
    private void Minimize()
    {
        if (_window is null) return;

        _window.WindowState = WindowState.Minimized;
    }

    [RelayCommand]
    private void Maximize()
    {
        if (_window is null) return;

        _window.WindowState = _window.WindowState switch
        {
            WindowState.Normal => WindowState.Maximized,
            WindowState.Maximized => WindowState.Normal,
            _ => _window.WindowState
        };
    }

    [RelayCommand]
    private void Exit()
    {
        _window?.Close();
    }

    #endregion
}