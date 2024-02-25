using Crud.Domain.Models;
using Crud.Domain.Services;
using Microsoft.IdentityModel.Tokens;

namespace Crud.EFCore.Services;

/// <summary>
/// 学生数据增删改查操作 Service
/// </summary>
public class StudentCrudService
{
    private readonly IDataService<Student> _studentService =
        new GenericDataService<Student>(new StudentDbContextFactory());

    /// <summary>
    /// 新增学生信息
    /// </summary>
    /// <param name="name">学生姓名</param>
    /// <param name="course">课程</param>
    /// <returns>新增后的学生信息</returns>
    /// <exception cref="Exception">学生姓名为空/新增失败</exception>
    public async Task<Student> Add(string name, string course)
    {
        try
        {
            if (name.IsNullOrEmpty())
            {
                throw new Exception("学生姓名不能为空:(");
            }

            return await _studentService.CreateAsync(new Student()
            {
                Name = name,
                Course = course
            });
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// 根据 ID 删除学生信息
    /// </summary>
    /// <param name="id">要删除的学生的 ID</param>
    /// <returns>删除成功返回 true，否则返回 false</returns>
    /// <exception cref="Exception">删除失败时</exception>
    public async Task<bool> DeleteById(int id)
    {
        try
        {
            var student = await _studentService.GetAsync(id);
            if (student == null)
            {
                return true;
            }

            await _studentService.DeleteAsync(student);
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// 更新学生信息
    /// </summary>
    /// <param name="id">学生 ID</param>
    /// <param name="name">学生姓名</param>
    /// <param name="course">课程</param>
    /// <returns>更新后的学生信息</returns>
    /// <exception cref="Exception">更新失败时</exception>
    public async Task<Student> Update(int id, string name, string course)
    {
        try
        {
            var student = await _studentService.GetAsync(id);
            student.Name = name;
            student.Course = course;
            return await _studentService.UpdateAsync(student);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// 获取所有记录
    /// </summary>
    /// <returns>学生列表</returns>
    /// <exception cref="Exception">查询出错时</exception>
    public async Task<ICollection<Student>> GetAll()
    {
        try
        {
            return await _studentService.GetAllAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// 根据姓名获取学生信息，支持左模糊查询
    /// </summary>
    /// <param name="name">学生姓名</param>
    /// <returns>学生信息列表</returns>
    /// <exception cref="Exception">查询出错时</exception>
    public async Task<ICollection<Student>> GetAllByName(string name)
    {
        try
        {
            var students = await GetAll();
            return students.Where(student => student.Name.StartsWith(name)).ToList();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// 根据 ID 获取学生信息
    /// </summary>
    /// <param name="id">学生 ID</param>
    /// <returns>学生信息</returns>
    /// <exception cref="Exception">查询出错时</exception>
    public async Task<Student> GetById(int id)
    {
        try
        {
            return await _studentService.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}