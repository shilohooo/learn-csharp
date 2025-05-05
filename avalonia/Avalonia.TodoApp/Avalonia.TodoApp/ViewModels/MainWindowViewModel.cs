using System.Collections.ObjectModel;
using Avalonia.TodoApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.TodoApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    ///     Item to add
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    private string? _newItemContent;

    /// <summary>
    ///     To-do items
    /// </summary>
    public ObservableCollection<TodoItemViewModel> TodoItems { get; } = [];

    private bool CanAddItem()
    {
        return !string.IsNullOrWhiteSpace(NewItemContent);
    }

    /// <summary>
    ///     Add new to-do item
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        TodoItems.Add(new TodoItemViewModel(new TodoItem { Content = NewItemContent }));
        NewItemContent = null;
    }

    /// <summary>
    ///     Remove to-do item
    /// </summary>
    [RelayCommand]
    private void RemoveItem(TodoItemViewModel todoItem)
    {
        TodoItems.Remove(todoItem);
    }
}