using System.Windows;

namespace DatePicker;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowSelectedDate(object sender, RoutedEventArgs e)
    {
        // SelectedDate 属性会带上时分秒信息
        var selectedDate = $"查询日期：{StartDatePicker.SelectedDate} - {EndDatePicker.SelectedDate}";
        // 需要注意一点的是，DatePicker的SelectedDate属性是一个DateTime?日期型，而Text属性是一个string类型，所以两者的内容是不相等的。
        // Text 属性不包含时分秒
        var text = $"文本值：{StartDatePicker.Text} - {EndDatePicker.Text}";
        MessageBox.Show($"{selectedDate} {text}");
    }
}