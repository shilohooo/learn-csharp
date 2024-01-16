using System.Windows;
using System.Windows.Input;

namespace Wpf.Transform.ScaleTransform;

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
        if (Button.RenderTransform is not System.Windows.Media.ScaleTransform scaleTransform)
        {
            return;
        }

        var point = e.GetPosition(this);
        scaleTransform.ScaleX = point.X / 200;
        scaleTransform.ScaleY = point.Y / 200;
    }
}