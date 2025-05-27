namespace Avalonia.ViewInteraction.MvvmDialogSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    public CustomInteractionViewModel CustomInteractionViewModel { get; set; } = new();
}