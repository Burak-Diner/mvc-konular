using System.Linq;

namespace WebHafta07.Web.Models
{
    public class HaftaOzeti
    {
        public int HaftaNo { get; init; }
        public string Baslik { get; init; }
        public string OzAciklama { get; init; }
        public IReadOnlyList<string> Kazanimlar { get; init; }
        public string? IlgiliProje { get; init; }

        public HaftaOzeti(int haftaNo, string baslik, string ozAciklama, IEnumerable<string> kazanimlar, string? ilgiliProje = null)
        {
            HaftaNo = haftaNo;
            Baslik = baslik;
            OzAciklama = ozAciklama;
            Kazanimlar = kazanimlar.ToList();
            IlgiliProje = ilgiliProje;
        }
    }
}
