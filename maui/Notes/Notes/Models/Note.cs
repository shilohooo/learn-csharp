namespace Notes.Models;

/// <summary>
/// 笔记数据模型
/// </summary>
internal class Note
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// 笔记文本内容
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime Date { get; set; }
}