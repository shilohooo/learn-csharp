using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.Routing.BasicViewLocatorSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly List<PageViewModelBase> _pages =
        [new FirstPageViewModel(), new SecondPageViewModel(), new ThirdPageViewModel()];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NavigateNextCommand))]
    [NotifyCanExecuteChangedFor(nameof(NavigatePrevCommand))]
    private PageViewModelBase _currentPage;

    public MainWindowViewModel()
    {
        CurrentPage = _pages[0];
    }

    public bool CanNavNext => CurrentPage.CanNavigateNext;

    public bool CanNavPrev => CurrentPage.CanNavigatePrev;

    [RelayCommand(CanExecute = nameof(CanNavNext))]
    private void NavigateNext()
    {
        var idx = _pages.IndexOf(CurrentPage) + 1;
        CurrentPage = _pages[idx];
    }

    [RelayCommand(CanExecute = nameof(CanNavPrev))]
    private void NavigatePrev()
    {
        var idx = _pages.IndexOf(CurrentPage) - 1;
        CurrentPage = _pages[idx];
    }

    /// <summary>
    ///     当前 ViewModel 修改回调
    /// </summary>
    /// <remarks>
    ///     1. 判断是否从第二个页面跳转到其他页面，如果是，则为 <see cref="SecondPageViewModel.PropertyChanged" /> 取消订阅
    ///     <see cref="HandleSecondPageVmCanNavigateNextChanged" />
    ///     2. 判断是否从其他页面跳转到第二个页面，如果是，则为 <see cref="SecondPageViewModel.PropertyChanged" /> 订阅
    ///     <see cref="HandleSecondPageVmCanNavigateNextChanged" />
    /// </remarks>
    /// <param name="oldValue">旧值</param>
    /// <param name="newValue">新值</param>
    partial void OnCurrentPageChanged(PageViewModelBase? oldValue, PageViewModelBase newValue)
    {
        if (oldValue is SecondPageViewModel oldSecondPageView)
            oldSecondPageView.PropertyChanged -= HandleSecondPageVmCanNavigateNextChanged;

        if (newValue is SecondPageViewModel newSecondPageView)
            newSecondPageView.PropertyChanged += HandleSecondPageVmCanNavigateNextChanged;
    }

    /// <summary>
    ///     第二个页面的 ViewModel 的 <see cref="SecondPageViewModel.CanNavigateNext" /> 属性修改后，通知 <see cref="NavigateNextCommand" />
    ///     重新计算 CanExecute
    /// </summary>
    /// <param name="sender">触发事件的对象</param>
    /// <param name="e">事件参数</param>
    private void HandleSecondPageVmCanNavigateNextChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.PropertyName) &&
            e.PropertyName.Equals(nameof(SecondPageViewModel.CanNavigateNext)))
            NavigateNextCommand.NotifyCanExecuteChanged();
    }
}