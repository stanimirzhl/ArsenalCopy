using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pharamcy.Data.Models;

[Index("Name", Name = "UQ__Medicine__72E12F1B32BB5A1F", IsUnique = true)]
public partial class Medicine
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("manufacturer")]
    [StringLength(100)]
    [Unicode(false)]
    public string Manufacturer { get; set; } = null!;

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("quantity_in_stock")]
    public int QuantityInStock { get; set; }

    [InverseProperty("Medicine")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Medicine")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
