namespace WebHafta02.Web.Models
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public double UrunFiyati { get; set; }

        public Urun(int urunId, string urunAdi, double urunFiyati)
        {
            UrunId = urunId;
            UrunAdi = urunAdi;
            UrunFiyati = urunFiyati;
        }
    }
}
