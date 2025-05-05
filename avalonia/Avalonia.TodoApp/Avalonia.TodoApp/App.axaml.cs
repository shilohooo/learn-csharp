using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.TodoApp.Services;
using Avalonia.TodoApp.ViewModels;
using Avalonia.TodoApp.Views;

namespace Avalonia.TodoApp;

public class App : Application
{
    private readonly MainWindowViewModel _mainWindowViewModel = new();
    private bool _canClose;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _mainWindowViewModel
            };

            await InitMainViewModelAsync();
            desktop.ShutdownRequested += DesktopOnShutdownRequested;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async Task InitMainViewModelAsync()
    {
        var todoItems = (await TodoListFileService.LoadFromFileAsync())!.ToList();
        if (todoItems.Count == 0) return;

        foreach (var todoItem in todoItems) _mainWindowViewModel.TodoItems.Add(new TodoItemViewModel(todoItem));
    }

    private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        e.Cancel = !_canClose;

        if (_canClose) return;

        var todoItems = _mainWindowViewModel.TodoItems.Select(item => item.GetTodoItem());
        await TodoListFileService.SaveToFileAsync(todoItems);

        _canClose = true;

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) desktop.Shutdown();
    }
}