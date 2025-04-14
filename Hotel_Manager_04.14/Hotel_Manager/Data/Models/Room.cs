using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager.Data.Models;

[Table("rooms")]
public partial class Room
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("number")]
    public int Number { get; set; }

    [Column("status")]
    [StringLength(15)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("room_type_id")]
    public int? RoomTypeId { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [ForeignKey("RoomTypeId")]
    [InverseProperty("Rooms")]
    public virtual RoomType? RoomType { get; set; }
}
