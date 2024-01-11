using System.Windows.Input;

namespace Wpf.Command.EventToCommand.Command;

public class RelayCommand<T>(Action<T?> action) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action.Invoke((T?)parameter);
    }

    public event EventHandler? CanExecuteChanged;
}