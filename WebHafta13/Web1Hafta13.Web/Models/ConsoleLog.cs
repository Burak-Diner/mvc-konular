namespace Web1Hafta13.Web.Models
{
    public class ConsoleLog : ILog
    {
        public int ClassId { get; set; }
        public ConsoleLog()
        {
            Random rnd = new Random();
            ClassId = rnd.Next(1, 100);

        }
        public void LogYaz()
        {
            Console.WriteLine($"Console ekranına Log yazıldı. ClassId={ClassId}");
        }
    }
}
