using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ornek.Web.TagHelpers
{
    [HtmlTargetElement("okul-logo")] 
    public class LogoTagHelper : TagHelper
    {
        public string Metin { get; set; } = "BANÜ";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "p-3 border rounded bg-light text-center mb-3");
            output.Content.SetHtmlContent($"<strong>{Metin}</strong> Yazılım Mühendisliği");
        }
    }
}
