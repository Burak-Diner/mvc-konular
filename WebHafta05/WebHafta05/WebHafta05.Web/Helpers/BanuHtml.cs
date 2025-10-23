using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHafta05.Web.Helpers
{
    public static class BanuHtml
    {
        public static IHtmlContent BanuTextBox(this IHtmlHelper helper, string name, string value, string placeholder)
        {
            return helper.TextBox(name, value, new
            {
                placeholder = placeholder,
                style = "background-color:green; color:white;",
                @class = "form-control"
            });
        }
    }
}
