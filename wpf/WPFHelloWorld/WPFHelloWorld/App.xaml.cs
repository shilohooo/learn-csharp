using System.Windows;

namespace WPFHelloWorld;

/// <summary>
/// 在此处编写 App.xaml 的交互逻辑
/// </summary>
public partial class App : Application
{
    // 重写应用程序生命周期相关方法
    
    /// <summary>
    /// 应用激活时触发
    /// </summary>
    /// <param name="e"></param>
    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        Console.WriteLine("2.OnActivated被触发");
    }

    /// <summary>
    /// 应用由激活变为非激活状态时触发
    /// </summary>
    /// <param name="e"></param>
    protected override void OnDeactivated(EventArgs e)
    {
        base.OnDeactivated(e);
        Console.WriteLine("3.OnDeactivated被触发");
    }

    /// <summary>
    /// 应用退出时触发
    /// </summary>
    /// <param name="e"></param>
    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        Console.WriteLine("4.OnExit被触发");
    }

    /// <summary>
    /// 应用启动时触发
    /// </summary>
    /// <param name="e"></param>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Console.WriteLine("1.OnStartup被触发");
    }
}