using System.Windows.Controls;
using Wpf.Command.EventToCommand.Command;

namespace Wpf.Command.EventToCommand.ViewModel;

public class MainViewModel
{
    /// <summary>
    /// 命令属性
    /// </summary>
    public RelayCommand<TextBox> MouseDownCommand { get; } = new(textBox =>
    {
        if (textBox is not null)
        {
            textBox.Text += $"{DateTime.Now}: 您点击了 TextBox 控件:)\r";
        }
    });
}