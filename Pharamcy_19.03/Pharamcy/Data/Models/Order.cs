using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pharamcy.Data.Models;

public partial class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("medicine_id")]
    public int? MedicineId { get; set; }

    [Column("supplier_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string SupplierName { get; set; } = null!;

    [Column("order_date")]
    public DateOnly OrderDate { get; set; }

    [Column("quantity_ordered")]
    public int QuantityOrdered { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Orders")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("MedicineId")]
    [InverseProperty("Orders")]
    public virtual Medicine? Medicine { get; set; }
}
