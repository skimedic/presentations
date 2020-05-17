using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoLot.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Web.TagHelpers
{
    public class EditCarTagHelper : CarLinkTagHelperBase
    {
        public EditCarTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output,nameof(CarsController.Edit),"text-warning","Edit","edit");
        }
    }
}