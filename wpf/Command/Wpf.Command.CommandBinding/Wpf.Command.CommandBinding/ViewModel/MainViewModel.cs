using System.Windows;
using Wpf.Command.CommandBinding.Command;

namespace Wpf.Command.CommandBinding.ViewModel;

/// <summary>
/// 主窗体视图模型
/// </summary>
public class MainViewModel
{
    /// <summary>
    /// 命令属性
    /// </summary>
    public RelayCommand<object> RelayCommand { get; } = new(o =>
    {
        Console.WriteLine($"命令参数类型：{o?.GetType()}");
        MessageBox.Show($"执行了命令，{o}");
    });
}