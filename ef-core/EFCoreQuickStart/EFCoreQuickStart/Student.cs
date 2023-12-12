namespace EFCoreQuickStart;

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
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// 学生姓氏
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// 出生日期
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// 个人照片
    /// </summary>
    public byte[] Photo { get; set; }

    /// <summary>
    /// 身高
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// 体重
    /// </summary>
    public float Weight { get; set; }

    /// <summary>
    /// 所属年级 ID
    /// </summary>
    public int GradeId { get; set; }

    /// <summary>
    /// 所属年级
    /// <remarks>
    /// <see cref="Grade"/>
    /// </remarks>
    /// </summary>
    public Grade Grade { get; set; }

    public override string ToString()
    {
        return $"StudentId: {StudentId}, FirstName: {FirstName}, LastName: {LastName}, Grade: {Grade}";
    }
}