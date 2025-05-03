namespace SqlSugar.HelloWorld;

/// <summary>
/// 学生实体
/// </summary>
[SugarTable("T_Student")]
public class Student
{
    /// <summary>
    /// 属性名称要和数据库一致，或者使用 ColumnName 指定列名
    /// 如果是主键，要把 IsPrimaryKey 设置为 true
    /// 如果主键是自增的，要把 IsIdentity 设置为 true
    /// </summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public long Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Student: [{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Age)}={Age}]";
    }
}