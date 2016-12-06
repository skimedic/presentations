#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - LoginMultiConverterConcerns.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Globalization;
using Machine.Specifications;
using MbUnit.Framework;
using WPF.Samples.F_LongRunner.Converters;

namespace WPFTests.F_LongRunner.Converters
{
    [Subject("LoginConverterConcerns"), Tags("LoginConverterConcerns")]
    public class When_Passing_In_Multiple_Parameters_To_The_Login_Converter
    {
        static LoginMultiConverter _converter;
        static LoginParameter _parameter;
        static string userName = "userName";
        static string password = "passWord";
        Establish context = () =>
        {
            _converter = new LoginMultiConverter();
        };

        Because Calling_Convert = () =>
                                  _parameter = (LoginParameter)_converter
                                  .Convert(new object[] { userName,password,null }, typeof(object), null, CultureInfo.CurrentCulture);

        It Should_Hold_A_Product_In_The_Returned_Type = () =>
        {
            Assert.AreEqual(userName, _parameter.UserName);
            Assert.AreEqual(password, _parameter.Password);
        };

    }
}