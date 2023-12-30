using System.Windows;
using System.Windows.Controls;

namespace Menu;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<MenuModel> Menus = [];

    public MainWindow()
    {
        InitializeComponent();

        // 初始化菜单
        for (var i = 0; i < 5; i++)
        {
            var parent = new MenuModel
            {
                Name = $"一级菜单（{i + 1}）"
            };
            for (var j = 0; j < 5; j++)
            {
                var children = new MenuModel
                {
                    Name = $"二级菜单（{j + 1}）"
                };
                parent.Children.Add(children);
            }

            Menus.Add(parent);
        }

        DynamicMenu.ItemsSource = Menus;
    }

    /// <summary>
    /// 显示当前点击的菜单名称
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMenuItemClick(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        MessageBox.Show($"你点击了【{menuItem?.Header}】");
    }
}

/// <summary>
/// 菜单实体
/// </summary>
public class MenuModel
{
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 子菜单列表
    /// </summary>
    public List<MenuModel> Children { get; set; } = [];

    /// <summary>
    /// 视图
    /// </summary>
    public string View { get; set; }
}