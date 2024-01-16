using System.Windows;

namespace SolidColorBrush;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Loaded += (_, _) =>
        // {
        //     System.Windows.Media.SolidColorBrush solidColorBrush = new()
        //     {
        //         Color = Colors.Green
        //     };
        //     // 从 Color 对象的 FromRgb 方法中得到颜色
        //     solidColorBrush.Color = Color.FromRgb(0, 0x80, 0);
        //     Grid.Background = solidColorBrush;
        // };
    }
}