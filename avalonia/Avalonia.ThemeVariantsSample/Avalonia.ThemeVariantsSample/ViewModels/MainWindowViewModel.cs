using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.ThemeVariantsSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isDarkMode = false;

    partial void OnIsDarkModeChanged(bool value)
    {
        if (Application.Current is null)
        {
            return;
        }

        if (IsDarkMode)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
            return;
        }
        
        Application.Current.RequestedThemeVariant = ThemeVariant.Light;
    }
}