using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Avalonia.ViewInteraction.MvvmDialogSample.ViewModels;

namespace Avalonia.ViewInteraction.MvvmDialogSample.Views;

public partial class CustomInteractionView : UserControl
{
    private IDisposable? _selectFilesInteractionDisposable;

    public CustomInteractionView()
    {
        InitializeComponent();
    }

    /// <inheritdoc />
    protected override void OnDataContextChanged(EventArgs e)
    {
        _selectFilesInteractionDisposable?.Dispose();

        if (DataContext is CustomInteractionViewModel vm)
            _selectFilesInteractionDisposable = vm.SelectFilesInteraction.RegisterHandler(InteractionHandler);

        base.OnDataContextChanged(e);
    }

    /// <summary>
    ///     交互处理：打开文件对话框，选择文件
    /// </summary>
    /// <param name="input">交互处理的输入参数</param>
    /// <returns></returns>
    private async Task<List<string>?> InteractionHandler(string input)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        var storageFiles = await topLevel!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            AllowMultiple = true,
            Title = input
        });

        return storageFiles.Select(storageFile => $"{storageFile.Path}/{storageFile.Name}").ToList();
    }
}