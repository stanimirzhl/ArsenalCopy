using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pharamcy.Data.Models;

public partial class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("position")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Position { get; set; }

    [Column("salary", TypeName = "decimal(10, 2)")]
    public decimal? Salary { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Employee")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
