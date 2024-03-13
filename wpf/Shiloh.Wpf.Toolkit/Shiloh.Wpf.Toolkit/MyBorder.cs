using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Shiloh.Wpf.Toolkit;

/// <summary>
///     Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
///     Step 1a) Using this custom control in a XAML file that exists in the current project.
///     Add this XmlNamespace attribute to the root element of the markup file where it is
///     to be used:
///     xmlns:MyNamespace="clr-namespace:Shiloh.Wpf.Toolkit"
///     Step 1b) Using this custom control in a XAML file that exists in a different project.
///     Add this XmlNamespace attribute to the root element of the markup file where it is
///     to be used:
///     xmlns:MyNamespace="clr-namespace:Shiloh.Wpf.Toolkit;assembly=Shiloh.Wpf.Toolkit"
///     You will also need to add a project reference from the project where the XAML file lives
///     to this project and Rebuild to avoid compilation errors:
///     Right click on the target project in the Solution Explorer and
///     "Add Reference"->"Projects"->[Browse to and select this project]
///     Step 2)
///     Go ahead and use your control in the XAML file.
///     <MyNamespace:MyBorder />
/// </summary>
[ContentProperty("Content")]
public class MyBorder : Control
{
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content), typeof(object), typeof(MyBorder), new PropertyMetadata(default(object)));

    public static readonly DependencyProperty ContentTemplateProperty = DependencyProperty.Register(
        nameof(ContentTemplate), typeof(DataTemplate), typeof(MyBorder), new PropertyMetadata(default(DataTemplate)));

    static MyBorder()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MyBorder), new FrameworkPropertyMetadata(typeof(MyBorder)));
    }

    public DataTemplate ContentTemplate
    {
        get => (DataTemplate)GetValue(ContentTemplateProperty);
        set => SetValue(ContentTemplateProperty, value);
    }

    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}