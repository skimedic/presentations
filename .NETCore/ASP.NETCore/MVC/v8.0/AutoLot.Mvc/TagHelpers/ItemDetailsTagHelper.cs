// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Mvc - ItemDetailsTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/10/30
// ==================================

namespace AutoLot.Mvc.TagHelpers;

public class ItemDetailsTagHelper : ItemLinkTagHelperBase
{
    public ItemDetailsTagHelper(
        IActionContextAccessor contextAccessor, 
        IUrlHelperFactory urlHelperFactory) 
        : base(contextAccessor, urlHelperFactory) 
    {
        ActionName = nameof(CarsController.Details); 
    }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        BuildContent(output,"text-info","Details","info-circle");
    }
}