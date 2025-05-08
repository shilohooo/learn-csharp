namespace Avalonia.Basic.Mvvm.CommandSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    public CommandsViewModel CommandsViewModel { get; } = new();
}