// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - ItemLinkTagHelperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Web.TagHelpers.Base;

public abstract class ItemLinkTagHelperBase(
    IActionContextAccessor contextAccessor,
    IUrlHelperFactory urlHelperFactory) : TagHelper
{
    protected readonly IUrlHelper UrlHelper =
        urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);

    public int? ItemId { get; set; }
    private readonly string _pageName = 
        contextAccessor.ActionContext.ActionDescriptor
            .RouteValues["page"]?.Split("/",StringSplitOptions.RemoveEmptyEntries)[0];
    protected string ActionName { get; set; }

    protected void BuildContent(TagHelperOutput output,
        string cssClassName, string displayText, string fontAwesomeName)
    {
        output.TagName = "a"; 
        var target = ItemId.HasValue
            ? UrlHelper.Page($"/{_pageName}/{ActionName}", new { id = ItemId }) 
            : UrlHelper.Page($"/{_pageName}/{ActionName}");
        output.Attributes.SetAttribute("href", target);
        output.Attributes.Add("class", cssClassName);
        output.Content.AppendHtml($@"{displayText} <i class=""fa-solid fa-{fontAwesomeName}""></i>");
    }
}
