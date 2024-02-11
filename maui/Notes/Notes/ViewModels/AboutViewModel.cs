using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;

namespace Notes.ViewModels;

/// <summary>
/// About页面视图模型
/// </summary>
public class AboutViewModel
{
    /// <summary>
    /// 页面标题
    /// </summary>
    public string Title => AppInfo.Name;

    /// <summary>
    /// 应用版本
    /// </summary>
    public string Version => AppInfo.VersionString;

    /// <summary>
    /// 更新信息的跳转地址
    /// </summary>
    public string MoreInfoUrl => "https://cn.bing.com";

    /// <summary>
    /// 消息
    /// </summary>
    public string Message => "该应用是使用 XAML 和 .NET MAUI 编写的";

    /// <summary>
    /// 显示更多信息的命令
    /// 命令是一种可以绑定的行为，它可以调用某些代码，是放置应用逻辑的好地方
    /// 在当前类中，该命令指向 <see cref="ShowMoreInfo"/> 方法
    /// </summary>
    public ICommand ShowMoreInfoCommand { get; }

    /// <summary>
    /// 初始化命令
    /// </summary>
    public AboutViewModel()
    {
        ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
    }

    /// <summary>
    /// 使用系统默认浏览器跳转到更新信息页面
    /// </summary>
    private async Task ShowMoreInfo()
    {
        await Launcher.Default.OpenAsync(MoreInfoUrl);
    }
}