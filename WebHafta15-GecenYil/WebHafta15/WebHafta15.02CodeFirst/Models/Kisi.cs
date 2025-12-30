namespace WebHafta15._02CodeFirst.Models
{
    public class Kisi
    {
        public int KisiId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public int DepartmanId { get; set; }

        public Departman KisiDepartmani { get; set; }


    }
}
