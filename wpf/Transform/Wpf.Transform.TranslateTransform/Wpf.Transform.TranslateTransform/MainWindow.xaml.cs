using System.Windows;
using System.Windows.Input;

namespace Wpf.Transform.TranslateTransform;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Point DownPoint { get; private set; } = new(0, 0);

    public bool IsMouseDown { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (!IsMouseDown)
        {
            return;
        }

        if (Border.RenderTransform is not System.Windows.Media.TranslateTransform translateTransform)
        {
            return;
        }

        var point = e.GetPosition(this);
        translateTransform.X = point.X - DownPoint.X;
        translateTransform.Y = point.Y - DownPoint.Y;
    }

    private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        IsMouseDown = true;
        DownPoint = e.GetPosition(this);
    }

    private void MainWindow_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        IsMouseDown = false;
    }
}