using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Hafta06.Web.TagHelpers
{
    
    public class LogoTagHelper:TagHelper
    {
        public string Alt { get; set; }
        public bool Renkli { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            if (Renkli)
            {
                output.Attributes.Add("src", "/wwwroot/images/renklilogo.png");
                output.Attributes.Add("alt", "RenkliLogo");
            }
            else
            {
                output.Attributes.Add("src", "/wwwroot/images/siyahbeyazlogo.png");
                output.Attributes.Add("alt", "SiyahBeyazLogo");

            }
            
            output.Attributes.Add("class", "img-logo");

            base.Process(context, output);
        }
    }
}
