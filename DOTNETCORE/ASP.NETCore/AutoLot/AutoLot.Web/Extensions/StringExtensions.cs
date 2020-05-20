using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoLot.Web.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveController(this string text) 
            => text.Replace("Controller", "");
    }
}
