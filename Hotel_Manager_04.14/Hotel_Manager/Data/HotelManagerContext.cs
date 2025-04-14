using System;
using System.Collections.Generic;
using Hotel_Manager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Manager.Data;

public partial class HotelManagerContext : DbContext
{
    public HotelManagerContext()
    {
    }

    public HotelManagerContext(DbContextOptions<HotelManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=hotel_manager;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__guests__3213E83F8588813A");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83FAE7050E1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations).HasConstraintName("FK__reservati__guest__3F466844");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations).HasConstraintName("FK__reservati__room___3E52440B");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rooms__3213E83F97168D5C");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms).HasConstraintName("FK__rooms__room_type__3B75D760");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__room_typ__3213E83F8BCFFF6F");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
