namespace EFCoreDataCUD;

/// <summary>
/// 年级实体
/// </summary>
public class Grade
{
    /// <summary>
    /// 年级 ID
    /// </summary>
    public int GradeId { get; set; }

    /// <summary>
    /// 年级名称
    /// </summary>
    public string GradeName { get; set; }

    /// <summary>
    /// 年级下的学生列表
    /// </summary>
    public ICollection<Student> Students { get; set; } = [];
}