namespace Web1Hafta10.Web.Models
{
	public class Urun
	{
		public int UrunId { get; set; }
		public string UrunAdi { get; set; }
		public string UrunAciklama { get; set; }
		public double UrunFiyat { get; set; }

		public Urun()
		{
			
		}

		public Urun(int id, string adi, string aciklama, double fiyat)
		{
			this.UrunId = id;
			this.UrunAdi = adi;
			this.UrunAciklama = aciklama;
			this.UrunFiyat = fiyat;
		}
	}
}
