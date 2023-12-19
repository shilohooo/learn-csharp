using System.Windows;

namespace WPFHelloWorld;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DisplayLifecycle();

        ChangeBtnTextAfter3Seconds();
    }

    /// <summary>
    /// 组件生命周期测试
    /// </summary>
    private void DisplayLifecycle()
    {
        // 组件已初始化：创建窗体源时触发此事件
        SourceInitialized += (_, _) => Console.WriteLine("1.MainWindow的SourceInitialized被执行");

        // 组件已激活：当前窗体成为前台窗体时触发此事件
        Activated += (_, _) => Console.WriteLine("1.MainWindow的Activated被执行");

        // 组件已加载：当前窗体内部所有元素完成布局和呈现时触发此事件
        Loaded += (_, _) => Console.WriteLine("1.MainWindow的Loaded被执行");

        // 组件内容已渲染：当前窗体的内容呈现之后触发此事件
        ContentRendered += (_, _) => Console.WriteLine("1.MainWindow的ContentRendered被执行");

        // 组件已由激活变为非激活：当前窗体关闭之前触发此事件
        Deactivated += (_, _) => Console.WriteLine("1.MainWindow的Deactivated被执行");

        // 组件正在关闭：当前窗体成为后台窗体时触发此事件
        Closing += (_, _) => Console.WriteLine("1.MainWindow的Closing被执行");

        // 组件已关闭：当前窗体关闭之后触发此事件
        Closed += (_, _) => Console.WriteLine("1.MainWindow的Closed被执行");

        // 组件已卸载：当前窗体从元素树中删除时触发此事件
        Unloaded += (_, _) => Console.WriteLine("1.MainWindow的Unloaded被执行");
    }

    /// <summary>
    /// 延迟3秒后修改按钮文案
    /// </summary>
    private void ChangeBtnTextAfter3Seconds()
    {
        // 创建子线程（后台线程）
        Task.Factory.StartNew(() =>
        {
            Task.Delay(3000).Wait();
            // 调用指定函数，修改按钮的 Content 属性
            Button.Dispatcher.Invoke(() => { Button.Content = "按钮文案变啦~"; });
        });
    }
}