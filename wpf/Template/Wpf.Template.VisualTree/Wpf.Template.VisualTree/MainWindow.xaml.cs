using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Template.VisualTree;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowVisualTree(object sender, RoutedEventArgs e)
    {
        var rootNode = new TreeViewItem { Header = "VisualTreeRootNode" };

        LoadVisualTree(rootNode, this);

        VisualTreeView.Items.Add(rootNode);
    }

    private static void LoadVisualTree(ItemsControl node, object element)
    {
        if (element is not DependencyObject dependencyObject)
        {
            return;
        }

        var currentNode = new TreeViewItem { Header = element.GetType().Name };
        node.Items.Add(currentNode);

        var childrenCount = VisualTreeHelper.GetChildrenCount(dependencyObject);
        for (var i = 0; i < childrenCount; i++)
        {
            LoadVisualTree(
                currentNode,
                VisualTreeHelper.GetChild(dependencyObject, i)
            );
        }
    }
}