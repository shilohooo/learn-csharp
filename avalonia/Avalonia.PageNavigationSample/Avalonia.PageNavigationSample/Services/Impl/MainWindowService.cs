using Avalonia.Controls;
using Avalonia.PageNavigationSample.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.PageNavigationSample.Services.Impl;

/// <summary>
///     主窗口管理服务
/// </summary>
public class MainWindowService(Window window) : IMainWindowService
{
    /// <inheritdoc />
    public bool IsMaximized { get; private set; } = window.WindowState == WindowState.Maximized;

    /// <inheritdoc />
    public void Minimize()
    {
        window.WindowState = WindowState.Minimized;
    }

    /// <inheritdoc />
    public void Maximize()
    {
        window.WindowState = window.WindowState switch
        {
            WindowState.Normal => WindowState.Maximized,
            WindowState.Maximized => WindowState.Normal,
            _ => window.WindowState
        };

        IsMaximized = window.WindowState == WindowState.Maximized;

        // 发布窗口最大化状态改变消息
        WeakReferenceMessenger.Default.Send(new MainWindowStateChangedMessage(IsMaximized));
    }

    /// <inheritdoc />
    public void Close()
    {
        window.Close();
    }
}