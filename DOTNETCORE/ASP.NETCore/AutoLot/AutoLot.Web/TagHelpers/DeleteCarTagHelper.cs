using AutoLot.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Web.TagHelpers
{
    public class DeleteCarTagHelper : CarLinkTagHelperBase
    {
        public DeleteCarTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //    <a asp-action="Details" asp-route-id="@item.Id" class="text-info">Details <i class="fas fa-info-circle"></i></a>&nbsp;&nbsp;|&nbsp;&nbsp;
            BuildContent(output,nameof(CarsController.Delete),"text-danger","Delete","trash");
        }
    }
    public class CarDetailsTagHelper : CarLinkTagHelperBase
    {
        public CarDetailsTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output,nameof(CarsController.Details),"text-info","Details","info-circle");
        }
    }
}