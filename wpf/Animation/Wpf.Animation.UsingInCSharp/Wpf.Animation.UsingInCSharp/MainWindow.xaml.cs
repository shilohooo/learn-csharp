using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Wpf.Animation.UsingInCSharp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Grid_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        var point = e.GetPosition(Grid);
        if (Ellipse.RenderTransform is not ScaleTransform scaleTransform)
        {
            return;
        }

        var doubleAnimation = new DoubleAnimation
        {
            To = (point.X + point.Y) / 200,
            Duration = new TimeSpan(
                0, 0, 0, 0, 250
            )
        };

        // 通过动画修改ScaleX和ScaleY属性达到放大的效果
        scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, doubleAnimation);
        scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, doubleAnimation);
    }
}