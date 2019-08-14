using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SpyStore.Mvc.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        // Pascal case gets translated into lower-kebab-case.
        // Can be passed via <email email-name="..." />. 
        public string EmailName { get; set; }
        public string EmailDomain { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag
            var address = EmailName + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }

    }
}
