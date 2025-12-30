using Web1Hafta12.Web.Middlewares;

namespace Web1Hafta12.Web.Extensions
{
    public static class BanuExtension
    {
        public static IApplicationBuilder UseBanu(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BanuMiddleware>();
        }
    }
}
