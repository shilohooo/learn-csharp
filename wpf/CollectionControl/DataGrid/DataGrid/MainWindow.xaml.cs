using System.Windows;
using System.Windows.Controls;

namespace DataGrid;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var persons = new List<Person>(3);

        // 添加数据到表格中
        var person1 = new Person { Name = "张三", Age = 20, Address = "北京市朝阳区" };
        // DataGrid.Items.Add(person1);
        var person2 = new Person { Name = "李四", Age = 21, Address = "北京市海淀区" };
        // DataGrid.Items.Add(person2);
        var person3 = new Person { Name = "王五", Age = 22, Address = "北京市昌平区" };
        // DataGrid.Items.Add(person3);

        // 数据源赋值
        persons.Add(person1);
        persons.Add(person2);
        persons.Add(person3);

        // 这种赋值方式可以让前端编辑数据源
        DataGrid.ItemsSource = persons;
    }

    private void DisplaySelectedPersonInfo(object sender, SelectionChangedEventArgs e)
    {
        var dataGrid = sender as System.Windows.Controls.DataGrid;
        if (dataGrid?.SelectedItem is not Person person)
        {
            return;
        }

        // 回显当前选中的人员信息
        NameTextBlock.Text = person.Name;
        AgeTextBlock.Text = $"{person.Age}岁";
        AddressTextBlock.Text = person.Address;
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