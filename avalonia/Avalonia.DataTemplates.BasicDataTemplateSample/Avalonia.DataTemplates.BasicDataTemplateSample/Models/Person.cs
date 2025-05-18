using Avalonia.DataTemplates.BasicDataTemplateSample.Enums;

namespace Avalonia.DataTemplates.BasicDataTemplateSample.Models;

/// <summary>
/// </summary>
public class Person
{
    /// <summary>
    ///     First name
    /// </summary>
    public string? FirstName { get; init; }

    /// <summary>
    ///     Last name
    /// </summary>
    public string? LastName { get; init; }

    /// <summary>
    ///     Age
    /// </summary>
    public int Age { get; init; }

    /// <summary>
    ///     Sex
    /// </summary>
    public Sex Sex { get; init; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{FirstName} {LastName} (Age: {Age}, Sex: {Sex})";
    }
}