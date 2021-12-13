namespace AutoLot.Web.TagHelpers.Base;

public abstract class ItemLinkTagHelperBase : TagHelper
{
    protected readonly IUrlHelper UrlHelper;
    public int? ItemId { get; set; }
    private readonly string _pageName;
    protected string ActionName { get; set; }

    protected ItemLinkTagHelperBase(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
    {
        UrlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext);
        _pageName = contextAccessor.ActionContext.ActionDescriptor.RouteValues["page"]?.Split("/",StringSplitOptions.RemoveEmptyEntries)[0];
    }

    protected void BuildContent(TagHelperOutput output,
        string cssClassName, string displayText, string fontAwesomeName)
    {
        output.TagName = "a"; 
        var target = (ItemId.HasValue) ? UrlHelper.Page($"/{_pageName}/{ActionName}", new { id = ItemId }) : UrlHelper.Page($"/{_pageName}/{ActionName}");
        output.Attributes.SetAttribute("href", target);
        output.Attributes.Add("class", cssClassName);
        output.Content.AppendHtml($@"{displayText} <i class=""fas fa-{fontAwesomeName}""></i>");
    }

}
