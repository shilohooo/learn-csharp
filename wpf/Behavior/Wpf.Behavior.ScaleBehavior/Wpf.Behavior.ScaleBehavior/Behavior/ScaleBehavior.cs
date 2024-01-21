using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace Wpf.Behavior.ScaleBehavior.Behavior;

/// <summary>
/// 行为之控件缩放效果
/// </summary>
public class ScaleBehavior : Behavior<FrameworkElement>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.MouseWheel += ScaleControl;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.MouseWheel -= ScaleControl;
    }

    private void ScaleControl(object sender, MouseWheelEventArgs e)
    {
        // 首次滚动时, 判断 RenderTransform 的类型是否为 ScaleTransform
        if (AssociatedObject.RenderTransform is not ScaleTransform)
        {
            // 创建 ScaleTransform
            AssociatedObject.RenderTransform = new ScaleTransform
            {
                CenterX = AssociatedObject.ActualWidth / 2,
                CenterY = AssociatedObject.ActualHeight / 2,
            };
        }

        if (AssociatedObject.RenderTransform is not ScaleTransform scaleTransform)
        {
            return;
        }

        var scale = e.Delta * 0.001;
        scaleTransform.ScaleX += scale;
        scaleTransform.ScaleY += scale;
    }
}