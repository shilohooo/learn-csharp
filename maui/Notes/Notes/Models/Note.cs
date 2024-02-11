using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Maui.Storage;

namespace Notes.Models;

/// <summary>
/// 笔记数据模型
/// </summary>
public class Note
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public string FileName { get; set; } = $"{Path.GetRandomFileName()}.notes.txt";

    /// <summary>
    /// 笔记文本内容
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>
    /// 保存笔记内容到指定文件
    /// </summary>
    public void Save() =>
        File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, FileName), Text);

    /// <summary>
    /// 删除笔记
    /// </summary>
    public void Delete() =>
        File.Delete(Path.Combine(FileSystem.AppDataDirectory, FileName));

    /// <summary>
    /// 加载所有笔记
    /// </summary>
    /// <returns>笔记列表</returns>
    public static IEnumerable<Note> LoadNotes()
    {
        var appDataPath = FileSystem.AppDataDirectory;
        return Directory
            // 列出指定目录下匹配的文件名
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(fileName => LoadNote(Path.GetFileName(fileName)))
            .OrderByDescending(note => note.Date);
    }

    /// <summary>
    /// 根据文件名加载笔记
    /// </summary>
    /// <param name="fileName">文件名</param>
    public static Note LoadNote(string fileName)
    {
        fileName = Path.Combine(FileSystem.AppDataDirectory, fileName);
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("笔记文件不存在", fileName);
        }

        return new Note
        {
            FileName = fileName,
            Text = File.ReadAllText(fileName),
            // 获取文件的最后修改时间
            Date = File.GetLastWriteTime(fileName)
        };
    }
}