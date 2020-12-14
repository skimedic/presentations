// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - ItemLinkTagHelperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Web.TagHelpers.Base
{
    public abstract class ItemLinkTagHelperBase : TagHelper
    {
        protected readonly IUrlHelper UrlHelper;
        public int? ItemId { get; set; }

        protected ItemLinkTagHelperBase(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            UrlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);
        }

        protected void BuildContent(TagHelperOutput output, 
            string pageName, string className, string displayText, string fontAwesomeName)
        {
            output.TagName = "a"; // Replaces <email> with <a> tag
            var target = (ItemId.HasValue)?UrlHelper.Page(pageName,new { id = ItemId }): UrlHelper.Page(pageName);
            output.Attributes.SetAttribute("href", target);
            output.Attributes.Add("class", className);
            output.Content.AppendHtml($@"{displayText} <i class=""fas fa-{fontAwesomeName}""></i>");
        }

    }
}