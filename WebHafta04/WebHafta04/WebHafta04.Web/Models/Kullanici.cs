namespace WebHafta04.Web.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }  
        public string KullaniciAdi { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciSifre { get; set; }

        public Kullanici()
        {
            
        }
        public Kullanici(int id, string adi, string email, string sifre)
        {
            KullaniciId = id;
            KullaniciAdi = adi;
            KullaniciEmail = email;
            KullaniciSifre = sifre;
            
        }

    }
}
