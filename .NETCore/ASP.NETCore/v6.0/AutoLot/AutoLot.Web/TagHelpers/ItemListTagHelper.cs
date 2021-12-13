namespace AutoLot.Web.TagHelpers;

public class ItemListTagHelper : ItemLinkTagHelperBase
{
    public ItemListTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory)
        : base(contextAccessor, urlHelperFactory)
    {
        ActionName = "Index";

    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        BuildContent(output,  "text-default", "Back to List", "list");
    }
}
