using Avalonia.Controls;

namespace Avalonia.GroupBox.Controls;

public class GroupBox : ContentControl
{
    #region Styled Properties

    // 自定义样式属性，可以绑定到控件的样式上 Text={TemplateBinding Header}

    public static readonly StyledProperty<string> HeaderProperty =
        AvaloniaProperty.Register<GroupBox, string>(nameof(Header), "Header");

    /// <summary>
    ///     标题
    /// </summary>
    public string Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    #endregion
}