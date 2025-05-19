using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Routing.BasicViewLocatorSample.ViewModels;

/// <summary>
///     第二个页面的 ViewModel
/// </summary>
public partial class SecondPageViewModel : PageViewModelBase
{
    /// <summary>
    ///     能否导航到下一页
    /// </summary>
    private bool _canNavigateNext;

    /// <summary>
    ///     注册邮箱
    /// </summary>
    [ObservableProperty]
    [Required(ErrorMessage = "邮箱不能为空")]
    [EmailAddress(ErrorMessage = "邮箱不合法")]
    [NotifyDataErrorInfo]
    private string? _email;

    /// <summary>
    ///     密码
    /// </summary>
    [ObservableProperty] [Required(ErrorMessage = "密码不能为空")] [NotifyDataErrorInfo]
    private string? _password;

    /// <inheritdoc />
    public override bool CanNavigateNext
    {
        get => _canNavigateNext;
        protected set => SetProperty(ref _canNavigateNext, value);
    }

    /// <inheritdoc />
    public override bool CanNavigatePrev
    {
        // 第二个页面可以返回到上一页
        get => true;
        protected set => throw new NotSupportedException();
    }

    partial void OnEmailChanged(string? value)
    {
        UpdateCanNavigateNext();
    }

    partial void OnPasswordChanged(string? value)
    {
        UpdateCanNavigateNext();
    }

    /// <summary>
    ///     更新 CanNavigateNext
    /// </summary>
    private void UpdateCanNavigateNext()
    {
        // 填写了有效的邮箱和密码后，才能跳转到下一页
        CanNavigateNext = !string.IsNullOrWhiteSpace(Email) && Email.Contains('@') &&
                          !string.IsNullOrWhiteSpace(Password);
    }
}