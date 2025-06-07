using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Avalonia.Controls.TreeViewSample.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Controls.TreeViewSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private TreeNodeModel? _selectedTreeNode;

    [ObservableProperty]
    private ObservableCollection<TreeNodeModel> _selectedTreeNodes = [new() { Title = "LevelTowSubMenu-1" }];

    public string Greeting { get; } = "Welcome to Avalonia!";

    public ObservableCollection<TreeNodeModel> TreeNodes { get; } = TreeNodeModel.BuildTestTreeNodes();

    partial void OnSelectedTreeNodeChanged(TreeNodeModel? value)
    {
        Debug.WriteLine($"selected node: {value?.Title}");
    }

    partial void OnSelectedTreeNodesChanged(ObservableCollection<TreeNodeModel> value)
    {
        value.ToList().ForEach(x => Debug.WriteLine($"selected node: {x.Title}"));
    }
}