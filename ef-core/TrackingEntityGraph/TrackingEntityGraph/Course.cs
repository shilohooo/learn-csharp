namespace TrackingEntityGraph;

/// <summary>
/// 课程实体，一个课程可以让多个学生加入
/// </summary>
public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    
    /// <summary>
    /// 定义一对多
    /// </summary>
    public ICollection<StudentCourse> StudentCourses { get; set; } = [];
}