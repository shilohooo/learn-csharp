using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuItem = Avalonia.PageNavigationSample.Models.MenuItem;

namespace Avalonia.PageNavigationSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    ///     当前选中的菜单项
    /// </summary>
    [ObservableProperty] private MenuItem? _currentMenu;

    /// <summary>
    ///     当前页面对应的视图模型
    /// </summary>
    [ObservableProperty] private ViewModelBase? _currentViewModel;

    /// <summary>
    ///     菜单列表
    /// </summary>
    public ObservableCollection<MenuItem> Menus { get; } =
    [
        new() { Title = "主页", ViewType = typeof(HomeViewModel) },
        new() { Title = "关于", ViewType = typeof(AboutViewModel) }
    ];

    partial void OnCurrentMenuChanged(MenuItem? value)
    {
        if (value?.ViewType is null) return;

        CurrentViewModel = value.Title switch
        {
            "主页" => new HomeViewModel(),
            "关于" => new AboutViewModel(),
            _ => new HomeViewModel()
        };
    }

    [RelayCommand]
    private void Navigate(MenuItem? menu)
    {
        CurrentMenu = menu;
    }
}