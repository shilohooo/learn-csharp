namespace EFCoreLogging;

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
    /// 名字
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// 姓氏
    /// </summary>
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}";
    }
}