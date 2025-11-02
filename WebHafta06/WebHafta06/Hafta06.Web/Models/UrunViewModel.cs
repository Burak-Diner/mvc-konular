namespace Hafta06.Web.Models
{
    public class UrunViewModel
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyat { get; set; }

        public UrunViewModel()
        {
            
        }
        public UrunViewModel(int id, string adi, double fiyat)
        {
            this.UrunId = id;
            this.UrunAdi = adi;
            this.UrunFiyat = fiyat;
        }
    }
}
