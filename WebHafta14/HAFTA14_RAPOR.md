# Hafta 14 - Ders Özeti

## Yapılanlar
- EF Core Db-First yaklaşımıyla mevcut `FinalSirketDB` veritabanından `TbKisi` ve `TbDepartman` modelleri üretildi.
- `FinalSirketDbContext` bağlamı `AddScoped` ile DI'a eklendi ve `UseSqlServer` bağlantısı `OnConfiguring` içinde yapılandırıldı.
- `KisiController` ve `DepartmanController` üzerinden CRUD örnekleri (ekle, düzenle, sil) çalıştırıldı ve değişiklikler `SaveChanges()` ile kaydedildi.

## Öne Çıkan Kodlar
- DbContext tanımı ve tablo eşlemeleri:  
  ```csharp
  public partial class FinalSirketDbContext : DbContext
  {
      public virtual DbSet<TbDepartman> TbDepartmen { get; set; }
      public virtual DbSet<TbKisi> TbKisis { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlServer("Server=.;Database=FinalSirketDB;Trusted_Connection=yes; TrustServerCertificate=True;");

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<TbKisi>(entity =>
          {
              entity.HasOne(d => d.Departman).WithMany(p => p.TbKisis).HasForeignKey(d => d.DepartmanId);
          });
      }
  }
  ```
- DbContext DI kaydı ve varsayılan rota:  
  ```csharp
  builder.Services.AddScoped<FinalSirketDbContext, FinalSirketDbContext>();
  app.MapDefaultControllerRoute();
  ```
- `KisiController` CRUD aksiyonları doğrudan DbSet üzerinde çalışıyor:  
  ```csharp
  public IActionResult Ekle()
  {
      TbKisi kisi = new() { Adi = "Süleyman Gökhan", Soyadi = "TAŞKIN", DepartmanId = 1 };
      _db.TbKisis.Add(kisi);
      _db.SaveChanges();
      return View(kisi);
  }

  public IActionResult Duzenle(int id)
  {
      TbKisi kisi = _db.TbKisis.FirstOrDefault(a => a.KisiId == id);
      kisi.Soyadi = "Taşkın";
      _db.SaveChanges();
      return View();
  }
  ```

## Benzer Örnek: İlişkili Veri Listeleme ve Include
- Departmanla birlikte kişi listesini göstermek için `Include` kullanılabilir:  
  ```csharp
  public IActionResult Liste()
  {
      var kisiler = _db.TbKisis.Include(k => k.Departman).ToList();
      return View(kisiler);
  }
  ```
- Razor tarafında ilişkili alan doğrudan okunur:  
  ```cshtml
  @model IEnumerable<TbKisi>
  <table>
    @foreach (var kisi in Model)
    {
        <tr>
            <td>@kisi.Adi @kisi.Soyadi</td>
            <td>@kisi.Departman.DepartmanAdi</td>
        </tr>
    }
  </table>
  ```
- Böylece Hafta 14'teki Db-First kurulum, listeleme ve navigation property kullanımıyla pratik bir CRUD ekranına dönüştürülebilir.
