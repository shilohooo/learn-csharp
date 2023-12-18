using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldDbContext.Entities;

public partial class Grade
{
    [Key]
    public int GradeId { get; set; }

    public string GradeName { get; set; } = null!;

    public string Section { get; set; } = null!;

    [InverseProperty("CurrentGrade")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
