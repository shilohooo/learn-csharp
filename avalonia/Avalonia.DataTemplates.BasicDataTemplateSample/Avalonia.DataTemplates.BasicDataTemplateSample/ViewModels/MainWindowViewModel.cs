using System.Collections.Generic;
using Avalonia.DataTemplates.BasicDataTemplateSample.Enums;
using Avalonia.DataTemplates.BasicDataTemplateSample.Models;

namespace Avalonia.DataTemplates.BasicDataTemplateSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<Person> People { get; } =
    [
        new Teacher
        {
            FirstName = "Mr.",
            LastName = "X",
            Age = 55,
            Sex = Sex.Male,
            Subject = "My Favorite Subject"
        },
        new Student
        {
            FirstName = "Hello",
            LastName = "World",
            Age = 17,
            Sex = Sex.Female,
            Grade = 12
        },
        new Student
        {
            FirstName = "Hello",
            LastName = "Kitty",
            Age = 12,
            Sex = Sex.Male,
            Grade = 6
        }
    ];
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
}