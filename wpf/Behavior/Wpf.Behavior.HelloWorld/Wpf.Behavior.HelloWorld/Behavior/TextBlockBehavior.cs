using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Microsoft.Xaml.Behaviors;

namespace Wpf.Behavior.HelloWorld.Behavior;

/// <summary>
/// 自定义行为, 给文本框添加阴影效果
/// </summary>
public class TextBlockBehavior : Behavior<TextBlock>
{
    /// <summary>
    /// 附加一个行为到目标对象时要执行的业务逻辑
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.MouseEnter += AssociatedObjectOnMouseEnter;
        AssociatedObject.MouseLeave += AssociatedObjectOnMouseLeave;
    }

    /// <summary>
    /// 分离一个行为时要执行的业务逻辑
    /// </summary>
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.MouseEnter -= AssociatedObjectOnMouseEnter;
        AssociatedObject.MouseLeave -= AssociatedObjectOnMouseLeave;
    }

    /// <summary>
    /// 在鼠标进入目标对象范围内时, 给目标对象添加阴影效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AssociatedObjectOnMouseEnter(object sender, MouseEventArgs e)
    {
        if (sender is not TextBlock textBlock)
        {
            return;
        }

        textBlock.Effect = new DropShadowEffect
        {
            Color = Colors.Gold,
            ShadowDepth = 0,
            BlurRadius = 15
        };
    }

    /// <summary>
    /// 鼠标离开目标对象范围时, 移除目标对象阴影效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AssociatedObjectOnMouseLeave(object sender, MouseEventArgs e)
    {
        if (sender is not TextBlock textBlock)
        {
            return;
        }

        textBlock.Effect = null;
    }
}