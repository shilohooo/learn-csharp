using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.Controls;

namespace Avalonia.MusicStore.Services;

/// <summary>
///     对话框管理服务
/// </summary>
public class DialogManager
{
    /// <summary>
    ///     注册映射，key = 控件的 viewModel 实例，value = 对应的控件实例
    /// </summary>
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

    /// <summary>
    ///     注册变更回调
    /// </summary>
    /// <param name="sender">在哪个窗口打开对话框</param>
    /// <param name="e">事件参数，可以将窗口的view model 实例绑定到<see cref="AvaloniaPropertyChangedEventArgs.NewValue" />属性</param>
    /// <exception cref="InvalidOperationException">窗口实例为空时</exception>
    private static void RegisterChanged(Visual sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (sender is null) throw new InvalidOperationException("对话框管理服务器只能在控件上注册");

        if (e.OldValue is not null) RegisteredMapper.Remove(e.OldValue);

        if (e.NewValue is null) return;

        Debug.WriteLine($"DialogManager - Register Changde, {sender}, {e}");
        RegisteredMapper.Add(e.NewValue, sender);
    }

    #endregion

    #region Public Methods

    public static void SetRegister(AvaloniaObject element, object value)
    {
        Debug.WriteLine($"DialogManager - SetRegister, {element}, {value}");
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