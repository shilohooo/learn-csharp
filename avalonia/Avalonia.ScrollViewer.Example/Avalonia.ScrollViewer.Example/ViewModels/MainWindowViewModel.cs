using System.Collections.Generic;

namespace Avalonia.ScrollViewer.Example.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    public List<string> Activities { get; } = new()
    {
        "Sleeping",
        "Eating",
        "Working",
        "Communicating",
        "Having Fun",
        "Studying",
        "Exercising",
        "Cooking",
        "Shopping",
        "Watching TV",
        "Playing Games",
        "Reading",
        "Learning",
    };
}