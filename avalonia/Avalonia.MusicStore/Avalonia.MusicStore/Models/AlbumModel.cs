using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using iTunesSearch.Library;

namespace Avalonia.MusicStore.Models;

/// <summary>
///     音乐专辑 Model
/// </summary>
public class AlbumModel(string artist, string title, string coverUrl)
{
    private const string CacheDir = "./Cache";
    private static readonly iTunesSearchManager TunesSearchManager = new();
    private static readonly HttpClient HttpClient = new();
    private string CachePath => $"{CacheDir}/{Artist}-{Title}";

    /// <summary>
    ///     艺术家名称
    /// </summary>
    public string Artist { get; set; } = artist;

    /// <summary>
    ///     音乐标题
    /// </summary>
    public string Title { get; set; } = title;

    /// <summary>
    ///     音乐封面图片地址
    /// </summary>
    public string CoverUrl { get; set; } = coverUrl;

    /// <summary>
    ///     搜索 iTunes 音乐专辑列表
    /// </summary>
    /// <param name="searchTerm">搜索内容</param>
    /// <returns>音乐专辑列表</returns>
    public static async Task<IEnumerable<AlbumModel>> SearchAsync(string searchTerm)
    {
        var query = await TunesSearchManager.GetAlbumsAsync(searchTerm)
            .ConfigureAwait(false);
        return query.Albums.Select(album => new AlbumModel(album.ArtistName, album.CollectionName,
            album.ArtworkUrl100.Replace("100x100bb", "600x600bb")));
    }

    /// <summary>
    ///     下载音乐封面图片
    /// </summary>
    /// <returns>图片流</returns>
    public async Task<Stream> LoadCoverBitmapAsync()
    {
        var cachedImgPath = $"{CachePath}.bmp";
        if (File.Exists(cachedImgPath)) return File.OpenRead(cachedImgPath);

        var coverImgBytes = await HttpClient.GetByteArrayAsync(CoverUrl);
        return new MemoryStream(coverImgBytes);
    }

    /// <summary>
    ///     数据持久化
    /// </summary>
    public async Task SaveAsync()
    {
        if (!Directory.Exists(CacheDir)) Directory.CreateDirectory(CacheDir);

        await using var fs = File.OpenWrite($"{CachePath}.json");
        await SaveToStreamAsync(this, fs);
    }

    /// <summary>
    ///     保存音乐专辑封面图片
    /// </summary>
    /// <returns>图片流</returns>
    public Stream SaveCoverBitmapStream()
    {
        return File.OpenWrite($"{CachePath}.bmp");
    }

    /// <summary>
    ///     加载音乐专辑数据
    /// </summary>
    /// <param name="stream">数据流</param>
    /// <returns>音乐专辑对象</returns>
    public static async Task<AlbumModel> LoadFromStream(Stream stream)
    {
        return (await JsonSerializer.DeserializeAsync<AlbumModel>(stream).ConfigureAwait(false))!;
    }

    /// <summary>
    ///     从缓存中加载音乐专辑列表
    /// </summary>
    /// <returns>音乐专辑列表</returns>
    public static async Task<IEnumerable<AlbumModel>> LoadCachedAsync()
    {
        if (!Directory.Exists(CacheDir)) Directory.CreateDirectory(CacheDir);

        var results = new List<AlbumModel>();

        foreach (var file in Directory.EnumerateFiles(CacheDir))
            try
            {
                var fileInfo = new DirectoryInfo(file);
                if (!fileInfo.Extension.Equals(".json")) continue;

                await using var fs = File.OpenRead(file);
                var albumModel = await LoadFromStream(fs).ConfigureAwait(false);
                Debug.WriteLine($"purchased album: {albumModel}");
                results.Add(albumModel);
            }
            catch (Exception e)
            {
                Console.WriteLine($"从文件 {file} 中加载音乐专辑数据报错, {e}");
            }

        return results;
    }

    /// <summary>
    ///     将音乐专辑数据保存为 JSON 文件
    /// </summary>
    /// <param name="data">音乐专辑数据</param>
    /// <param name="stream">流</param>
    private static async Task SaveToStreamAsync(AlbumModel data, Stream stream)
    {
        await JsonSerializer.SerializeAsync(stream, data).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Artist} - {Title} - {CoverUrl}";
    }
}