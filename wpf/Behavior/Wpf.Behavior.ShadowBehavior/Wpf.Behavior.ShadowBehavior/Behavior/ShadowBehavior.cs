using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Microsoft.Xaml.Behaviors;

namespace Wpf.Behavior.ShadowBehavior.Behavior;

/// <summary>
/// 阴影行为, 适用于UIElement控件及其子类
/// </summary>
public class ShadowBehavior : Behavior<UIElement>
{
    private readonly DropShadowEffect _dropShadowEffect = new();

    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.MouseEnter += AddShadow;
        AssociatedObject.MouseLeave += RemoveShadow;
        _dropShadowEffect.ShadowDepth = 0;
        _dropShadowEffect.BlurRadius = 5;
        _dropShadowEffect.Color = Colors.Black;
        AssociatedObject.Effect = _dropShadowEffect;
    }

    /// <summary>
    /// 鼠标进入时添加阴影
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddShadow(object sender, MouseEventArgs e)
    {
        _dropShadowEffect.BlurRadius = 15;
    }

    /// <summary>
    /// 鼠标离开时移除阴影
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RemoveShadow(object sender, MouseEventArgs e)
    {
        _dropShadowEffect.BlurRadius = 5;
    }
}