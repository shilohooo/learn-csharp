using System;
using Avalonia.PageNavigationSample.Constants;

namespace Avalonia.PageNavigationSample.Models;

/// <summary>
///     菜单项
/// </summary>
public class MenuItem
{
    /// <summary>
    ///     菜单标题
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     菜单图标
    /// </summary>
    public IconName Icon { get; set; }

    /// <summary>
    ///     菜单对应的页面类型
    /// </summary>
    public Type? ViewType { get; set; }
}