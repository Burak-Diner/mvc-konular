using Web1Hafta13.Web.Services;

namespace Web1Hafta13.Web.Models
{
    public class KisiModel
    {
        public int Id { get; set; }
        public string TCNo { get; set; }
        public string AdSoyad { get; set; }

        public MernisService _srv;

        public KisiModel(MernisService srv, string TCNo)
        {
            _srv = srv;
            this.TCNo = TCNo;
        }

        public void KisiBilgileriniYukle()
        {
            this.AdSoyad = _srv.KisiGetir(TCNo);
        }
    }
}
