using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample;

public class ViewLocator : IDataTemplate
{
    /// <summary>
    ///     视图字典
    /// </summary>
    private static readonly Dictionary<Type, Func<Control>> ViewFactories = new();

    public Control? Build(object? param)
    {
        if (param is null)
            return null;

        var vmType = param.GetType();
        var notFound = new TextBlock { Text = "View not found for " + vmType.FullName };

        return ViewFactories.TryGetValue(vmType, out var factoryFn) ? factoryFn.Invoke() : notFound;
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }

    /// <summary>
    ///     注册视图
    /// </summary>
    /// <typeparam name="TViewModel">视图模型类型，必须是 <see cref="ViewModelBase" />的子类</typeparam>
    /// <typeparam name="TView">视图类型，必须是 <see cref="Control" />的子类</typeparam>
    public static void Register<TViewModel, TView>() where TViewModel : ViewModelBase where TView : Control, new()
    {
        ViewFactories[typeof(TViewModel)] = () => new TView();
    }
}