using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace Wpf.Behavior.DragBehavior.Behavior;

/// <summary>
/// 控件移动行为, 实现思路:
/// 1、TranslateTransform平移对象最终赋值给RenderTransform属性，而RenderTransform位于UIElement基类中，
/// 所以，行为的泛型T参数应设置为UIElement。
/// 2、TranslateTransform的X和Y是当前控件平移的位置坐标，这个坐标相对于当前控件的父控件而言的，
/// 所以在实现行为时，要拿到这个父控件。
/// 3、我们采用鼠标去拖拽一个控件进行平移，所以要获取鼠标按下时的位置和移动过程中的位置，
/// 从而才知道TranslateTransform要平移到什么位置。
/// 4、如果当前被移动的控件没有TranslateTransform，我们需要先给它实例化一个TranslateTransform对象。
/// </summary>
public class DragBehavior : Behavior<FrameworkElement>
{
    private bool _isDragging;
    private Point _startPosition;

    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.MouseDown += OnMouseDown;
        AssociatedObject.MouseMove += OnMouseMove;
        AssociatedObject.MouseUp += OnMouseUp;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.MouseDown -= OnMouseDown;
        AssociatedObject.MouseMove -= OnMouseMove;
        AssociatedObject.MouseUp -= OnMouseUp;
    }

    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (AssociatedObject.Parent is not FrameworkElement parent)
        {
            return;
        }

        _isDragging = true;
        var clickPosition = e.GetPosition(parent);
        // 首次按下时, 判断 RenderTransform 的类型是否为 TranslateTransform
        if (AssociatedObject.RenderTransform is not TranslateTransform)
        {
            // 如果不是，那么就创建一个 TranslateTransform 对象并赋值给 RenderTransform 属性
            AssociatedObject.RenderTransform = new TranslateTransform();
        }

        if (AssociatedObject.RenderTransform is not TranslateTransform transform)
        {
            return;
        }

        _startPosition.X = clickPosition.X - transform.X;
        _startPosition.Y = clickPosition.Y - transform.Y;
        // 强制鼠标捕捉
        AssociatedObject.CaptureMouse();
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (!_isDragging)
        {
            return;
        }

        if (AssociatedObject.Parent is not FrameworkElement parent)
        {
            return;
        }

        var currentPosition = e.GetPosition(parent);

        if (AssociatedObject.RenderTransform is not TranslateTransform transform)
        {
            return;
        }

        transform.X = currentPosition.X - _startPosition.X;
        transform.Y = currentPosition.Y - _startPosition.Y;
    }

    private void OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _isDragging = false;
        // 释放鼠标捕捉
        AssociatedObject.ReleaseMouseCapture();
    }
}