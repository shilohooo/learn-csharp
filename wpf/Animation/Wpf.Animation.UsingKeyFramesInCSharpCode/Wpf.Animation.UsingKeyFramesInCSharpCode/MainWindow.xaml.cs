using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Wpf.Animation.UsingKeyFramesInCSharpCode;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Canvas_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        // 实例化关键帧动画和关键帧对象
        if (Canvas.Background is not LinearGradientBrush brush)
        {
            return;
        }

        var startAnimation = new PointAnimationUsingKeyFrames();
        var startKey = new LinearPointKeyFrame
        {
            KeyTime = TimeSpan.FromMicroseconds(2500)
        };
        startAnimation.KeyFrames.Add(startKey);
        var endAnimation = new PointAnimationUsingKeyFrames();
        var endKey = new LinearPointKeyFrame
        {
            KeyTime = TimeSpan.FromMicroseconds(1500)
        };
        endAnimation.KeyFrames.Add(endKey);

        // 生成随机数，并设置关键帧对象的 value 和 key time
        var random = new Random();
        var x = random.NextDouble();
        Thread.Sleep(1);
        var y = random.NextDouble();
        startKey.Value = new Point(x, y);

        Thread.Sleep(1);
        x = random.NextDouble();
        Thread.Sleep(1);
        y = random.NextDouble();
        endKey.Value = new Point(x, y);

        // 开启动画
        brush.BeginAnimation(LinearGradientBrush.StartPointProperty, startAnimation);
        brush.BeginAnimation(LinearGradientBrush.EndPointProperty, endAnimation);
    }
}