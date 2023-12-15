namespace EFCoreDSDataCUD;

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

    public override string ToString()
    {
        return $"GradeId: {GradeId}, GradeName: {GradeName}";
    }
}