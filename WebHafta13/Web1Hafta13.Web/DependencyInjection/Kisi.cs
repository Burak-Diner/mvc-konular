namespace Web1Hafta13.Web.DependencyInjection
{
    public class Kisi
    {
        public ITopluTasima _Itt { get; set; }
        public Kisi(ITopluTasima Itt)
        {
            this._Itt = Itt;
        }
    }
}
