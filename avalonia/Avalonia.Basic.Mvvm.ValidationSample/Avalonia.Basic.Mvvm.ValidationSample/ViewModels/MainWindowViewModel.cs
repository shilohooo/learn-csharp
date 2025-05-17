namespace Avalonia.Basic.Mvvm.ValidationSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public ValidationUsingDataAnnotationViewModel ValidationUsingDataAnnotationViewModel { get; } = new();
}