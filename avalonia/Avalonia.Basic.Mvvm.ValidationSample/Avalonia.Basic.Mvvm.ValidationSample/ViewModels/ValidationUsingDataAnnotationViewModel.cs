using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Basic.Mvvm.ValidationSample.ViewModels;

/// <summary>
/// </summary>
public partial class ValidationUsingDataAnnotationViewModel : ViewModelBase
{
    /// <summary>
    ///     邮箱
    ///     <remarks>
    ///         加上 <see cref="NotifyDataErrorInfoAttribute" />，触发数据校验
    ///     </remarks>
    /// </summary>
    [Required(ErrorMessage = "邮箱不能为空")]
    [ObservableProperty]
    [EmailAddress(ErrorMessage = "邮箱不合法")]
    [NotifyDataErrorInfo]
    private string? _email;
}