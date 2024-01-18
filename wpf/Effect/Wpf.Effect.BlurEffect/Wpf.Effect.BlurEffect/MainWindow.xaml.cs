using System.Windows;
using System.Windows.Input;

namespace Wpf.Effect.BlurEffect;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Grid_OnMouseMove(object sender, MouseEventArgs e)
    {
        var width = Grid.ActualWidth;
        var height = Grid.ActualHeight;
        var centerPoint = new Point(width / 2, height / 2);
        var mousePoint = e.GetPosition(Grid);

        if (Ellipse.Effect is not System.Windows.Media.Effects.BlurEffect blurEffect)
        {
            return;
        }

        // 计算距离
        var distance = Math.Sqrt(
            Math.Pow(mousePoint.X - centerPoint.X, 2)
            +
            Math.Pow(mousePoint.Y - centerPoint.Y, 2)
        );

        // 设置模糊程度
        blurEffect.Radius = distance / 5;

        Title = $"距离 = {distance}";
    }
}