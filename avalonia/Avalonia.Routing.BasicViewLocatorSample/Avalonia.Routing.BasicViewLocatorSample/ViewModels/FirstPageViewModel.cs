using System;

namespace Avalonia.Routing.BasicViewLocatorSample.ViewModels;

/// <summary>
///     第一个页面的 ViewModel
/// </summary>
public class FirstPageViewModel : PageViewModelBase
{
    /// <summary>
    ///     页面标题
    /// </summary>
    public string Title => "Welcome to our Wizard-Sample.";

    /// <summary>
    ///     页面内容
    /// </summary>
    public string Message => "Press \"Next\" to register yourself.";

    /// <summary>
    ///     第一页可以跳转到下一页
    /// </summary>
    public override bool CanNavigateNext
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    /// <summary>
    ///     第一页不能跳转到上一页
    /// </summary>
    public override bool CanNavigatePrev
    {
        get => false;
        protected set => throw new NotSupportedException();
    }
}