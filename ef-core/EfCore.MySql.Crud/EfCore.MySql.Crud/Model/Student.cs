using System.ComponentModel.DataAnnotations.Schema;
using EfCore.MySql.Crud.Constant;
using Microsoft.EntityFrameworkCore;

namespace EfCore.MySql.Crud.Model;

/// <summary>
/// 学生实体
/// </summary>
[Table("tb_student")]
[Index("StuNo", Name = "idx_stu_no")]
[Index("Age", Name = "idx_age")]
public class Student
{
    #region Properties

    /// <summary>
    /// 自增主键
    /// </summary>
    [Column("id", TypeName = "bigint(20)")]
    [Comment("自增主键")]
    public long Id { get; set; }

    /// <summary>
    /// 学生姓名
    /// </summary>
    [Column("name", TypeName = "varchar(50)")]
    public string? Name { get; set; }

    /// <summary>
    /// 学生性别
    /// </summary>
    [Column("sex", TypeName = "varchar(10)")]
    [Comment("性别")]
    public StudentConstants.Sex Sex { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    [Column("age", TypeName = "int(11)")]
    [Comment("年龄")]
    public int Age { get; set; }

    /// <summary>
    /// 学生学号
    /// </summary>
    [Column("stu_no", TypeName = "varchar(50)")]
    [Comment("学号")]
    public string? StuNo { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    [Column("mobile", TypeName = "varchar(50)")]
    [Comment("手机号码")]
    public string? Mobile { get; set; }

    /// <summary>
    /// 关联的人脸 ID，see：<see cref="StudentFace.Id"/>
    /// </summary>
    [Column("student_face_id", TypeName = "bigint(20)")]
    [Comment("关联的人脸 ID")]
    [ForeignKey("StudentFace")]
    public long StudentFaceId { get; set; }

    /// <summary>
    /// 关联的人脸信息
    /// </summary>
    public StudentFace? StudentFace { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
        return
            $"Student[Id: {Id}, Name: {Name}, Sex: {Sex}, Age: {Age}, StuNo: {StuNo}, Mobile: {Mobile}," +
            $" StudentFaceId: {StudentFaceId}, StudentFace: {StudentFace}]";
    }

    #endregion
}