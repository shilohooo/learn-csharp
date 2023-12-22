using System.Windows;

namespace RadioButton;

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
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowMenu(object sender, RoutedEventArgs e)
    {
        var menus = new List<string?>();

        if (BeefRadio.IsChecked is true)
        {
            menus.Add(BeefRadio.Content.ToString());
        }
        
        if (VegRadio.IsChecked is true)
        {
            menus.Add(VegRadio.Content.ToString());
        }
        
        if (PorkRadio.IsChecked is true)
        {
            menus.Add(PorkRadio.Content.ToString());
        }
        
        if (VegRadio2.IsChecked is true)
        {
            menus.Add(VegRadio2.Content.ToString());
        }
        
        if (menus.Count == 0)
        {
            return;
        }

        MessageBox.Show($"今晚想吃：{string.Join(",", menus)}");
    }
}