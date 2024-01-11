using System.Windows;
using Wpf.Command.HelloWorld.Command;

namespace Wpf.Command.HelloWorld.ViewModel;

public class MainViewModel
{
    /// <summary>
    /// 命令属性
    /// </summary>
    public RelayCommand<object> OpenCommand { get; } = new(param =>
    {
        Console.WriteLine($"Command param type: {param?.GetType().Name}");
        MessageBox.Show($"Hello WPF Command:) {param}");
    });
}