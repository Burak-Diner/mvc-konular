namespace Web1Hafta12.Web.Middlewares
{
    public class BanuMiddleware
    {
        public RequestDelegate _next;
        public BanuMiddleware(RequestDelegate next)
        {
           _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("BANÜ Middleware başladı.");
            await _next(context);
            Console.WriteLine("BANÜ middleware bitti.");

        }
    }
}
