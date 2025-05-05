namespace Avalonia.TodoApp.Models;

/// <summary>
///     TodoItem Model
/// </summary>
public class TodoItem
{
    /// <summary>
    ///     Item check status
    /// </summary>
    public bool IsChecked { get; set; }

    /// <summary>
    ///     Content of to-do item
    /// </summary>
    public string? Content { get; set; }
}