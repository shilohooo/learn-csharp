using Avalonia.TodoApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.TodoApp.ViewModels;

/// <summary>
///     To-do item view model
/// </summary>
public partial class TodoItemViewModel : ViewModelBase
{
    /// <summary>
    ///     Content of to-do item
    /// </summary>
    [ObservableProperty] private string? _content;

    /// <summary>
    ///     Check status
    /// </summary>
    [ObservableProperty] private bool _isChecked;

    /// <inheritdoc />
    public TodoItemViewModel(TodoItem todoItem)
    {
        IsChecked = todoItem.IsChecked;
        Content = todoItem.Content;
    }

    public TodoItem GetTodoItem()
    {
        return new TodoItem
        {
            Content = Content,
            IsChecked = IsChecked
        };
    }
}