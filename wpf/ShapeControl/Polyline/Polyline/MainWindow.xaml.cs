using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Polyline;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _count;
    private System.Windows.Shapes.Polyline? _polyline;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (_count++ == 0)
        {
            _polyline = new System.Windows.Shapes.Polyline
            {
                StrokeThickness = 5,
                Stroke = Brushes.Red
            };
            Canvas.Children.Add(_polyline);
        }

        var point = e.GetPosition(Canvas);
        _polyline?.Points.Add(point);
    }

    private void OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        _count = 0;
    }
}