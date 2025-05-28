using System;
using System.Collections.Generic;
using Avalonia.Controls;

namespace Avalonia.ViewInteraction.DialogManagerSample.Services;

/// <summary>
///     对话框管理服务
/// </summary>
public class DialogManager
{
    private static readonly Dictionary<object, Visual?> RegisteredMapper = new();

    #region Attached Properties

    /// <summary>
    ///     记录要在哪个控件上面显示对话框
    /// </summary>
    public static readonly AttachedProperty<object?> RegisterProperty =
        AvaloniaProperty.RegisterAttached<DialogManager, Visual, object?>("Register");

    #endregion

    #region Constructors

    static DialogManager()
    {
        RegisterProperty.Changed.AddClassHandler<Visual>(RegisterChanged);
    }

    #endregion

    #region Private Methods

    private static void RegisterChanged(Visual sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (sender is null) throw new InvalidOperationException("对话框管理服务器只能在控件上注册");

        if (e.OldValue is not null) RegisteredMapper.Remove(e.OldValue);

        if (e.NewValue is null) return;

        RegisteredMapper.Add(e.NewValue, sender);
    }

    #endregion

    #region Public Methods

    public static void SetRegister(AvaloniaObject element, object value)
    {
        element.SetValue(RegisterProperty, value);
    }

    public static object? GetRegister(AvaloniaObject element)
    {
        return element.GetValue(RegisterProperty);
    }

    public static Visual? GetVisualForContext(object ctx)
    {
        return RegisteredMapper.GetValueOrDefault(ctx, null);
    }

    public static TopLevel? GetTopLevelForContext(object ctx)
    {
        return TopLevel.GetTopLevel(GetVisualForContext(ctx));
    }

    #endregion
}