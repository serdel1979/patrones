using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Patterns.UnitOW.Entities;

public partial class PatternsContext : DbContext
{
    public PatternsContext()
    {
    }

    public PatternsContext(DbContextOptions<PatternsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
   //     => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=patterns;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.BeerId).HasName("Beer_pkey");

            entity.ToTable("Beer");

            entity.HasIndex(e => e.BeerId, "Beer_new_beerid_key").IsUnique();

            entity.HasIndex(e => e.BrandId, "fki_beer_brandid");

            entity.Property(e => e.BeerId).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Style).HasMaxLength(50);

            entity.HasOne(d => d.Brand).WithMany(p => p.Beers)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("beer_brandid");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("Brand_pkey");

            entity.ToTable("Brand");

            entity.HasIndex(e => e.BrandId, "Brand_new_brandid_key").IsUnique();

            entity.Property(e => e.BrandId).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.Name).HasMaxLength(50);
        });
        modelBuilder.HasSequence("beer_beerid_seq");
        modelBuilder.HasSequence("brand_brandid_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
