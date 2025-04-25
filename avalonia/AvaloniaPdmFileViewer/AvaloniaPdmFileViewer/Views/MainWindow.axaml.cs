using Avalonia.Controls;

namespace AvaloniaPdmFileViewer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // private void Button_OnClicked(object? sender, RoutedEventArgs e)
    // {
    //     Debug.WriteLine($"BUtton Click! Celsius={Celsius.Text}");
    //     CelsiusToFahrenheit();
    // }
    //
    // private void Celsius_OnTextChanged(object? sender, TextChangedEventArgs e)
    // {
    //     Debug.WriteLine($"Celsius change to {Celsius.Text}");
    //     CelsiusToFahrenheit();
    // }
    //
    // private void CelsiusToFahrenheit()
    // {
    //     if (double.TryParse(Celsius.Text, out var c))
    //     {
    //         Fahrenheit.Text = (c * (9d / 5d) + 32).ToString("0.0");
    //         return;
    //     }
    //
    //     Celsius.Text = "0";
    //     Fahrenheit.Text = "0";
    // }
}