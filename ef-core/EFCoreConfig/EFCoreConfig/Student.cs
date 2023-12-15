using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConfig;

/// <summary>
/// 学生实体，使用注解覆盖 EF Core 默认配置来生成数据库表结构，使用 Table 注解指定数据库表名称，
/// 使用 Comment 注解给表添加注释信息
/// </summary>
[Table("StudentInfo", Schema = "dbo")]
[Comment("学生信息表")]
public class Student
{
    /// <summary>
    /// 学生 ID，使用 Key 注解标注属性为主键字段，表示唯一标识实体的一个属性。
    /// 使用 Comment 注解给字段添加注释信息
    /// </summary>
    [Key]
    [Comment("主键")]
    public int StudentId { get; set; }

    /// <summary>
    /// 学生姓名，使用 Column 注解配置数据库字段名称和数据库字段类型，使用 MaxLength 注解配置数据库字段长度
    /// </summary>
    [Column("Name", TypeName = "nvarchar")]
    [MaxLength(50)]
    [Comment("学生姓名")]
    public string StudentName { get; set; }

    /// <summary>
    /// 学生年龄，使用 NotMapped 注解标识该字段无需持久化，即不会创建对应的数据库字段
    /// </summary>
    [NotMapped]
    public int? Age { get; set; }

    public override string ToString()
    {
        return $"StudentId: {StudentId}, Name: {StudentName}, Age: {Age}";
    }
}