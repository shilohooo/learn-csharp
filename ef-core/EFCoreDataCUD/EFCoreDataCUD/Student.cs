namespace EFCoreDataCUD;

/// <summary>
/// 学生实体
/// </summary>
public class Student
{
    /// <summary>
    /// 学生 ID
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// 学生名字
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// 学生姓氏
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// 所属年级 ID
    /// </summary>
    public int GradeId { get; set; }

    /// <summary>
    /// 所属年级
    /// </summary>
    public Grade Grade { get; set; }
}