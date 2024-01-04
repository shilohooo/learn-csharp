using System.Windows;

namespace Style.Resource;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        // 设置应用启动之后要打开的窗口或者页面
        StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
    }
}