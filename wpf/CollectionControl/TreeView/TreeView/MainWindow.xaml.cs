using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace TreeView;

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
    /// 打开目录选择器
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OpenDirectorySelector(object sender, RoutedEventArgs e)
    {
        var openFolderDialog = new OpenFolderDialog();
        openFolderDialog.ShowDialog();
        var folderName = openFolderDialog.FolderName;
        if (folderName is null)
        {
            return;
        }

        // 加载树形目录
        TextBlock.Text = folderName;
        LoadTreeView(folderName);
    }

    /// <summary>
    /// 加载树形目录
    /// </summary>
    /// <param name="rootPath">根目录路径</param>
    private void LoadTreeView(string rootPath)
    {
        var rootNode = new TreeViewItem
        {
            // 添加根节点
            Header = rootPath
        };

        // 递归加载子文件夹和文件
        LoadSubDirectory(rootNode, rootPath);

        TreeView.Items.Add(rootNode);
    }

    /// <summary>
    /// 加载子文件夹和子文件
    /// </summary>
    /// <param name="node">树节点</param>
    /// <param name="path">目录路径</param>
    private void LoadSubDirectory(TreeViewItem node, string path)
    {
        try
        {
            var directoryInfo = new DirectoryInfo(path);
            // 加载子文件夹
            foreach (var directory in directoryInfo.GetDirectories())
            {
                var subNode = new TreeViewItem
                {
                    Header = directory.Name
                };

                LoadSubDirectory(subNode, directory.FullName);

                node.Items.Add(subNode);
            }

            // 加载文件
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                node.Items.Add(new TreeViewItem
                {
                    Header = fileInfo.Name
                });
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    /// <summary>
    /// 显示当前选中的树形控件子项的信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DisplaySelectedTreeViewItemInfo(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        var treeView = sender as System.Windows.Controls.TreeView;
        if (treeView?.SelectedItem is not TreeViewItem selectedItem)
        {
            return;
        }

        MessageBox.Show(selectedItem.Header.ToString());
    }
}