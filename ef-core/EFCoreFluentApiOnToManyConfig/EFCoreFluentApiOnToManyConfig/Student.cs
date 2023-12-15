namespace EFCoreFluentApiOnToManyConfig;

/// <summary>
/// 学生实体，多个学生可以同属于一个年级
/// </summary>
public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CurrentGradeId { get; set; }

    public Grade Grade { get; set; }
}