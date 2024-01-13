using System.Windows;
using System.Windows.Controls;

namespace Wpf.Dp.AttachedDp.Helper;

/// <summary>
/// 给 PasswordBox 添加属性
/// </summary>
public class PasswordBoxHelper
{
    public static string GetPassword(DependencyObject obj)
    {
        return (string)obj.GetValue(PasswordProperty);
    }

    public static void SetPassword(DependencyObject obj, string value)
    {
        obj.SetValue(PasswordProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyNum.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached(
        "Password",
        typeof(string),
        typeof(PasswordBoxHelper),
        new PropertyMetadata(string.Empty, OnPasswordPropertyChangedCallback)
    );

    private static void OnPasswordPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not PasswordBox passwordBox)
        {
            return;
        }

        passwordBox.PasswordChanged -= OnPasswordChanged;
        passwordBox.PasswordChanged += OnPasswordChanged;
    }

    /// <summary>
    /// 密码修改时设置密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is not PasswordBox passwordBox)
        {
            return;
        }

        SetPassword(passwordBox, passwordBox.Password);
    }
}