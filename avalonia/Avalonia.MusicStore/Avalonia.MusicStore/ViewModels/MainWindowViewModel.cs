using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.MusicStore.Helpers;
using Avalonia.MusicStore.Models;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.MusicStore.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    #region Observable Properties

    public ObservableCollection<AlbumViewModel> Albums { get; } = [];

    #endregion

    #region Commands

    /// <summary>
    ///     打开音乐商店窗口
    /// </summary>
    [RelayCommand]
    private async Task BuyMusic()
    {
        Debug.WriteLine("按钮点击事件触发");
        var albumViewModel = await this.OpenMusicStoreDialog();
        if (albumViewModel is null) return;

        Albums.Add(albumViewModel);
        Debug.WriteLine($"购买了 {Albums.Count} 个音乐专辑");
        await albumViewModel.SaveToDiskAsync();
    }

    #endregion

    /// <summary>
    ///     加载已购买的音乐专辑列表
    /// </summary>
    public async Task LoadAlbums()
    {
        var albumViewModels = await Task.Run(async () =>
        {
            return (await AlbumModel.LoadCachedAsync())
                .Select(item => new AlbumViewModel(item));
        });
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            foreach (var albumViewModel in albumViewModels) Albums.Add(albumViewModel);
            Debug.WriteLine($"Load Albums {Albums.Count}");
        });
        await Task.Run(async () =>
        {
            foreach (var albumViewModel in Albums.ToList()) await albumViewModel.LoadCover();
        });
    }
}