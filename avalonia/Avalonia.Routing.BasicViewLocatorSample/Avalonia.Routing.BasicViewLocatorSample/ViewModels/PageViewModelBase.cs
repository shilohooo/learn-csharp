namespace Avalonia.Routing.BasicViewLocatorSample.ViewModels;

/// <summary>
/// </summary>
public abstract class PageViewModelBase : ViewModelBase
{
    /// <summary>
    ///     能否跳转到下一页
    /// </summary>
    public abstract bool CanNavigateNext { get; protected set; }

    /// <summary>
    ///     能否跳转到上一页
    /// </summary>
    public abstract bool CanNavigatePrev { get; protected set; }
}