using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.Basic.Mvvm.CommandSample.ViewModels;

/// <summary>
/// </summary>
public partial class CommandsViewModel : ViewModelBase
{
    /// <summary>
    ///     Robot name
    /// </summary>
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(OpenThePodBayDoorsFellowRobotCommand))]
    private string? _robotName;

    public ObservableCollection<string> ConversationLog { get; } = [];


    [RelayCommand]
    private void OpenThePodBayDoorsSync()
    {
        ConversationLog.Clear();
        AddToConvo("I'm sorry, Dave, I'm afraid I can't do that.");
    }

    [RelayCommand(CanExecute = nameof(CanRobotOpenTheDoor))]
    private void OpenThePodBayDoorsFellowRobot(string? robotName)
    {
        ConversationLog.Clear();
        AddToConvo($"Hello {robotName}, the Pod Bay is open :-)");
    }

    private bool CanRobotOpenTheDoor()
    {
        return !string.IsNullOrWhiteSpace(RobotName);
    }

    [RelayCommand]
    private async Task OpenThePodBayDoorsAsync()
    {
        ConversationLog.Clear();
        AddToConvo("Preparing to open the Pod Bay...");
        await Task.Delay(TimeSpan.FromSeconds(1));

        AddToConvo("Depressurizing Airlock...");
        await Task.Delay(TimeSpan.FromSeconds(2));

        AddToConvo("Retracting blast doors...");
        await Task.Delay(TimeSpan.FromSeconds(2));

        AddToConvo("Pod Bay is open to space!");
    }

    private void AddToConvo(string content)
    {
        ConversationLog.Add(content);
    }
}