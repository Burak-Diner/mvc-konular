using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ornek.Web.Helpers
{
    public static class OrnekHtmlHelpers
    {
        public static IHtmlContent OrnekTextBox(this IHtmlHelper helper, string name, string value, string placeholder)
        {
            return helper.TextBox(name, value, new
            {
                placeholder,
                @class = "form-control",
                style = "border:1px solid #198754;"
            });
        }
    }
}
