namespace EFCoreFluentApiOnToManyConfig;

/// <summary>
/// 年级实体，一个年级下可以有多个学生
/// </summary>
public class Grade
{
    public int GradeId { get; set; }
    public string GradeName { get; set; }
    public string Section { get; set; }

    public ICollection<Student> Students { get; set; } = [];
}