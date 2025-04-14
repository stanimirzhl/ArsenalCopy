using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager.Data.Models;

[Table("room_types")]
public partial class RoomType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("description")]
    [StringLength(80)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("max_capacity")]
    public int MaxCapacity { get; set; }

    [InverseProperty("RoomType")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
