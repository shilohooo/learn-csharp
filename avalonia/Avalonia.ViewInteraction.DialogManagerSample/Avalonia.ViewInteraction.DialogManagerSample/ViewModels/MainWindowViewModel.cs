using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.ViewInteraction.DialogManagerSample.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.ViewInteraction.DialogManagerSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private List<string> _selectedFiles = [];

    public string Greeting { get; } = "Welcome to Avalonia!";

    [RelayCommand]
    private async Task SelectFilesAsync()
    {
        SelectedFiles = (await this.OpenFileDialogAsync()).ToList();
    }
}