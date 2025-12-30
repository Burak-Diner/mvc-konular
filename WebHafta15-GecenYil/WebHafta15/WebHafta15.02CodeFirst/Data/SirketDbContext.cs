using Microsoft.EntityFrameworkCore;
using WebHafta15._02CodeFirst.Models;

namespace WebHafta15._02CodeFirst.Data
{
    public class SirketDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=MUH13NOLUDERSLI;Database=FinalSirketDB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Kisi> Kisis { get; set; } 
        public DbSet<Departman> Departmans { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departman>().ToTable("tb_Departman");
            modelBuilder.Entity<Departman>().HasKey(a => a.DepartmanId);
            modelBuilder.Entity<Departman>().Property(a => a.DepartmanAdi).HasMaxLength(250);
            modelBuilder.Entity<Departman>().Property(a => a.DepartmanAdi).IsRequired(true);


            modelBuilder.Entity<Kisi>().ToTable("tb_Kisi");
            modelBuilder.Entity<Kisi>().HasKey(a=>a.KisiId);
            modelBuilder.Entity<Kisi>().Property(a=>a.Adi).HasMaxLength(150).IsRequired(true);
            modelBuilder.Entity<Kisi>().Property(a => a.Soyadi).HasMaxLength(150).IsRequired(true);
            modelBuilder.Entity<Kisi>().Property(a => a.DepartmanId).IsRequired(true);
            modelBuilder.Entity<Kisi>().HasOne(a=>a.KisiDepartmani)
                .WithMany(a=>a.DepartmanKisileri)
                .HasForeignKey(a=>a.DepartmanId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
