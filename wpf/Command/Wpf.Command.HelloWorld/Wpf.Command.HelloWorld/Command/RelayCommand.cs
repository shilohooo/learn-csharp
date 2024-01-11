using System.Windows.Input;

namespace Wpf.Command.HelloWorld.Command;

/// <summary>
/// 自定义命令
/// </summary>
public class RelayCommand<T>(Action<T?> action) : ICommand
{
    /// <summary>
    /// 命令执行时，要调用的委托
    /// </summary>
    private readonly Action<T?> _action = action;

    /// <summary>
    /// 判断命令是否可以执行，如果可以执行，返回 <code>true</code>，否则返回 <code>false</code>
    /// </summary>
    /// <param name="parameter">任务参数，可以为 <code>null</code></param>
    /// <returns></returns>
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    /// <summary>
    /// 如果命令可以执行，那么 WPF 会自动调用改方法，使用委托来执行业务逻辑
    /// </summary>
    /// <param name="parameter">任务参数</param>
    public void Execute(object? parameter)
    {
        // 调用委托，执行具体的方法
        _action?.Invoke((T?)parameter);
    }

    public event EventHandler? CanExecuteChanged;
}