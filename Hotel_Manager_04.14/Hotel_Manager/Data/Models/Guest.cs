using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager.Data.Models;

[Table("guests")]
[Index("Ucn", Name = "UQ__guests__C5B186D2441210C0", IsUnique = true)]
public partial class Guest
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(20)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(30)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("UCN")]
    [StringLength(10)]
    [Unicode(false)]
    public string Ucn { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [InverseProperty("Guest")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
