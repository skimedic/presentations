#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ProductService.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.Generic;
using WPF.Models;

namespace WPF
{
    public class ProductService
    {
        public IList<Product> GetProducts() => new List<Product>
               {
                   new Product
                   {
                       ID = 1,
                       ModelName = "Foo",
                       Price = 25.00M,
                       SalePrice = 25.00M,
                       Inventory = 50,
                       SKU = "1234567890"
                   },
                   new Product
                   {
                       ID = 2,
                       ModelName = "Bar",
                       Price = 15.00M,
                       SalePrice = 15.00M,
                       Inventory = 10,
                       SKU = "ABCEDFGHIJKLMNOP"
                   }
               };
    }
}
