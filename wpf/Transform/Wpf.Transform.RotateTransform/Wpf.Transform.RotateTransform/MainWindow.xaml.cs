using System.Windows;
using System.Windows.Input;

namespace Wpf.Transform.RotateTransform;

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
        if (Button.RenderTransform is not System.Windows.Media.RotateTransform rotateTransform)
        {
            return;
        }

        var point = e.GetPosition(this);
        rotateTransform.Angle = point.X + point.Y;
    }
}