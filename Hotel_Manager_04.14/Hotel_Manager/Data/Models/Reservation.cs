using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager.Data.Models;

[Table("reservations")]
public partial class Reservation
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("accommodation_date")]
    public DateOnly AccommodationDate { get; set; }

    [Column("release_date")]
    public DateOnly ReleaseDate { get; set; }

    [Column("days")]
    public int Days { get; set; }

    [Column("room_id")]
    public int? RoomId { get; set; }

    [Column("guest_id")]
    public int? GuestId { get; set; }

    [ForeignKey("GuestId")]
    [InverseProperty("Reservations")]
    public virtual Guest? Guest { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("Reservations")]
    public virtual Room? Room { get; set; }
}
