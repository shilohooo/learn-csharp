using System.Windows;
using System.Windows.Controls;

namespace TabControl;

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
    /// 获取当前选中的标签页项 TabItem
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var tabControl = sender as System.Windows.Controls.TabControl;
        var selectedItem = tabControl?.SelectedItem as TabItem;
        var selectedContent = tabControl?.SelectedContent;
        TextBlock.Text = $"标题：{selectedItem?.Header}, 内容：{selectedContent}";
    }
}