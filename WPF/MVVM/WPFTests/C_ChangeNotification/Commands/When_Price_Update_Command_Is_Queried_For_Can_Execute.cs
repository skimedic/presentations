#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Price_Update_Command_Is_Queried_For_Can_Execute.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using Machine.Specifications;
using WPF.Models;
using WPF.Samples.C_ChangeNotification.Commands;
using WPF.Samples.C_ChangeNotification.Converters;
using Xunit;

namespace WPFTests.C_ChangeNotification.Commands
{
    [Subject("PriceUpdaterCommand"), Tags("PriceUpdaterCommand")]
    public class When_Price_Update_Command_Is_Queried_For_Can_Execute
    {
        static PriceUpdaterCommand _command;
        Establish context = () =>
        {
            _command = new PriceUpdaterCommand();
        };
        It Should_Not_Be_Able_To_Execute_If_Parameter_Is_Null = () => Assert.False(_command.CanExecute(null));
        It Should_Not_Be_Able_To_Execute_If_No_Product_Is_Selected = () => Assert.False(_command.CanExecute(new ProductChangeNotificationParameter()));
        It Should_Be_Able_To_Execute_If_Product_Is_Selected = () => Assert.True(_command.CanExecute(new ProductChangeNotificationParameter { Product = new Product() }));
    }
}