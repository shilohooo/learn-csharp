using System.Configuration;
using System.Data;
using System.Windows;
using ShowMeTheXAML;

namespace Wpf.MaterialDesign.Demo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        XamlDisplay.Init();
        base.OnStartup(e);
    }
}