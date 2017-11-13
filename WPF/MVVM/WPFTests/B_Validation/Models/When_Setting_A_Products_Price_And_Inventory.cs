#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Setting_A_Products_Price_And_Inventory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using Machine.Specifications;
using WPF.Models;

namespace WPFTests.B_Validation.Models
{
    [Subject("ProductValidation"), Tags("ProductValidation")]
    public class When_Setting_A_Products_Price_And_Inventory
    {
        static Product product = new Product();
        static string modelName = "model";
        Establish context = () =>  product.ModelName = modelName;
        It Should_Error_If_Inventory_Is_Greater_Than_50_And_SalePrice_Is_Greater_Than_90_Percent_Of_Price_ = () =>
        {
            product.Inventory = 100;
            product.Price = 100;
            product.SalePrice = 100;
			//Assert.AreEqual(
			//	product[Product.FieldNames.SalePrice.ToString()], 
			//	modelName + " must be marked down due to stock quantity greater than 50");
        };
        It Should_Error_If_Inventory_Is_Less_Than_50_And_SalePrice_Does_Not_Equal_Price_ = () =>
        {
            product.Inventory = 49;
            product.Price = 100;
            product.SalePrice = 90;
			//Assert.AreEqual(
			//	product[Product.FieldNames.SalePrice.ToString()],
			//	modelName + " must not be marked down if the quantity is less than 50");
        };
        It Should_Not_Error_If_Inventory_Is_Greater_Than_50_And_SalePrice_Is_Not_Greater_Than_90_Percent_Of_Price_ = () =>
        {
            product.Inventory = 100;
            product.Price = 100;
            product.SalePrice = 90;
            //Assert.AreEqual(product[Product.FieldNames.SalePrice.ToString()], string.Empty);
        };
        It Should_Not_Error_If_Inventory_Is_Less_Than_50_And_SalePrice_Equals_Price_ = () =>
        {
            product.Inventory = 49;
            product.Price = 100;
            product.SalePrice = 100;
            //Assert.AreEqual(product[Product.FieldNames.SalePrice.ToString()], string.Empty);
        };
    }
}