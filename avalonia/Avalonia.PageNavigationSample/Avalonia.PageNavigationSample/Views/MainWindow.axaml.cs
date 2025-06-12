using Avalonia.Controls;
using Avalonia.Input;

namespace Avalonia.PageNavigationSample.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // 实现无边框窗口拖动
        PointerPressed += (_, e) =>
        {
            if (e.Pointer.Type is not PointerType.Mouse) return;

            BeginMoveDrag(e);
        };
    }
}