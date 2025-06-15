using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample.Views;

public partial class MainWindow : Window
{
    /// <inheritdoc />
    public MainWindow()
    {
    }

    public MainWindow(Lazy<MainWindowViewModel> lazyViewModel)
    {
        InitializeComponent();
        DataContext = lazyViewModel.Value;
        PointerPressed += OnPointerPressed;
    }

    /// <summary>
    ///     实现无边框窗口拖动
    /// </summary>
    /// <returns></returns>
    private void OnPointerPressed(object? _, PointerPressedEventArgs e)
    {
        if (e.Pointer.Type is not PointerType.Mouse) return;

        BeginMoveDrag(e);
    }
}