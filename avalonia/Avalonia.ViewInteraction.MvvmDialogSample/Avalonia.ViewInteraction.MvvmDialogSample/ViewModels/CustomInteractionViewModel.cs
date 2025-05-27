using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.ViewInteraction.MvvmDialogSample.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.ViewInteraction.MvvmDialogSample.ViewModels;

/// <summary>
///     自定义交互 vm
/// </summary>
public partial class CustomInteractionViewModel : ViewModelBase
{
    /// <summary>
    ///     当前选择的文件名称列表
    /// </summary>
    [ObservableProperty] private List<string> _selectedFiles = [];

    /// <summary>
    ///     交互模式实例
    ///     <remarks>输入是一个对话框标题，输出是一个当前选择的文件名称列表</remarks>
    /// </summary>
    public Interaction<string, List<string>?> SelectFilesInteraction { get; set; } = new();

    [RelayCommand]
    private async Task SelectFilesAsync()
    {
        SelectedFiles = await SelectFilesInteraction.HandleAsync("Hello from avalonia:)") ?? [];
    }
}