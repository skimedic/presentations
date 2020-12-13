// Copyright Information
// ==================================
// AutoLot50 - AutoLot.Mvc - ItemLinkTagHelperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using AutoLot.Mvc.Controllers;
using AutoLot.Services.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Mvc.TagHelpers.Base
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
            string actionName, string className, string displayText, string fontAwesomeName)
        {
            output.TagName = "a"; // Replaces <email> with <a> tag
            var target = (ItemId.HasValue)
                ? UrlHelper.Action(actionName, nameof(CarsController).RemoveController(), new {id = ItemId})
                : UrlHelper.Action(actionName, nameof(CarsController).RemoveController());
            output.Attributes.SetAttribute("href", target);
            output.Attributes.Add("class",className);
            output.Content.AppendHtml($@"{displayText} <i class=""fas fa-{fontAwesomeName}""></i>");
        }
    }
}