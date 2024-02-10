using System.Collections.ObjectModel;

namespace Notes.Models;

/// <summary>
/// 模型类：所有笔记
/// </summary>
internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = [];

    public AllNotes() => LoadNotes();

    /// <summary>
    /// 加载所有笔记
    /// </summary>
    public void LoadNotes()
    {
        Notes.Clear();

        // 获取笔记保存的目录
        string appDataPath = FileSystem.AppDataDirectory;

        // 使用 Linq 获取所有笔记文件：*.notes.txt
        var notes = Directory
            .EnumerateFiles(appDataPath)
            .Select(fileName => new Note()
            {
                FileName = fileName,
                Text = File.ReadAllText(fileName),
                Date = File.GetCreationTime(fileName)
            })
            .OrderBy(note => note.Date);

        // 将笔记文件添加到列表
        foreach (var item in notes)
        {
            Notes.Add(item);
        }
    }
}