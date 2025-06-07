using System.Collections.ObjectModel;

namespace Avalonia.Controls.TreeViewSample.Models;

/// <summary>
///     树节点
/// </summary>
public class TreeNodeModel()
{
    public TreeNodeModel(string title) : this()
    {
        Title = title;
    }

    public TreeNodeModel(string title, ObservableCollection<TreeNodeModel> subNodes) : this(title)
    {
        Title = title;
        SubNodes = subNodes;
    }

    public required string Title { get; set; }

    public ObservableCollection<TreeNodeModel>? SubNodes { get; set; }

    public static ObservableCollection<TreeNodeModel> BuildTestTreeNodes()
    {
        return
        [
            new TreeNodeModel
            {
                Title = "Root",
                SubNodes =
                [
                    new TreeNodeModel
                    {
                        Title = "LevelOneSubMenu",
                        SubNodes =
                        [
                            new TreeNodeModel { Title = "LevelTwoSubMenu-1" },
                            new TreeNodeModel { Title = "LevelTwoSubMenu-2" },
                            new TreeNodeModel { Title = "LevelTwoSubMenu-3" }
                        ]
                    }
                ]
            }
        ];
    }
}