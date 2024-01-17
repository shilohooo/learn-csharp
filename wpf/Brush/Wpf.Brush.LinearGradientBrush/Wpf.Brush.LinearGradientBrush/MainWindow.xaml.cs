using System.Windows;
using System.Windows.Input;

namespace Wpf.Brush.LinearGradientBrush;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (Grid.Background is not System.Windows.Media.LinearGradientBrush gridBrush)
        {
            return;
        }

        var gradientStop0 = gridBrush.GradientStops[0];
        var gradientStop1 = gridBrush.GradientStops[1];
        var point = e.GetPosition(this);
        var offset = (point.X + point.Y) / (Width + Height);
        gradientStop0.Offset = offset;
        gradientStop1.Offset = 1 - offset;
    }
}