namespace Notes.Models;

/// <summary>
/// 关于页数据模型
/// </summary>
internal class About
{
    /// <summary>
    /// 页面标题
    /// </summary>
    public string Title => AppInfo.Name;

    /// <summary>
    /// 版本号
    /// </summary>
    public string Version => AppInfo.VersionString;

    /// <summary>
    /// 更多信息跳转地址
    /// </summary>
    public string MoreInfoUrl => "https://cn.bing.com";

    /// <summary>
    /// 介绍信息
    /// </summary>
    public string Message => "This app is written in XAML and C# with .NET MAUI";
}