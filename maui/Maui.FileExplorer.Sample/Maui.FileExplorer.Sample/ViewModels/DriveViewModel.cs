using System.Collections.ObjectModel;

namespace Maui.FileExplorer.Sample.ViewModels;

/// <summary>
/// 驱动信息视图模型
/// </summary>
internal class DriveViewModel
{
    /// <summary>
    /// 驱动器列表
    /// </summary>
    public ObservableCollection<DriveInfo> Drives { get; set; } = [];

    /// <summary>
    /// 加载所有驱动器
    /// </summary>
    public DriveViewModel()
    {
        const string msg = "DriveViewModel";
        Console.WriteLine(msg);
        // Drives = new ObservableCollection<DriveInfo>(DriveInfo.GetDrives(
    }
}
