namespace WebHafta05.Web.Models
{
    public class UrunViewModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public UrunViewModel()
        {
            
        }
        public UrunViewModel(int id, string adi, string aciklama,double fiyat)
        {
            this.Id = id;
            this.Adi = adi;
            this.Aciklama = aciklama;
            this.Fiyat = fiyat;
        }
    }
}
