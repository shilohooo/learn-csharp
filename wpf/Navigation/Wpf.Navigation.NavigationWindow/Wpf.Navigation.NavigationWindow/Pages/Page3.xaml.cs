using System.Globalization;
using System.Windows.Controls;

namespace Wpf.Navigation.NavigationWindow.Pages;

public partial class Page3 : Page
{
    public Page3()
    {
        InitializeComponent();
        TimeTextBlock.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
    }
}