#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Passing_In_Multiple_Parameters_To_The_Product_List_Change_Notification_Converter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.Generic;
using System.Globalization;
using Machine.Specifications;
using WPF.Models;
using WPF.Samples.C_ChangeNotification.Converters;
using Xunit;

namespace WPFTests.C_ChangeNotification.Converters
{
    [Subject("ChangeNotification"), Tags("ChangeNotification")]
    public class When_Passing_In_Multiple_Parameters_To_The_Product_List_Change_Notification_Converter
    {
        static ProductListChangeNotificationMultiConverter converter;
        static IList<Product> products;
        static ProductListChangeNotificationParameter param;
        Establish context = () =>
        {
            converter = new ProductListChangeNotificationMultiConverter();
            products = new List<Product>
            {
                new Product {ID = 1, Inventory = 5, ModelName = "Model1", Price = 5M, SalePrice = 5M, SKU = "1234"},
                new Product {ID = 2, Inventory = 10, ModelName = "Model2", Price = 10M, SalePrice = 10M, SKU = "2468"}
            };
        };

        Because Calling_Convert = () =>
            param = (ProductListChangeNotificationParameter)converter.Convert(new object[] { products }, typeof(object), null, CultureInfo.CurrentCulture);

        It Should_Hold_A_Product_List_In_The_Returned_Type = () => Assert.Equal(products,param.ProductList);
        
    }
}