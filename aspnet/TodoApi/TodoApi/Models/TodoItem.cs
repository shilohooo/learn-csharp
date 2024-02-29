namespace TodoApi.Models;

/// <summary>
/// 实体
/// </summary>
public class TodoItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}