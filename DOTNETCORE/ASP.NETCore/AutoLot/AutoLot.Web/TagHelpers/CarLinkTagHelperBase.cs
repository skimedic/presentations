using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Web.TagHelpers
{
    public abstract class CarLinkTagHelperBase : TagHelper
    {
        protected readonly IUrlHelper UrlHelper;
        public int CarId { get; set; }

        protected CarLinkTagHelperBase(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            UrlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);
        }

        protected void BuildContent(TagHelperOutput output, 
            string actionName, string className, string displayText, string fontAwesomeName)
        {
            output.TagName = "a"; // Replaces <email> with <a> tag
            var target = UrlHelper.Action(actionName, "Cars", new {id = CarId});
            output.Attributes.SetAttribute("href", target);
            output.Attributes.Add("class",className);
            output.Content.AppendHtml($@"{displayText} <i class=""fas fa-{fontAwesomeName}""></i>");

        }

    }
}