using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web1Hafta14.WebDbFirst.Models;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace Web1Hafta14.WebDbFirst.DbContext;

public partial class FinalSirketDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public FinalSirketDbContext()
    {
    }

    public FinalSirketDbContext(DbContextOptions<FinalSirketDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbDepartman> TbDepartmen { get; set; }

    public virtual DbSet<TbKisi> TbKisis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=FinalSirketDB;Trusted_Connection=yes; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbDepartman>(entity =>
        {
            entity.HasKey(e => e.DepartmanId);

            entity.ToTable("tb_Departman");

            entity.Property(e => e.DepartmanAdi).HasMaxLength(250);
        });

        modelBuilder.Entity<TbKisi>(entity =>
        {
            entity.HasKey(e => e.KisiId);

            entity.ToTable("tb_Kisi");

            entity.HasIndex(e => e.DepartmanId, "IX_tb_Kisi_DepartmanId");

            entity.Property(e => e.Adi).HasMaxLength(150);
            entity.Property(e => e.Soyadi).HasMaxLength(150);

            entity.HasOne(d => d.Departman).WithMany(p => p.TbKisis).HasForeignKey(d => d.DepartmanId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
