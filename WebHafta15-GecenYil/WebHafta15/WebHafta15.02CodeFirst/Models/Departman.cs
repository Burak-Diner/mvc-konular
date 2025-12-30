namespace WebHafta15._02CodeFirst.Models
{
    public class Departman
    {
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }

        public List<Kisi> DepartmanKisileri { get; set; }
    }
}
