using System;
using System.Diagnostics;
using Avalonia.Controls;

namespace Avalonia.MusicStore.Views;

/// <summary>
///     音乐商店窗口
/// </summary>
public partial class MusicStoreWindow : Window
{
    public MusicStoreWindow()
    {
        InitializeComponent();
        Debug.WriteLine("打开了音乐商店窗口");
    }

    /// <inheritdoc />
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        Debug.WriteLine("关闭了音乐商店窗口");
    }
}