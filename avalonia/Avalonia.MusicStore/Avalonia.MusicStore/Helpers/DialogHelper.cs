using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.MusicStore.Services;
using Avalonia.MusicStore.ViewModels;
using Avalonia.MusicStore.Views;

namespace Avalonia.MusicStore.Helpers;

/// <summary>
///     Dialog 工具类
/// </summary>
public static class DialogHelper
{
    /// <summary>
    ///     以对话框的形式打开音乐商店窗口
    /// </summary>
    /// <param name="context">对话框所属窗口</param>
    public static async Task<AlbumViewModel?> OpenMusicStoreDialog(this object? context)
    {
        ArgumentNullException.ThrowIfNull(context);


        var visual = DialogManager.GetVisualForContext(context);
        Debug.WriteLine($"OpenMusicStoreDialog, {visual}");
        if (visual is not Window owner) return new AlbumViewModel();

        var vm = new MusicStoreViewModel();
        var musicStoreWindow = new MusicStoreWindow
        {
            DataContext = vm
        };
        var tsc = new TaskCompletionSource<AlbumViewModel?>();
        vm.ClosedCallback += albumViewModel =>
        {
            tsc.SetResult(albumViewModel);
            musicStoreWindow.Close();
        };

        await musicStoreWindow.ShowDialog<AlbumViewModel>(owner);

        return await tsc.Task;
    }
}