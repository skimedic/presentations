// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - ItemCreateTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using AutoLot.Mvc.Controllers;
using AutoLot.Mvc.TagHelpers.Base;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AutoLot.Mvc.TagHelpers
{
    public class ItemCreateTagHelper : ItemLinkTagHelperBase
    {
        public ItemCreateTagHelper(IActionContextAccessor contextAccessor, IUrlHelperFactory urlHelperFactory) 
            : base(contextAccessor, urlHelperFactory) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildContent(output,nameof(CarsControllerApi.Create),"text-success","Create New","plus");
        }
    }
}