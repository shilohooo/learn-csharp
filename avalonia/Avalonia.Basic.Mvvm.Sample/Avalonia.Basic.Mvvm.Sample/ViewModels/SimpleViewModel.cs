using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Basic.Mvvm.Sample.ViewModels;

/// <summary>
/// </summary>
public partial class SimpleViewModel : ViewModelBase
{
    /// <summary>
    ///     Name
    /// </summary>
    [ObservableProperty] private string? _name;

    /// <summary>
    ///     Greeting
    /// </summary>
    public string Greeting => string.IsNullOrWhiteSpace(Name) ? "Hello World!" : $"Hello World from {Name}!";

    /// <summary>
    ///     Name 属性修改后，触发 Greeting 属性修改同步到 UI
    ///     <remarks>
    ///         有点类似于 Vue 里面的 computed
    ///     </remarks>
    /// </summary>
    /// <param name="value">Name属性修改后的值</param>
    partial void OnNameChanged(string? value)
    {
        OnPropertyChanged(nameof(Greeting));
    }
}