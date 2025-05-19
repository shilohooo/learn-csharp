using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.DataTemplates.IDataTemplateSample.Enums;
using Avalonia.Metadata;

namespace Avalonia.DataTemplates.IDataTemplateSample.DataTemplates;

/// <summary>
///     根据图形类型来选择要渲染哪个数据模板
/// </summary>
public class ShapeTemplateSelector : IDataTemplate
{
    [Content] public Dictionary<string, IDataTemplate> AvailableTemplates { get; } = new();

    /// <inheritdoc />
    public Control? Build(object? param)
    {
        var key = param?.ToString();
        if (key is null) throw new ArgumentNullException(nameof(param));

        return AvailableTemplates[key].Build(param);
    }

    /// <inheritdoc />
    public bool Match(object? data)
    {
        // 该函数判断给点的数据是否匹配数据模板要渲染的数据类型
        var key = data?.ToString();
        return data is ShapeType && !string.IsNullOrWhiteSpace(key) && AvailableTemplates.ContainsKey(key);
    }
}