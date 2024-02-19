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

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Order1);

            entity.Property(e => e.Order1)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("Order");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<API_BlobsOfGobs.Orders> Order { get; set; } = default!;

public DbSet<API_BlobsOfGobs.Customers> Customer { get; set; } = default!;

public DbSet<API_BlobsOfGobs.GobFlavors> Gob { get; set; } = default!;

public DbSet<API_BlobsOfGobs.OrderGob> OrderGob { get; set; } = default!;
}
