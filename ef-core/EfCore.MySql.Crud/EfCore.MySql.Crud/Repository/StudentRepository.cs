using System.Linq.Expressions;
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
        // 使用表达式树构建动态查询条件
        var parameterExpression = Expression.Parameter(typeof(Student));

        // 根据姓名模糊查询 where name like ?
        // 1.声明属性表达式
        var nameExp = Expression.Property(parameterExpression, typeof(Student), "Name");
        // 2.声明值表达式
        Expression<Func<object>> nameValExp = () => "赵六";
        // 3.转换值表达式类型
        var nameConvertExp = Expression.Convert(nameValExp.Body, nameExp.Type);
        // 4.声明条件表达式
        var strContainsMethod = typeof(string).GetMethod("Contains", [typeof(string)])!;
        var nameEqExp = Expression.Call(nameExp, strContainsMethod, nameConvertExp);

        // 根据年龄范围查询 where age >= ? and age <= ?
        var minAgeExp = Expression.Property(parameterExpression, typeof(Student), "Age");
        Expression<Func<object>> minAgeValExp = () => 16;
        var ageGoeExp = Expression.GreaterThanOrEqual(
            minAgeExp, Expression.Convert(minAgeValExp.Body, minAgeExp.Type)
        );
        var maxAgeExp = Expression.Property(parameterExpression, typeof(Student), "Age");
        Expression<Func<object>> maxAgeValExp = () => 18;
        var ageLoeExp = Expression.LessThanOrEqual(
            maxAgeExp, Expression.Convert(maxAgeValExp.Body, maxAgeExp.Type)
        );
        var ageBetweenExp = Expression.AndAlso(ageGoeExp, ageLoeExp);

        // 拼接条件 where name = ? and (age >= ? and age <= ?)
        // var andCondition = Expression.AndAlso(nameEqExp, ageGoeExp);
        // 拼接条件 where name = ? or (age >= ? and age <= ?)
        var andCondition = Expression.OrElse(nameEqExp, ageBetweenExp);

        return schoolContext.Student?
            .Include(student => student.StudentFace)
            .Where(Expression.Lambda<Func<Student, bool>>(andCondition, parameterExpression))
            .OrderByDescending(student => student.Age)
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