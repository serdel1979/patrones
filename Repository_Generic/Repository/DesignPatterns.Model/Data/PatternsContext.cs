using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Model.Data;

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
    //    => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=patterns;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.BeerId).HasName("Beer_pkey");

            entity.ToTable("Beer");

            entity.Property(e => e.BeerId).HasDefaultValueSql("nextval('beer_beerid_seq'::regclass)");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Style).HasMaxLength(50);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("Brand_pkey");

            entity.ToTable("Brand");

            entity.Property(e => e.BrandId).HasDefaultValueSql("nextval('brand_brandid_seq'::regclass)");
            entity.Property(e => e.Name).HasMaxLength(50);
        });
        modelBuilder.HasSequence("beer_beerid_seq");
        modelBuilder.HasSequence("brand_brandid_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
