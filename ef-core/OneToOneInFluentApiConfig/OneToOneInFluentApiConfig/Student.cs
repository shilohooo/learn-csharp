namespace OneToOneInFluentApiConfig;

/// <summary>
/// 学生实体，每个学生都有一个自己的地址信息
/// </summary>
public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public StudentAddress StudentAddress { get; set; }
}