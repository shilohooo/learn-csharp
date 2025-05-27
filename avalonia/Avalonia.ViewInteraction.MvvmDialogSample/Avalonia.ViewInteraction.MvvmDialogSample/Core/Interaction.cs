using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Avalonia.ViewInteraction.MvvmDialogSample.Core;

/// <summary>
///     交互模式实现，这是对 https://www.reactiveui.net/docs/handbook/interactions/ 的一个简单实现
/// </summary>
public sealed class Interaction<TInput, TOutput> : IDisposable, ICommand
{
    private Func<TInput, Task<TOutput>>? _handler;

    /// <summary>
    ///     只有注册了交互处理器，才可执行交互
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object? parameter)
    {
        return _handler is not null;
    }

    /// <summary>
    ///     执行交互
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object? parameter)
    {
        HandleAsync((TInput?)parameter!);
    }

    public event EventHandler? CanExecuteChanged;

    /// <summary>
    ///     重置交互处理器
    /// </summary>
    public void Dispose()
    {
        _handler = null;
    }

    /// <summary>
    ///     注册交互处理器
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public IDisposable RegisterHandler(Func<TInput, Task<TOutput>> handler)
    {
        if (_handler is not null) throw new InvalidOperationException("已注册过交互处理器，请勿重复注册:(");

        _handler = handler;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        return this;
    }

    /// <summary>
    ///     异步执行请求的交互，并返回视图提供的结果
    /// </summary>
    /// <param name="input">输入参数</param>
    /// <returns>交互的结果</returns>
    /// <exception cref="InvalidOperationException">如果没有注册交互处理器</exception>
    public Task<TOutput> HandleAsync(TInput input)
    {
        if (_handler is null) throw new InvalidOperationException("没有已注册的交互处理器:(");

        return _handler.Invoke(input);
    }
}