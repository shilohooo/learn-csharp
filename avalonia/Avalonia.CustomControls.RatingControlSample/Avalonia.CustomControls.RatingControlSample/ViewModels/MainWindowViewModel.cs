using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.CustomControls.RatingControlSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private int _numberOfStars = 6;

    [ObservableProperty] [Range(0, 5, ErrorMessage = "评分值只能的范围只能为 0 ~ 5")] [NotifyDataErrorInfo]
    private int _ratingValue = 2;

    public string Greeting { get; } = "Welcome to Avalonia!";
}