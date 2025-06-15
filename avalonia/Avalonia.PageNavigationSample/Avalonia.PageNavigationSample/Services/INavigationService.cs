using System;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample.Services;

/// <summary>
///     导航服务
/// </summary>
public interface INavigationService
{
    /// <summary>
    ///     当前页面的视图模型
    /// </summary>
    ViewModelBase? CurrentPage { get; }

    /// <summary>
    ///     导航到指定页面
    /// </summary>
    /// <param name="vmType">页面视图模型类型</param>
    void NavigateTo(Type vmType);
}