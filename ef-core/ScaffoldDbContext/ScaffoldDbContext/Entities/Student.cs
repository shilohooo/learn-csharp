using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldDbContext.Entities;

[Index("CurrentGradeId", Name = "IX_Students_CurrentGradeId")]
public partial class Student
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CurrentGradeId { get; set; }

    [ForeignKey("CurrentGradeId")]
    [InverseProperty("Students")]
    public virtual Grade CurrentGrade { get; set; } = null!;
}
