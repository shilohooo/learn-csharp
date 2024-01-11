using System.Windows.Input;

namespace Wpf.Command.CommandBinding.Command;

/// <summary>
/// 自定义命令
/// </summary>
public class RelayCommand<T>(Action<T?> action) : ICommand
{
    /// <summary>
    /// 该方法用于判断命令是否能够执行
    /// </summary>
    /// <param name="parameter">命令参数</param>
    /// <returns>
    /// <see langword="true" /> 代表可以执行，否则为 <see langword="false" />
    /// </returns>
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    /// <summary>
    /// 如果 <see cref="CanExecute" /> 方法返回 <see langword="true" />，则 WPF 会自动调用此方法执行命令
    /// </summary>
    /// <param name="parameter">命令参数</param>
    public void Execute(object? parameter)
    {
        // 通过委托执行用户自定义的业务逻辑
        action((T?)parameter);
    }

    public event EventHandler? CanExecuteChanged;
}