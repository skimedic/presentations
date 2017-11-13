#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Setting_A_Products_Inventory.cs
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
    public class When_Setting_A_Products_Inventory
    {
        static Product product = new Product();
        It Should_Error_If_Inventory_Is_Less_Than_Zero = () =>
        {
            product.Inventory = -1;
            //Assert.AreEqual(product[Product.FieldNames.Inventory.ToString()], "Inventory can not be less than zero");
        };
        It Should_Not_Error_If_Inventory_Is_Greater_Than_Zero = () =>
        {
            product.Inventory = 100;
            //Assert.AreEqual(product[Product.FieldNames.Inventory.ToString()], string.Empty);
        };
    }
}