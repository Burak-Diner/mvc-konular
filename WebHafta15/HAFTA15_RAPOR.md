# Hafta 15 - Ders Özeti

## Yapılanlar
- Db-First yaklaşımıyla `EticaretDbContext` `Scaffold-DbContext` çıktısı olarak üretildi; ilişkiler `HasOne/WithMany` ve `HasForeignKey` ile korundu, bağlantı `UseSqlServer` ile sağlandı.
- Code-First tarafında `SirketDbContext` içinde tablo isimleri (`ToTable`), zorunlu alanlar (`IsRequired`) ve `HasOne/WithMany` ilişkileri manuel olarak tanımlandı, `add-migration` ve `update-database` ile şema oluşturma akışı pekiştirildi.
- Her iki örnekte de controller yönlendirmesi `MapControllerRoute` ile yapıldı ve DI için `AddControllersWithViews` kullanıldı.

## Öne Çıkan Kodlar
- Db-First modelde ilişkilerin otomatik tanımı:  
  ```csharp
  modelBuilder.Entity<SaticiUrun>(entity =>
  {
      entity.HasOne(d => d.Satici).WithMany(p => p.SaticiUruns)
          .HasForeignKey(d => d.SaticiId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SaticiUrun_Satici");

      entity.HasOne(d => d.Urun).WithMany(p => p.SaticiUruns)
          .HasForeignKey(d => d.UrunId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SaticiUrun_Urun");
  });
  ```
- Code-First modelde tablo adı ve kolon kısıtlamaları elle verildi:  
  ```csharp
  modelBuilder.Entity<Kisi>().ToTable("tb_Kisi");
  modelBuilder.Entity<Kisi>().HasKey(a => a.KisiId);
  modelBuilder.Entity<Kisi>().Property(a => a.Adi).HasMaxLength(150).IsRequired(true);
  modelBuilder.Entity<Kisi>().HasOne(a => a.KisiDepartmani)
      .WithMany(a => a.DepartmanKisileri)
      .HasForeignKey(a => a.DepartmanId);
  ```

## Detaylı Örnek: Sipariş Akışı (Db-First + Code-First)
Hafta 13-14 konularındaki DI, Db-First ve Code-First adımlarını birleştirerek aynı e-ticaret senaryosu için sipariş oluşturma akışı kurgulanabilir. Aşağıdaki örnek, var olan Db-First `EticaretDbContext` ve Code-First `SirketDbContext` yaklaşımlarından çıkmadan çalışır:

1) **Bağlamların DI ile kaydı** – Hafta 13'teki constructor injection mantığına uygun olarak iki DbContext de servislere eklenir, böylece controller veya servis sınıfları `ctor` üzerinden alabilir:  
   ```csharp
   builder.Services.AddDbContext<EticaretDbContext>(opt =>
       opt.UseSqlServer(builder.Configuration.GetConnectionString("Eticaret")));
   builder.Services.AddDbContext<SirketDbContext>(opt =>
       opt.UseSqlServer(builder.Configuration.GetConnectionString("FinalSirket")));
   ```
   `AddDbContext` yaşam süresi scoped olduğu için her HTTP isteğinde güvenli tek bir bağlam örneği üretir; bu, Hafta 13'teki `AddScoped` kullanımına denk gelir.

2) **Sipariş servisi** – Db-First modelinden `SaticiUrun` ve `Kullanici` verilerini `Include` ile yükleyip yeni `Sipari` kaydı ekler. `Include` yöntemi Hafta 14'teki navigation property pratikleriyle aynı mantığı kullanır:  
   ```csharp
   public class SiparisService
   {
       private readonly EticaretDbContext _db;
       public SiparisService(EticaretDbContext db) => _db = db;

       public async Task<int> SiparisOlusturAsync(int kullaniciId, int saticiUrunId, short adet)
       {
           var saticiUrun = await _db.SaticiUruns
               .Include(su => su.Urun)
               .FirstOrDefaultAsync(su => su.SaticiUrunId == saticiUrunId);

           var siparis = new Sipari
           {
               KullaniciId = kullaniciId,
               AdresId = _db.Adres.First(a => a.KullaniciId == kullaniciId).AdresId,
               SiparisTarihi = DateTime.Now,
               SiparisUruns =
               {
                   new SiparisUrun { SatUrunId = saticiUrunId, Adet = adet, Fiyat = saticiUrun.Fiyat }
               }
           };

           _db.Siparis.Add(siparis);
           await _db.SaveChangesAsync();
           return siparis.SiparisId;
       }
   }
   ```
   - `Include` ile ürün adı ve fiyatını navigation üzerinden çekip Hafta 14'teki ilişkili veri okuma tekniği korunur.
   - `Add` ve `SaveChangesAsync` doğrudan DbSet üzerinden çalışır; bu da Hafta 14 CRUD örnekleriyle uyumlu.

3) **Personel tarafı için Code-First raporu** – Siparişi hazırlayan personelin bağlı olduğu departmanı Code-First bağlamından okur. `HasOne/WithMany` ile kurulan ilişkiyi kullanıp projection ile sade DTO döner:  
   ```csharp
   public class PersonelRaporService
   {
       private readonly SirketDbContext _db;
       public PersonelRaporService(SirketDbContext db) => _db = db;

       public IEnumerable<object> DepartmanBazliSayim()
       {
           return _db.Departmans
               .Select(dep => new
               {
                   dep.DepartmanAdi,
                   KisiSayisi = dep.DepartmanKisileri.Count
               })
               .ToList();
       }
   }
   ```
   - `Select` ve `Count` ile LINQ tarafı Code-First tablolarına uygulanır; Hafta 13'te DI ile alınan servis gibi scoped çalışır.

4) **Controller entegrasyonu** – Hafta 13'teki constructor injection örneklerini izleyerek iki servisi de controller'a eklemek yeterlidir:  
   ```csharp
   public class SiparisController : Controller
   {
       private readonly SiparisService _siparisService;
       private readonly PersonelRaporService _raporService;
       public SiparisController(SiparisService siparisService, PersonelRaporService raporService)
       {
           _siparisService = siparisService;
           _raporService = raporService;
       }

       public async Task<IActionResult> Yeni(int kullaniciId, int saticiUrunId, short adet)
       {
           var siparisId = await _siparisService.SiparisOlusturAsync(kullaniciId, saticiUrunId, adet);
           var departmanRaporu = _raporService.DepartmanBazliSayim();
           return View((siparisId, departmanRaporu));
       }
   }
   ```
   Controller sadece servisleri çağırdığı için Hafta 13-14'teki katmanlı mimari ve DI prensiplerine sadık kalınır.

Bu örnek, haftalar boyunca kullanılan `AddDbContext`, `Include`, `HasOne/WithMany`, `Add/SaveChanges`, `Select` gibi yöntemleri tekrar ederek hem Db-First hem Code-First kurulumlarının aynı projede nasıl kullanılabileceğini gösterir.
