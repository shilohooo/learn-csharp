namespace Dapper.PostgreSql;

/// <summary>
/// 
/// </summary>
public class User
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    
    public override string ToString()
    {
        return $"User: [Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, FullName: {FullName}]";
    }
}