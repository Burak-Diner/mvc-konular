using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebHafta15._01DbFirst.Models;

namespace WebHafta15._01DbFirst.Data;

public partial class EticaretDbContext : DbContext
{
    public EticaretDbContext()
    {
    }

    public EticaretDbContext(DbContextOptions<EticaretDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adre> Adres { get; set; }

    public virtual DbSet<Ilce> Ilces { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<KategoriOzellik> KategoriOzelliks { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<Mahalle> Mahalles { get; set; }

    public virtual DbSet<Ozellik> Ozelliks { get; set; }

    public virtual DbSet<Satici> Saticis { get; set; }

    public virtual DbSet<SaticiUrun> SaticiUruns { get; set; }

    public virtual DbSet<Sehir> Sehirs { get; set; }

    public virtual DbSet<SepetUrun> SepetUruns { get; set; }

    public virtual DbSet<Sipari> Siparis { get; set; }

    public virtual DbSet<SiparisUrun> SiparisUruns { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<UrunOzellik> UrunOzelliks { get; set; }

    public virtual DbSet<Yorum> Yorums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MUH13NOLUDERSLI;Database=ETicaretDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adre>(entity =>
        {
            entity.HasKey(e => e.AdresId);

            entity.Property(e => e.AdSoyad).HasMaxLength(250);
            entity.Property(e => e.AdresSatir1).HasMaxLength(500);
            entity.Property(e => e.AdresSatir2).HasMaxLength(500);
            entity.Property(e => e.Cep).HasMaxLength(20);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Adres)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adres_Kullanici");

            entity.HasOne(d => d.Mah).WithMany(p => p.Adres)
                .HasForeignKey(d => d.MahId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adres_Mahalle");
        });

        modelBuilder.Entity<Ilce>(entity =>
        {
            entity.ToTable("Ilce");

            entity.Property(e => e.IlceAdi).HasMaxLength(500);

            entity.HasOne(d => d.Sehir).WithMany(p => p.Ilces)
                .HasForeignKey(d => d.SehirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ilce_Sehir");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.ToTable("Kategori");

            entity.Property(e => e.KategoriAdi).HasMaxLength(250);

            entity.HasOne(d => d.UstKategori).WithMany(p => p.InverseUstKategori)
                .HasForeignKey(d => d.UstKategoriId)
                .HasConstraintName("FK_Kategori_Kategori");
        });

        modelBuilder.Entity<KategoriOzellik>(entity =>
        {
            entity.HasKey(e => e.KategoriOzellikId).HasName("PK_KategoriOZellik");

            entity.ToTable("KategoriOzellik");

            entity.HasOne(d => d.Kategori).WithMany(p => p.KategoriOzelliks)
                .HasForeignKey(d => d.KategoriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KategoriOZellik_Kategori");

            entity.HasOne(d => d.Ozellik).WithMany(p => p.KategoriOzelliks)
                .HasForeignKey(d => d.OzellikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KategoriOZellik_Ozellik");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");

            entity.Property(e => e.AdSoyad).HasMaxLength(250);
            entity.Property(e => e.Mail).HasMaxLength(250);
            entity.Property(e => e.MailKodu).HasMaxLength(6);
            entity.Property(e => e.Sifre).HasMaxLength(50);
        });

        modelBuilder.Entity<Mahalle>(entity =>
        {
            entity.ToTable("Mahalle");

            entity.Property(e => e.MahalleAdi).HasMaxLength(500);
            entity.Property(e => e.MahallePostaKodu).HasMaxLength(10);

            entity.HasOne(d => d.Ilce).WithMany(p => p.Mahalles)
                .HasForeignKey(d => d.IlceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mahalle_Ilce");
        });

        modelBuilder.Entity<Ozellik>(entity =>
        {
            entity.ToTable("Ozellik");

            entity.Property(e => e.OzellikAdi).HasMaxLength(500);
        });

        modelBuilder.Entity<Satici>(entity =>
        {
            entity.ToTable("Satici");

            entity.Property(e => e.SaticiAdi).HasMaxLength(500);
            entity.Property(e => e.SaticiAdres).HasMaxLength(500);
            entity.Property(e => e.SaticiMahId).HasColumnName("SaticiMahID");

            entity.HasOne(d => d.SaticiMah).WithMany(p => p.Saticis)
                .HasForeignKey(d => d.SaticiMahId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Satici_Mahalle");
        });

        modelBuilder.Entity<SaticiUrun>(entity =>
        {
            entity.ToTable("SaticiUrun");

            entity.Property(e => e.Fiyat).HasColumnType("money");

            entity.HasOne(d => d.Satici).WithMany(p => p.SaticiUruns)
                .HasForeignKey(d => d.SaticiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaticiUrun_Satici");

            entity.HasOne(d => d.Urun).WithMany(p => p.SaticiUruns)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaticiUrun_Urun");
        });

        modelBuilder.Entity<Sehir>(entity =>
        {
            entity.ToTable("Sehir");

            entity.Property(e => e.SehirAdi).HasMaxLength(250);
        });

        modelBuilder.Entity<SepetUrun>(entity =>
        {
            entity.ToTable("SepetUrun");

            entity.HasOne(d => d.SaticiUrun).WithMany(p => p.SepetUruns)
                .HasForeignKey(d => d.SaticiUrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SepetUrun_SaticiUrun");

            entity.HasOne(d => d.SepetKullanici).WithMany(p => p.SepetUruns)
                .HasForeignKey(d => d.SepetKullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SepetUrun_Kullanici");
        });

        modelBuilder.Entity<Sipari>(entity =>
        {
            entity.HasKey(e => e.SiparisId);

            entity.Property(e => e.SiparisTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Adres).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.AdresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siparis_Siparis");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Siparis_Kullanici");
        });

        modelBuilder.Entity<SiparisUrun>(entity =>
        {
            entity.ToTable("SiparisUrun");

            entity.HasOne(d => d.SatUrun).WithMany(p => p.SiparisUruns)
                .HasForeignKey(d => d.SatUrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SiparisUrun_SaticiUrun");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisUruns)
                .HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SiparisUrun_Siparis");
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.ToTable("Urun");

            entity.Property(e => e.UrunAdi).HasMaxLength(500);

            entity.HasOne(d => d.Kat).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.KatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Urun_Kategori");
        });

        modelBuilder.Entity<UrunOzellik>(entity =>
        {
            entity.ToTable("UrunOzellik");

            entity.Property(e => e.OzellikIcerik).HasMaxLength(500);

            entity.HasOne(d => d.Ozellik).WithMany(p => p.UrunOzelliks)
                .HasForeignKey(d => d.OzellikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UrunOzellik_Ozellik");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunOzelliks)
                .HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UrunOzellik_Urun");
        });

        modelBuilder.Entity<Yorum>(entity =>
        {
            entity.ToTable("Yorum");

            entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");
            entity.Property(e => e.Tarih).HasColumnType("datetime");
            entity.Property(e => e.YorumMetin).HasMaxLength(500);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Yorums)
                .HasForeignKey(d => d.KullaniciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yorum_Kullanici");

            entity.HasOne(d => d.SaticiUrun).WithMany(p => p.Yorums)
                .HasForeignKey(d => d.SaticiUrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yorum_Yorum");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
