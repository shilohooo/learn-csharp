using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using AvaloniaPdmFileViewer.Models;
using AvaloniaPdmFileViewer.Readers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaPdmFileViewer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    ///     tables
    /// </summary>
    [ObservableProperty] private ObservableCollection<Table> _tables = [];

    /// <summary>
    ///     current selected table
    /// </summary>
    [ObservableProperty] private Table? _currentTable;

    /// <summary>
    ///     loading flag
    /// </summary>
    [ObservableProperty] private bool _isLoading;

    /// <summary>
    ///     选择文件
    /// </summary>
    [RelayCommand]
    private async Task SelectPdmFile()
    {
        var storageProvider = Ioc.Default.GetService<IStorageProvider>()!;
        var files = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open PDM File",
            AllowMultiple = false,
            FileTypeFilter = new List<FilePickerFileType>
            {
                new("PDM File")
                {
                    Patterns = new List<string> { "*.xml", "*.pdm" }
                }
            }
        });
        if (files.Count == 0) return;
        await LoadPdmFile(files[0]);
    }

    /// <summary>
    ///     加载选中的 pdm 文件
    /// </summary>
    /// <param name="storageFile">选中的pdm文件</param>
    private async Task LoadPdmFile(IStorageFile storageFile)
    {
        await Dispatcher.UIThread.InvokeAsync(() => IsLoading = true);
        try
        {
            var resolveTables = await Task.Run(async () =>
            {
                await using var stream = await storageFile.OpenReadAsync();
                // 基础流读取 xml 文件
                return PdmFileReader.Read(stream);
            });

            await Dispatcher.UIThread.InvokeAsync(() => Tables = new ObservableCollection<Table>(resolveTables));
            if (Tables.Any()) CurrentTable = Tables[0];
        }
        finally
        {
            await Dispatcher.UIThread.InvokeAsync(() => IsLoading = false);
        }
    }

    [RelayCommand]
    private static void Exit()
    {
        Environment.Exit(0);
    }
}