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

    public DbSet<API_BlobsOfGobs.OrderGob> OrderGobs { get; set; } = default!;

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
