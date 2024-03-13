using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.FileExplorer.Models;

namespace Wpf.FileExplorer.ViewModels;

/// <summary>
/// 驱动器信息视图模型
/// </summary>
public partial class DriveViewModel : ObservableObject
{
    /// <summary>
    /// 驱动器信息列表
    /// </summary>
    [ObservableProperty] private ObservableCollection<Drive>? _drives;

    /// <summary>
    /// 驱动器选择命令
    /// </summary>
    public ICommand SelectDriveCommand { get; set; }

    public DriveViewModel()
    {
        _drives = new ObservableCollection<Drive>(Drive.LoadAllDrives());
        SelectDriveCommand = new RelayCommand<Drive>(SelectDrive);
    }

    /// <summary>
    /// 选择驱动器
    /// </summary>
    /// <param name="drive">当前选择的驱动器信息</param>
    private void SelectDrive(Drive? drive)
    {
        if (drive == null)
        {
            return;
        }

        MessageBox.Show(
            $"当前选择的驱动器信息 - 标签：{drive.Label}，名称：{drive.Name}，总空间：{drive.TotalSpace}GB，可用空间：{drive.AvailableSpace}GB，根目录绝对路径：{drive.RootDirFullPath}");
    }
}