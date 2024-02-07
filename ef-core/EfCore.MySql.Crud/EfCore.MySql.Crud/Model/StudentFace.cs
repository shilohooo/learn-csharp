using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EfCore.MySql.Crud.Model;

/// <summary>
/// 学生人脸照片实体，一个学生只能上传一张人脸照片
/// </summary>
[Table("tb_student_face")]
public class StudentFace
{
    #region Properties

    /// <summary>
    /// 自增主键
    /// </summary>
    [Column("id", TypeName = "bigint(20)")]
    [Comment("自增主键")]
    public long Id { get; set; }

    /// <summary>
    /// 人脸照片相对路径
    /// </summary>
    [Column("file_path", TypeName = "varchar(500)")]
    public string? FilePath { get; set; }

    /// <summary>
    /// 关联的学生信息
    /// </summary>
    public Student? Student { get; set; }

    #endregion

    #region Methods

    public override string ToString()
    {
        return $"StudentFace[Id: {Id}, FilePath: {FilePath}]";
    }

    #endregion
}