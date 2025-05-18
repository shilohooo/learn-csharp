namespace Avalonia.Basic.Mvvm.Sample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public SimpleViewModel SimpleViewModel { get; } = new();
    public string Greeting { get; } = "Welcome to Avalonia!";
}