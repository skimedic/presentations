#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Passing_In_Multiple_Parameters_To_The_Product_Change_Notification_Converter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Globalization;
using Machine.Specifications;
using WPF.Models;
using WPF.Samples.C_ChangeNotification.Converters;
using Xunit;

namespace WPFTests.C_ChangeNotification.Converters
{
    [Subject("ChangeNotification"), Tags("ChangeNotification")]
    public class When_Passing_In_Multiple_Parameters_To_The_Product_Change_Notification_Converter
    {
        static ProductChangeNotificationMultiConverter _converter;
        static Product _product;
        static ProductChangeNotificationParameter _param;
        Establish context = () =>
        {
            _converter = new ProductChangeNotificationMultiConverter();
            _product = 
                new Product {ID = 1, Inventory = 5, ModelName = "Model1", Price = 5M, SalePrice = 5M, SKU = "1234"};
        };

        Because Calling_Convert = () =>
                                  _param = (ProductChangeNotificationParameter)_converter.Convert(new object[] { _product }, typeof(object), null, CultureInfo.CurrentCulture);

        It Should_Hold_A_Product_In_The_Returned_Type = () => Assert.Equal(_product,_param.Product);
        
    }
}