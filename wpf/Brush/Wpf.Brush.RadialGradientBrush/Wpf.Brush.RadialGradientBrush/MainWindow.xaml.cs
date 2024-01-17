using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Wpf.Brush.RadialGradientBrush;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Ellipse_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (e.Source is not Ellipse ellipse)
        {
            return;
        }

        var point = e.GetPosition(ellipse);
        var width = ellipse.Width;
        var height = ellipse.Height;
        if (ellipse.Fill is not System.Windows.Media.RadialGradientBrush brush)
        {
            return;
        }

        var x = point.X / width;
        var y = point.Y / height;
        brush.GradientOrigin = new Point(x, y);
    }
}