using System.Windows;
using System.Windows.Input;

namespace Wpf.Effect.DropShadowEffect;

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

        // 计算与 X 轴的夹角
        var angle = Math.Atan2(mousePoint.Y - centerPoint.Y, mousePoint.X - centerPoint.X);
        var theta = angle * 180 / Math.PI;
        Title = $"角度 = {theta}";

        if (Button.Effect is not System.Windows.Media.Effects.DropShadowEffect dropShadowEffect)
        {
            return;
        }

        // 计算距离
        var distance = Math.Sqrt(
            Math.Pow(mousePoint.X - centerPoint.X, 2)
            +
            Math.Pow(mousePoint.Y - centerPoint.Y, 2)
        );

        // 设置阴影角度
        dropShadowEffect.Direction = -theta;
        // 设置阴影偏移量
        dropShadowEffect.ShadowDepth = distance / 10;
        // 设置模糊程度
        dropShadowEffect.BlurRadius = distance / 10 * 2;
    }
}