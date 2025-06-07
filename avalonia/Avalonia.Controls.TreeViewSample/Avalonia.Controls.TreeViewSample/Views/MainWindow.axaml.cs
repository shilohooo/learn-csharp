using System.Diagnostics;

namespace Avalonia.Controls.TreeViewSample.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TreeView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine($"selected nodes count: {e.AddedItems.Count}");
    }
}