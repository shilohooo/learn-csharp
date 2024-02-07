using EfCore.MySql.Crud.Context;
using EfCore.MySql.Crud.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCore.MySql.Crud.Repository;

/// <summary>
/// 学生信息仓储
/// </summary>
public class StudentRepository(SchoolContext schoolContext)
{
    #region Methods

    /// <summary>
    /// 新增学生信息
    /// </summary>
    /// <param name="student">学生信息</param>
    public Student Save(Student student)
    {
        schoolContext.Student?.Add(student);
        schoolContext.SaveChanges();
        Console.WriteLine($"新增学生信息成功，学生 ID：{student.Id}");
        return student;
    }

    /// <summary>
    /// 根据 ID 删除学生信息
    /// </summary>
    /// <param name="id">学生 ID</param>
    public void DeleteById(long id)
    {
        var studentToDelete = schoolContext.Student?
            .Include(student => student.StudentFace)
            .First(student => id == student.Id);
        if (studentToDelete is null)
        {
            return;
        }

        schoolContext.Student?.Remove(studentToDelete);
        if (studentToDelete.StudentFace is not null)
        {
            schoolContext.StudentFace?.Remove(studentToDelete.StudentFace);
        }

        schoolContext.SaveChanges();
    }

    /// <summary>
    /// 更新学生信息
    /// </summary>
    /// <param name="student">学生信息</param>
    public void Update(Student student)
    {
        schoolContext.Student?.Update(student);
        schoolContext.SaveChanges();
    }

    /// <summary>
    /// 查询所有学生信息
    /// </summary>
    /// <returns>学生信息列表</returns>
    public List<Student>? FindAll()
    {
        return schoolContext.Student?
            .Include(student => student.StudentFace)
            .OrderByDescending(student => student.Age)
            .Skip((2 - 1) * 2)
            .Take(2)
            .ToList();
    }

    /// <summary>
    /// 根据 ID 查询学生信息
    /// </summary>
    /// <param name="id">学生ID</param>
    /// <returns>ID对应的学生信息</returns>
    public Student? FindById(long id)
    {
        return schoolContext.Student?
            .Include(student => student.StudentFace)
            .FirstOrDefault(student => id == student.Id) ?? null;
    }

    #endregion
}