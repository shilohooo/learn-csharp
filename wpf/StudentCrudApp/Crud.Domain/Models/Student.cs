namespace Crud.Domain.Models;

/// <summary>
/// 学生实体
/// </summary>
public class Student
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 学生姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 课程
    /// </summary>
    public string Course { get; set; }
}