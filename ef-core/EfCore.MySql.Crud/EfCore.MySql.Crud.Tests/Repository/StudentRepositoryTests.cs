using System;
using EfCore.MySql.Crud.Constant;
using EfCore.MySql.Crud.Context;
using EfCore.MySql.Crud.Factory;
using EfCore.MySql.Crud.Model;
using EfCore.MySql.Crud.Repository;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EfCore.MySql.Crud.Tests.Repository;

/// <summary>
/// 学生信息仓储单元测试
/// </summary>
[TestClass]
[TestSubject(typeof(StudentRepository))]
public class StudentRepositoryTests
{
    private SchoolContext _schoolContext;
    private StudentRepository _studentRepository;

    /// <summary>
    /// 测试初始化
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        Console.WriteLine("测试初始化...");
        _schoolContext = new SchoolContext(ConfigurationFactory.BuildConfigFromJsonFile());
        _schoolContext.Database.EnsureCreated();
        _studentRepository = new StudentRepository(_schoolContext);
    }

    /// <summary>
    /// 测试新增学生信息
    /// </summary>
    [TestMethod]
    public void Save_IdShouldNotBeNull()
    {
        var student = _studentRepository.Save(new Student
        {
            Name = "赵六",
            Sex = StudentConstants.Sex.男,
            Age = 18,
            StuNo = "10104",
            Mobile = "13025715377",
            StudentFace = new StudentFace
            {
                FilePath = "student/faces/赵六.jpg"
            }
        });
        Assert.IsNotNull(student.Id);
    }

    /// <summary>
    /// 测试根据 ID 删除学生信息
    /// </summary>
    [TestMethod]
    public void DeleteById_ShouldBeSucceed_WhenStudentIdExist()
    {
        const long id = 5L;
        _studentRepository.DeleteById(id);
        var deletedStudent = _studentRepository.FindById(id);
        Assert.IsNull(deletedStudent);
    }

    /// <summary>
    /// 测试查询所有学生信息
    /// </summary>
    [TestMethod]
    public void FindAll_ShouldNotBeEmpty()
    {
        var students = _studentRepository.FindAll();
        Assert.IsNotNull(students);
        Assert.IsTrue(students.Count > 0);
    }

    /// <summary>
    /// 测试根据 ID 查询学生信息
    /// </summary>
    [TestMethod]
    public void FindById_ShouldNotBeNull()
    {
        var student = _studentRepository.FindById(7);
        Assert.IsNotNull(student);
        Assert.IsNotNull(student.StudentFace);
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    [TestCleanup]
    public void Destroy()
    {
        _schoolContext.Dispose();
    }
}