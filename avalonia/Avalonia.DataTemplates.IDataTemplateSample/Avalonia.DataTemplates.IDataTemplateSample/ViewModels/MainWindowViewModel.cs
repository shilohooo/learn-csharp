using System;
using System.Collections.Generic;
using Avalonia.DataTemplates.IDataTemplateSample.Enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.DataTemplates.IDataTemplateSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    ///     当前选择的图形类型
    /// </summary>
    [ObservableProperty] private ShapeType _selectedShape;

    /// <summary>
    ///     图形类型选项
    /// </summary>
    public List<ShapeType> ShapeTypes { get; } = [..Enum.GetValues<ShapeType>()];

    public string Greeting { get; } = "Welcome to Avalonia!";
}