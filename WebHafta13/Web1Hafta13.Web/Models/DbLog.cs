namespace Web1Hafta13.Web.Models
{
    public class DbLog : ILog
    {
        public void LogYaz()
        {
            Console.WriteLine("Veritabanına Log yazıldı.");
        }
    }
}
