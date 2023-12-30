using System.Windows;
using System.Windows.Controls;

namespace ComboBox;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var persons = new List<Person>
        {
            new() { Name = "张三", Age = 20, Address = "北京" },
            new() { Name = "李四", Age = 25, Address = "上海" },
            new() { Name = "王五", Age = 30, Address = "广州" },
            new() { Name = "赵六", Age = 35, Address = "深圳" },
        };

        // 绑定数据源
        PersonSelect.ItemsSource = persons;
    }

    /// <summary>
    /// 将下拉框当作文本框使用，该回调在文本框中输入内容时触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Mobile.Text = MobileInput.Text;
    }

    /// <summary>
    /// 回显当前选中的人员信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void DisplaySelectedPersonInfo(object sender, SelectionChangedEventArgs e)
    {
        var selector = sender as System.Windows.Controls.ComboBox;
        if (selector?.SelectedItem is not Person person)
        {
            return;
        }

        Name.Text = person.Name;
        Age.Text = $"{person.Age}岁";
        Address.Text = person.Address;
    }
}

/// <summary>
/// 人员信息
/// </summary>
public class Person
{
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; set; }
}