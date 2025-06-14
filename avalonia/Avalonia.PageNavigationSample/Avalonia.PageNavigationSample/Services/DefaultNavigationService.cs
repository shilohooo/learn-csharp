using System;
using System.Collections.Immutable;
using System.Diagnostics;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample.Services;

/// <summary>
///     导航服务的默认实现
/// </summary>
public class DefaultNavigationService : INavigationService
{
    private static readonly ImmutableDictionary<Type, Func<ViewModelBase>> ViewModelFactories = ImmutableDictionary
        .Create<Type, Func<ViewModelBase>>()
        .Add(typeof(HomeViewModel), () => new HomeViewModel())
        .Add(typeof(AboutViewModel), () => new AboutViewModel());

    private ViewModelBase? _currentPage;

    /// <inheritdoc />
    public ViewModelBase? CurrentPage
    {
        get => _currentPage;
        set
        {
            if (_currentPage == value) return;

            _currentPage = value;
            CurrentPageChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <inheritdoc />
    public event EventHandler? CurrentPageChanged;

    /// <inheritdoc />
    public void NavigateTo(Type vmType)
    {
        if (!typeof(ViewModelBase).IsAssignableFrom(vmType))
        {
            Debug.WriteLine($"页面导航出错：{vmType} 不是 {nameof(ViewModelBase)} 类型");
            return;
        }

        CurrentPage = ViewModelFactories[vmType].Invoke();
    }
}