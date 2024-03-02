using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace Wpf.Xaml;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Console.WriteLine("Hello World!");
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        // 资源不但可以在XAML中访问，在C#中也可以访问
        var res = FindResource(resourceKey: "Human");
        if (res is not Human human)
        {
            return;
        }

        MessageBox.Show(human.Child.Name);
    }
}

/// <summary>
/// 使用TypeConverter 类映射Attribute与Property
/// </summary>
[TypeConverter(typeof(StringToHumanTypeConverter))]
public class Human
{
    public string? Name { get; set; }
    public Human Child { get; set; }
}

/// <summary>
/// 字符串转 Human 类型
/// </summary>
public class StringToHumanTypeConverter : TypeConverter
{
    /// <summary>
    /// 设计时判断是否支持源类型到目标类型的转换，缺少此方法的重载会使UI设计器异常
    /// </summary>
    /// <param name="context"></param>
    /// <param name="sourceType"></param>
    /// <returns></returns>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    /// <summary>
    /// 运行时转换源类型为此目标类型，缺少此方法的重载会使运行时类型转换异常
    /// </summary>
    /// <param name="context"></param>
    /// <param name="culture"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        return value is not string name
            ? base.ConvertFrom(context, culture, value)
            : new Human { Name = name };
    }
}