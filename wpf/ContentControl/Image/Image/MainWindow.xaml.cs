using System.Windows;
using System.Windows.Media.Imaging;

namespace Image;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var path = Environment.CurrentDirectory + "\\" + "huaji.jpg";
        var imgSource = BitmapFrame.Create(new Uri(path), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        LocalImage.Source = imgSource;
    }
}