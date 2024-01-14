using System.Windows;

namespace Wpf.RouteEvent.AttachedEvent.Mvvm;

public class SalesManager
{
    #region AttachedEvents

    /// <summary>
    /// 注册附件事件
    /// </summary>
    public static readonly RoutedEvent CheckEvent = EventManager.RegisterRoutedEvent(
        "CheckEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SalesManager)
    );

    /// <summary>
    /// 将事件添加到事件系统中
    /// </summary>
    /// <param name="dependencyObject"></param>
    /// <param name="handler"></param>
    public static void AddCheckHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
    {
        if (dependencyObject is not UIElement uiElement)
        {
            return;
        }

        uiElement.AddHandler(CheckEvent, handler);
    }

    /// <summary>
    /// 将事件从事件系统中移除
    /// </summary>
    /// <param name="dependencyObject"></param>
    /// <param name="handler"></param>
    public static void RemoveCheckHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
    {
        if (dependencyObject is not UIElement uiElement)
        {
            return;
        }

        uiElement.RemoveHandler(CheckEvent, handler);
    }

    #endregion
}