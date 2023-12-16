namespace EFCoreShadowProperty;

/// <summary>
/// 学生实体
/// </summary>
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, DateOfBirth: {DateOfBirth}, Height: {Height}, Weight: {Weight}";
    }
}