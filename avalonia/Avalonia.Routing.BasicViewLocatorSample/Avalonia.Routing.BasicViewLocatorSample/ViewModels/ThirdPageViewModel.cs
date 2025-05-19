using System;

namespace Avalonia.Routing.BasicViewLocatorSample.ViewModels;

/// <summary>
///     第三个页面的 ViewModel
/// </summary>
public class ThirdPageViewModel : PageViewModelBase
{
    /// <summary>
    ///     页面内容
    /// </summary>
    public string Message => "Done";

    /// <inheritdoc />
    public override bool CanNavigateNext
    {
        get => false;
        protected set => throw new NotSupportedException();
    }

    /// <inheritdoc />
    public override bool CanNavigatePrev
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
}