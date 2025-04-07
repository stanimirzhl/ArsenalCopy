using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Data.Models;

namespace Pharamcy.Data;

public partial class PharmacyDbContext : DbContext
{
    public PharmacyDbContext()
    {
    }

    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PAERF21\\SQLEXPRESS;Initial Catalog=PharmacyDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F9A91EB92");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicine__3213E83FBE2FC5E1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F6C325AF7");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasConstraintName("FK__Orders__employee__534D60F1");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Orders).HasConstraintName("FK__Orders__medicine__52593CB8");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3213E83F2CF90BD5");

            entity.HasOne(d => d.Employee).WithMany(p => p.Prescriptions).HasConstraintName("FK__Prescript__emplo__4F7CD00D");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Prescriptions).HasConstraintName("FK__Prescript__medic__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
