namespace AvaloniaPdmFileViewer.Models;

/// <summary>
///     Person Model
/// </summary>
public class Person(string firstName, string lastName)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}