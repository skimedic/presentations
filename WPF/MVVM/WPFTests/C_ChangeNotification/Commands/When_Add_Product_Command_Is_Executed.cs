#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Add_Product_Command_Is_Executed.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.Generic;
using Machine.Specifications;
using WPF.Helpers;
using WPF.Models;
using WPF.Samples.C_ChangeNotification.Commands;
using WPF.Samples.C_ChangeNotification.Converters;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using Xunit;

namespace WPFTests.C_ChangeNotification.Commands
{
    [Subject("AddProductCommand"), Tags("AddProductCommand")]
    public class When_Add_Product_Command_Is_Executed
    {
        static AddProductCommand _command;
        static ProductListChangeNotificationParameter param;
        static IControlUpdater _controlUpdater;
        static int count = 1;
        Establish context = () =>
        {
            _command = new AddProductCommand();
            _controlUpdater = Mock.Create<IControlUpdater>();
            _controlUpdater.Arrange(x => x.SetContent(count.ToString()))
                .Occurs(1);
            param = new ProductListChangeNotificationParameter
            {
                ProductList = new List<Product>(),
                CallBackControlUpdater = _controlUpdater
            };
        };

        Because Execute_Is_Called = () => _command.Execute(param);
        It Should_Add_Another_Product = () => Assert.Equal(count, param.ProductList.Count);
        It Should_Update_The_Content_Control = () => _controlUpdater.Assert();
    }
}