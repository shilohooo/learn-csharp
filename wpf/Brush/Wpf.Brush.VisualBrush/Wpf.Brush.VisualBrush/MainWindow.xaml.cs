using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf.Brush.VisualBrush;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Image_OnMouseMove(object sender, MouseEventArgs e)
    {
        var point = e.GetPosition(Image);
        var length = Ellipse.ActualWidth;
        var radius = length / 2;
        var viewBoxRect = new Rect(point.X - radius, point.Y - radius, length, length);
        VisualBrush.Viewbox = viewBoxRect;
        Ellipse.SetValue(Canvas.LeftProperty, point.X - Ellipse.ActualWidth / 2);
        Ellipse.SetValue(Canvas.TopProperty, point.Y - Ellipse.ActualHeight / 2);
    }

    private void Image_OnMouseEnter(object sender, MouseEventArgs e)
    {
        Ellipse.Visibility = Visibility.Visible;
    }

    private void Image_OnMouseLeave(object sender, MouseEventArgs e)
    {
        Ellipse.Visibility = Visibility.Collapsed;
    }
}