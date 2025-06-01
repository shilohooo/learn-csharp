using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.MusicStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.MusicStore.ViewModels;

/// <summary>
///     专辑
/// </summary>
public partial class AlbumViewModel : ViewModelBase
{
    private readonly AlbumModel _albumModel;

    /// <summary>
    ///     在 avalonia 中显示图像，可以使用 <see cref="Bitmap" />
    /// </summary>
    [ObservableProperty] private Bitmap? _cover;

    /// <inheritdoc />
    public AlbumViewModel(AlbumModel albumModel)
    {
        _albumModel = albumModel;
    }

    /// <inheritdoc />
    public AlbumViewModel()
    {
        _albumModel = new AlbumModel("Default Artist", "Default Title", "");
    }

    public string Artist => _albumModel.Artist;

    public string Title => _albumModel.Title;

    /// <summary>
    ///     加载音乐封面图片
    /// </summary>
    public async Task LoadCover()
    {
        await using var imgStream = await _albumModel.LoadCoverBitmapAsync();
        // 把图片转为较小的位图，并保持宽高比
        Cover = await Task.Run(() => Bitmap.DecodeToWidth(imgStream, 400));
    }

    /// <summary>
    ///     将音乐专辑数据保存到磁盘文件
    /// </summary>
    public async Task SaveToDiskAsync()
    {
        await _albumModel.SaveAsync();
        if (Cover is null) return;

        var bitmap = Cover;
        await Task.Run(() =>
        {
            using var fs = _albumModel.SaveCoverBitmapStream();
            bitmap.Save(fs);
        });
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Artist} - {Title}";
    }
}