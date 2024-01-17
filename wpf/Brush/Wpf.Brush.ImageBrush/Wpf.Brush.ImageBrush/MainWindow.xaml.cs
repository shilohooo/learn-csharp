using System.Windows;
using System.Windows.Input;

namespace Wpf.Brush.ImageBrush;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (Grid.Background is not System.Windows.Media.ImageBrush imageBrush)
        {
            return;
        }

        var offset = e.Delta / 3600.0;
        var rect = imageBrush.Viewport;
        if (rect.Width + offset <= 0 && rect.Height + offset <= 0)
        {
            return;
        }

        rect.Width += offset;
        rect.Height += offset;
        imageBrush.Viewport = rect;
    }
}