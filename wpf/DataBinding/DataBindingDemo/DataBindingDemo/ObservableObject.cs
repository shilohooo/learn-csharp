using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindingDemo;

/// <summary>
/// 触发属性更改通知的基类，ViewModel、Model 可以继承此类，从而调用属性更改通知接口。
/// </summary>
public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// 属性变更回调，使用了 CallerMemberNameAttribute，可以自动获取属性名称
    /// </summary>
    /// <param name="propertyName">属性名称</param>
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this, new PropertyChangedEventArgs(propertyName)
        );
    }
}