using System.Collections.Generic;
using Avalonia.DataTemplates.FuncDataTemplateSample.Enums;
using Avalonia.DataTemplates.FuncDataTemplateSample.Models;

namespace Avalonia.DataTemplates.FuncDataTemplateSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable S2325 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore S2325 // Mark members as static

    public List<Person> People { get; } =
    [
        new()
        {
            FirstName = "Mr.",
            LastName = "X",
            Sex = Sex.Unknown
        },

        new()
        {
            FirstName = "Hello",
            LastName = "World",
            Sex = Sex.Male
        },

        new()
        {
            FirstName = "Hello",
            LastName = "Kitty",
            Sex = Sex.Female
        }
    ];
}