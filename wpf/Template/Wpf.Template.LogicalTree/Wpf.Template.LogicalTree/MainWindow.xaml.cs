using System.Windows;
using System.Windows.Controls;

namespace Wpf.Template.LogicalTree;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowLogicalTree(object sender, RoutedEventArgs e)
    {
        var rootNode = new TreeViewItem { Header = "Root" };

        LoadLogicTree(rootNode, this);

        LogicalTreeView.Items.Add(rootNode);
    }

    private static void LoadLogicTree(ItemsControl treeViewItem, object element)
    {
        if (element is not DependencyObject dependencyObject)
        {
            return;
        }

        var currentNode = new TreeViewItem { Header = element.GetType().Name };
        treeViewItem.Items.Add(currentNode);

        // 获取当前元素的子元素
        var elements = LogicalTreeHelper.GetChildren(dependencyObject);

        foreach (var child in elements)
        {
            LoadLogicTree(currentNode, child);
        }
    }
}