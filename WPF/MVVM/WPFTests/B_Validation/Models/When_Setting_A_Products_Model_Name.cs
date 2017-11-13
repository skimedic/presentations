#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Setting_A_Products_Model_Name.cs
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
    public class When_Setting_A_Products_Model_Name
    {
        static Product product = new Product();
        It Should_Error_If_Model_Name_Contains_XXX = () =>
        {
            product.ModelName = "something XXX something else";
            //Assert.AreEqual(product[Product.FieldNames.ModelName.ToString()], "Our Store does not support adult content.");
        };
        It Should_Not_Error_If_Model_Name_Does_Not_Contains_XXX = () =>
        {
            product.ModelName = "name";
            //Assert.AreEqual(product[Product.FieldNames.ModelName.ToString()], string.Empty);
        };
    }
}