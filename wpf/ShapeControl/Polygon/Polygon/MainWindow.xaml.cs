using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Polygon;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _count;
    private System.Windows.Shapes.Polygon? _polygon;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (_count++ == 0)
        {
            _polygon = new System.Windows.Shapes.Polygon
            {
                StrokeThickness = 5,
                Stroke = Brushes.Red
            };
            Canvas.Children.Add(_polygon);
        }

        var point = e.GetPosition(Canvas);
        _polygon?.Points.Add(point);
    }

    private void OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        _count = 0;
    }
}