﻿using Avalonia.PageNavigationSample.Messages;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.PageNavigationSample.Services.Impl;

/// <summary>
///     主题管理服务
/// </summary>
public class ThemeService : IThemeService
{
    /// <inheritdoc />
    public bool IsDarkMode { get; private set; } = true;

    /// <inheritdoc />
    public void ToggleTheme(bool isDarkMode)
    {
        IsDarkMode = isDarkMode;
        WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(IsDarkMode));
        if (Application.Current is null) return;

        Application.Current.RequestedThemeVariant = IsDarkMode ? ThemeVariant.Dark : ThemeVariant.Light;
        WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(IsDarkMode));
    }
}