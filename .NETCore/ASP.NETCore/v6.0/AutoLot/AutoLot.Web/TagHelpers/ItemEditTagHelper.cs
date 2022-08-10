// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - ItemEditTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Web.TagHelpers;

public class ItemEditTagHelper : ItemLinkTagHelperBase
{
    public ItemEditTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
        : base(contextAccessor, urlHelperFactory)
    {
        ActionName = "Edit";

    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        BuildContent(output,  "text-warning", "Edit", "edit");
    }
}
