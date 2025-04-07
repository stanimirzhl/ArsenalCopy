using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pharamcy.Data.Models;

public partial class Prescription
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("medicine_id")]
    public int? MedicineId { get; set; }

    [Column("doctor_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string DoctorName { get; set; } = null!;

    [Column("patient_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string PatientName { get; set; } = null!;

    [Column("date_issued")]
    public DateOnly DateIssued { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Prescriptions")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("MedicineId")]
    [InverseProperty("Prescriptions")]
    public virtual Medicine? Medicine { get; set; }
}
