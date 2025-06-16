using Avalonia.Controls;
using Avalonia.PageNavigationSample.ViewModels;

namespace Avalonia.PageNavigationSample.Views;

public partial class AboutView : UserControl
{
    public AboutView(AboutViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}