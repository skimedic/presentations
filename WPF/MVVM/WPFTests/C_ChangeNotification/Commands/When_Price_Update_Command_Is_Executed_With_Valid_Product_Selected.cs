#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Price_Update_Command_Is_Executed_With_Valid_Product_Selected.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

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
    [Subject("PriceUpdaterCommand"), Tags("PriceUpdaterCommand")]
    public class When_Price_Update_Command_Is_Executed_With_Valid_Product_Selected
    {
        static PriceUpdaterCommand _command;
        static ProductChangeNotificationParameter param;
        static Product prod;
        static IControlUpdater _controlUpdater;
        static decimal price;
        Establish context = () =>
        {
            _command = new PriceUpdaterCommand();
            price = 5M;
            prod = new Product {ID = 1, Inventory = 5, ModelName = "Model1", Price = price, SalePrice = price, SKU = "1234"};
            _controlUpdater = Mock.Create<IControlUpdater>();
            _controlUpdater.Arrange(x => x.SetContent(string.Empty))
                .IgnoreArguments().Occurs(1);
            param = new ProductChangeNotificationParameter { Product = prod, CallBackControlUpdater = _controlUpdater};
        };

        Because Execute_Is_Called = () => _command.Execute(param);
        It Should_Update_The_Price_By_Ten_Percent = () => Assert.Equal(price*1.1M, prod.Price);
        It Should_Update_The_Content_Control = () => _controlUpdater.Assert();
    }
}