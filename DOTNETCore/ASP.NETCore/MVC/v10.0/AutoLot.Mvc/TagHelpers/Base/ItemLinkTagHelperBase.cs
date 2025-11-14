// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Mvc - ItemLinkTagHelperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/03
// ==================================

namespace AutoLot.Mvc.TagHelpers.Base;

public abstract class ItemLinkTagHelperBase(
    IActionContextAccessor contextAccessor,
    IUrlHelperFactory urlHelperFactory) : TagHelper
{
    protected readonly IUrlHelper UrlHelper
        = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);

    private readonly string _controllerName
        = contextAccessor.ActionContext.ActionDescriptor.RouteValues["controller"];

    public int? ItemId { get; set; }
    protected string ActionName { get; set; }

    protected void BuildContent(
        TagHelperOutput output, string cssClassName, string displayText, string fontAwesomeName)
    {
        output.TagName = "a"; // Replaces <email> with <a> tag
        var target = (ItemId.HasValue)
            ? UrlHelper.Action(ActionName, _controllerName, new { id = ItemId })
            : UrlHelper.Action(ActionName, _controllerName);
        output.Attributes.SetAttribute("href", target);
        output.Attributes.Add("class", cssClassName);
        output.Content.AppendHtml($@"{displayText} <i class=""fa-solid fa-{fontAwesomeName}""></i>");
    }
}
