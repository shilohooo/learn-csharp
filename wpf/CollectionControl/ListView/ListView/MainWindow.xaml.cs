using System.Windows;
using System.Windows.Controls;

namespace ListView;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 添加数据
        ListView.Items.Add(new Person { Name = "张三", Age = 20, Address = "北京市海淀区" });
        ListView.Items.Add(new Person { Name = "李四", Age = 21, Address = "北京市朝阳区" });
        ListView.Items.Add(new Person { Name = "王五", Age = 22, Address = "北京市昌平区" });
    }

    /// <summary>
    /// 获取当前选中的人员信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DisplaySelectedPersonInfo(object sender, SelectionChangedEventArgs e)
    {
        var listView = sender as System.Windows.Controls.ListView;
        if (listView?.SelectedItem is not Person person)
        {
            return;
        }

        // 可以确定，当前选中的项是 Person 类型
        Name.Text = person.Name;
        Age.Text = $"{person.Age}岁";
        Address.Text = person.Address;
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}