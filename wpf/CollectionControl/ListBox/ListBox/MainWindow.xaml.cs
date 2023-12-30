using System.Windows;
using System.Windows.Controls;

namespace ListBox;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 添加人员信息到 ListBox
        ListBox.Items.Add(new Person { Name = "张三", Age = 20, Address = "北京市朝阳区" });
        ListBox.Items.Add(new Person { Name = "李四", Age = 21, Address = "北京市海淀区" });
        ListBox.Items.Add(new Person { Name = "王五", Age = 22, Address = "北京市昌平区" });
    }

    private void GetSelectedPersonInfo(object sender, RoutedEventArgs e)
    {
        // 获取当前选择的数据项
        // SelectedItem = 选中的第一项数据
        var selectedItem = ListBox.SelectedItem;
        var selectedValue = ListBox.SelectedValue;
        TextBlock.Text = $"{selectedItem} {selectedValue}";
    }

    private void GetListBox2SelectedInfo(object sender, RoutedEventArgs e)
    {
        try
        {
            var selectedItem = ListBox2.SelectedItem;
            var contentControl = selectedItem as ContentControl;
            TextBlock2.Text = $"selectedItem={selectedItem}\r\ncontent={contentControl?.Content}";
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}