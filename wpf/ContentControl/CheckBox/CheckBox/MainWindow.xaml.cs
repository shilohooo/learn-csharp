using System.Windows;

namespace CheckBox;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 显示菜单信息
    /// </summary>
    /// <param name="sender">事件发送者</param>
    /// <param name="e">路由事件参数</param>
    private void ShowMenu(object sender, RoutedEventArgs e)
    {
        List<string?> menus = [];
        // 通过判断CheckBox的IsChecked属性，来获取前端用户的选择，这通常是CheckBox控件最常用的用法
        if (BeefCheckBox.IsChecked is true)
        {
            menus.Add(BeefCheckBox.Content.ToString());
        }

        if (PorkCheckBox.IsChecked is true)
        {
            menus.Add(PorkCheckBox.Content.ToString());
        }

        if (SheepCheckBox.IsChecked is true)
        {
            menus.Add(SheepCheckBox.Content.ToString());
        }

        if (ChickenCheckBox.IsChecked is true)
        {
            menus.Add(ChickenCheckBox.Content.ToString());
        }

        if (menus.Count <= 0)
        {
            return;
        }

        MessageBox.Show($"今晚想吃：{string.Join(",", menus.ToArray())}");
    }
}