namespace WebApi.JwtAuth.Models;

/// <summary>
/// Book Model
/// </summary>
public class BookModel
{
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 图书名称
    /// </summary>
    public string BookName { get; set; }

    /// <summary>
    /// 作者
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// 出版社
    /// </summary>
    public string Publisher { get; set; }

    /// <summary>
    /// 出版日期
    /// </summary>
    public DateOnly PublishDate { get; set; }

    public override string ToString()
    {
        return
            $"Book: [Id: {Id}, BookName: {BookName}, Author: {Author}, Publisher: {Publisher}, PublishDate: {PublishDate}]";
    }
}