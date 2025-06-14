using Avalonia.Controls;
using Avalonia.PageNavigationSample.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.PageNavigationSample.Services;

/// <summary>
///     主窗口管理服务
/// </summary>
public class MainWindowService(Window window)
{
    /// <summary>
    ///     主窗口是否最大化
    /// </summary>
    public bool IsMaximized { get; set; } = window.WindowState == WindowState.Maximized;

    /// <summary>
    ///     最小化主窗口
    /// </summary>
    public void Minimize()
    {
        window.WindowState = WindowState.Minimized;
    }

    /// <summary>
    ///     主窗口放大/缩小
    /// </summary>
    public void Maximize()
    {
        window.WindowState = window.WindowState switch
        {
            WindowState.Normal => WindowState.Maximized,
            WindowState.Maximized => WindowState.Normal,
            _ => window.WindowState
        };

        IsMaximized = window.WindowState == WindowState.Maximized;

        WeakReferenceMessenger.Default.Send(new MainWindowStateChangedMessage(IsMaximized));
    }

    /// <summary>
    ///     关闭主窗口
    /// </summary>
    public void Close()
    {
        window.Close();
    }
}