﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StarTEDSystemDB.Entities;

[Index("SchoolCode", Name = "IX_SchoolCode")]
public partial class Program
{
    [Key]
    [Column("ProgramID")]
    public int ProgramId { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string ProgramName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string DiplomaName { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string SchoolCode { get; set; }

    [Column(TypeName = "money")]
    public decimal Tuition { get; set; }

    [Column(TypeName = "money")]
    public decimal InternationalTuition { get; set; }

    [InverseProperty("Program")]
    public virtual ICollection<ProgramCourse> ProgramCourses { get; set; } = new List<ProgramCourse>();
}