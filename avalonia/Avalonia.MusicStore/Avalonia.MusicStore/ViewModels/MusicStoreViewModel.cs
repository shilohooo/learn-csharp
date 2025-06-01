using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.MusicStore.Models;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.MusicStore.ViewModels;

/// <summary>
///     vm of <see cref="MusicStoreViewModel" />
/// </summary>
public sealed partial class MusicStoreViewModel : ViewModelBase, IDisposable
{
    private CancellationTokenSource? _cancellationTokenSource;

    /// <inheritdoc />
    public MusicStoreViewModel()
    {
    }

    #region Public Properties

    /// <summary>
    ///     专辑列表搜索结果
    /// </summary>
    public ObservableCollection<AlbumViewModel> SearchResults { get; } = [];

    #endregion

    #region Events

    /// <summary>
    ///     窗口关闭回调事件
    /// </summary>
    public Action<AlbumViewModel?>? ClosedCallback { get; set; }

    #endregion

    /// <inheritdoc />
    public void Dispose()
    {
        _cancellationTokenSource?.Dispose();
    }

    partial void OnSearchTextChanged(string? value)
    {
        _ = DoSearch(value);
    }

    partial void OnSelectedAlbumChanged(AlbumViewModel? value)
    {
        Debug.WriteLine($"当前选择的专辑是：{value}");
    }

    #region Commands

    private bool CanBuyMusic => SelectedAlbum is not null;

    /// <summary>
    ///     购买音乐专辑
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanBuyMusic))]
    private void BuyMusic()
    {
        Debug.WriteLine($"当前想要购买的专辑是：{SelectedAlbum}");
        ClosedCallback?.Invoke(SelectedAlbum);
    }

    #endregion

    #region Private Methods

    /// <summary>
    ///     根据搜索内容搜索音乐专辑列表
    /// </summary>
    /// <param name="searchText">搜索内容</param>
    private async Task DoSearch(string? searchText)
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;

        IsBusy = true;
        SearchResults.Clear();

        if (string.IsNullOrWhiteSpace(searchText)) return;

        // 通过后台线程执行搜索，避免阻塞UI线程
        var albums = await Task.Run(async () => await AlbumModel.SearchAsync(searchText));
        // 切换到UI线程进行UI更新
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            foreach (var album in albums) SearchResults.Add(new AlbumViewModel(album));
        });

        if (!cancellationToken.IsCancellationRequested) await LoadCovers(cancellationToken);
        IsBusy = false;
    }

    /// <summary>
    ///     异步加载所有音乐专辑的封面图片，可以取消
    /// </summary>
    /// <param name="cancellationToken"></param>
    private async Task LoadCovers(CancellationToken cancellationToken)
    {
        foreach (var albumViewModel in SearchResults.ToList())
        {
            await albumViewModel.LoadCover();
            if (cancellationToken.IsCancellationRequested) return;
        }
    }

    #endregion

    #region Observable Properties

    /// <summary>
    ///     是否正在搜索中
    /// </summary>
    [ObservableProperty] private bool _isBusy;

    /// <summary>
    ///     搜索内容
    /// </summary>
    [ObservableProperty] private string? _searchText;

    /// <summary>
    ///     当前选择的专辑
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(BuyMusicCommand))]
    private AlbumViewModel? _selectedAlbum;

    #endregion
}