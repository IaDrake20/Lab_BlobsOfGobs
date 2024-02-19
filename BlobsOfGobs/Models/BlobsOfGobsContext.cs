using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_BlobsOfGobs;

namespace API_BlobsOfGobs.Models;

public partial class BlobsOfGobsContext : DbContext
{
    public BlobsOfGobsContext()
    {
    }

    public BlobsOfGobsContext(DbContextOptions<BlobsOfGobsContext> options)
        : base(options)
    {
    }

    public DbSet<API_BlobsOfGobs.Customers> Customers { get; set; } = default!;

    public DbSet<API_BlobsOfGobs.GobFlavors> GobFlavors { get; set; } = default!;

    public DbSet<API_BlobsOfGobs.Orders> Orders { get; set; } = default!;

    

    public virtual DbSet<OrderGob> OrderGobs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_People");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GobFlavor>(entity =>
        {
            entity.HasKey(e => e.FlavorId).HasName("PK__GobFlavo__0B05D02F7ADD87ED");

            entity.Property(e => e.FlavorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FlavorID");
            entity.Property(e => e.FlavorName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Orders");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<OrderGob>(entity =>
        {
            entity.HasKey(e => e.OrderGobId).HasName("PK__OrderGob__OrderGobID");

            entity.ToTable("OrderGob");

            entity.HasIndex(e => new { e.FlavorId, e.OrderId }, "UqOrderGob").IsUnique();

            entity.Property(e => e.OrderGobId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OrderGobID");
            entity.Property(e => e.FlavorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FlavorID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("OrderID");

            entity.HasOne(d => d.Flavor).WithMany(p => p.OrderGobs)
                .HasForeignKey(d => d.FlavorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderGob__Flavor__17F790F9");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderGobs)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderGob__OrderI__18EBB532");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
