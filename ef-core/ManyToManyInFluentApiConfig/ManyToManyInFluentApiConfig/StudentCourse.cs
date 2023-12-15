namespace ManyToManyInFluentApiConfig;

/// <summary>
/// 学生课程关联实体
/// </summary>
public class StudentCourse
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
}