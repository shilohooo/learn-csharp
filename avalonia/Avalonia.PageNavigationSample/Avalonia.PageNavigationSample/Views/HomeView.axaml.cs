using Avalonia.Controls;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }
}