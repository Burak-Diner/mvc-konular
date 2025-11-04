namespace Ornek.Web.Models
{
    public class KullaniciViewModel
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Eposta { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
    }
}
