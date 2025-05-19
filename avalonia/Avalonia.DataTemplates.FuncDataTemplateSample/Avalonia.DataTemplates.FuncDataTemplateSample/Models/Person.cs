using Avalonia.DataTemplates.FuncDataTemplateSample.Enums;

namespace Avalonia.DataTemplates.FuncDataTemplateSample.Models;

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
    ///     Sex
    /// </summary>
    public Sex Sex { get; init; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}