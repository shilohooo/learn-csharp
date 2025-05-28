using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using Avalonia.ViewInteraction.DialogManagerSample.Services;

namespace Avalonia.ViewInteraction.DialogManagerSample.Helpers;

/// <summary>
///     Dialog 工具类
/// </summary>
public static class DialogHelper
{
    /// <summary>
    ///     异步打开文件对话框
    /// </summary>
    /// <param name="context">上下文对象</param>
    /// <param name="title">对话框标题</param>
    /// <param name="multiple">是否多选，默认为 false</param>
    /// <returns>当前选择的文件绝对路径数组</returns>
    public static async Task<IEnumerable<string>> OpenFileDialogAsync(this object? context, string? title = "选择文件",
        bool multiple = true)
    {
        ArgumentNullException.ThrowIfNull(context);

        var topLevel = DialogManager.GetTopLevelForContext(context);
        if (topLevel is null) return [];

        var storageFiles = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = title,
            AllowMultiple = multiple
        });

        return storageFiles.Select(storageFile => storageFile.Path.AbsolutePath);
    }
}