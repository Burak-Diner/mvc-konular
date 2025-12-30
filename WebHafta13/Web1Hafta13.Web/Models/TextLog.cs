namespace Web1Hafta13.Web.Models
{
    public class TextLog : ILog
    {
        public void LogYaz()
        {
            Console.WriteLine("Text dosyasına Log yazıldı");
        }
    }
}
