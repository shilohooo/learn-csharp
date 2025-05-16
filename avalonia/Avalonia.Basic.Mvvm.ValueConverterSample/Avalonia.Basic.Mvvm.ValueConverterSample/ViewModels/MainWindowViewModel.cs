using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Basic.Mvvm.ValueConverterSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private decimal? _number1 = 2;

    [ObservableProperty] private decimal? _number2 = 3;

    [ObservableProperty] private string? _operator = "+";

    public string Greeting { get; } = "Welcome to Avalonia!";

    public List<string> Operators { get; } = ["+", "-", "*", "/"];
}