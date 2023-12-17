namespace DisconnectedEntityGraph;

/// <summary>
/// 学生实体，一个学生可以参加多个课程
/// </summary>
public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// 定义一对一
    /// </summary>
    public StudentAddress StudentAddress { get; set; }

    /// <summary>
    /// 定义一对多
    /// </summary>
    public ICollection<StudentCourse> StudentCourses { get; set; } = [];
}