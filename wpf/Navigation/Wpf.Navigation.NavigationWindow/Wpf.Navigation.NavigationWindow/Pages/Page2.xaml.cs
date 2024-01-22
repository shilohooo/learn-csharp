using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf.Navigation.NavigationWindow.Pages;

public partial class Page2 : Page
{
    public Page2()
    {
        InitializeComponent();
        TimeTextBlock.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// 跳转到 Page3
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToPage3(object sender, MouseButtonEventArgs e)
    {
        NavigationService?.Navigate(new Uri("/Pages/Page3.xaml", UriKind.Relative));
    }
}