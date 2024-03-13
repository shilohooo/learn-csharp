using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Wpf.FileExplorer.Models;

/// <summary>
/// 驱动器信息
/// </summary>
public partial class Drive : ObservableObject
{
    /// <summary>
    /// 驱动器标签，如：系统、软件
    /// </summary>
    [ObservableProperty] private string? _label;

    /// <summary>
    /// 驱动器名称，如：C:\、D:\
    /// </summary>
    [ObservableProperty] private string? _name;

    /// <summary>
    /// 总空间，单位：GB
    /// </summary>
    [ObservableProperty] private long _totalSpace;

    /// <summary>
    /// 可用空间，单位：GB
    /// </summary>
    [ObservableProperty] private long _availableSpace;

    /// <summary>
    /// 根目录绝对路径
    /// </summary>
    [ObservableProperty] private string? _rootDirFullPath;

    /// <summary>
    /// 加载驱动器信息
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<Drive> LoadAllDrives()
    {
        return DriveInfo.GetDrives().Select(driveInfo => new Drive
        {
            Label = driveInfo.VolumeLabel,
            Name = $"({driveInfo.Name.Replace("\\", "")})",
            TotalSpace = driveInfo.TotalSize / 1024 / 1024 / 1024,
            AvailableSpace = driveInfo.AvailableFreeSpace / 1024 / 1024 / 1024,
            RootDirFullPath = driveInfo.RootDirectory.FullName
        });
    }
}