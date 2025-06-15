using Avalonia.Controls;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample.Controls;

public partial class AppHeader : UserControl
{
    public AppHeader()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<AppHeaderViewModel>();
    }
}