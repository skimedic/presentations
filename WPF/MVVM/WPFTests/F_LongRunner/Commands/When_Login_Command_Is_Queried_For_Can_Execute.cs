#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Login_Command_Is_Queried_For_Can_Execute.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using Machine.Specifications;
using WPF.Helpers;
using WPF.Samples.F_LongRunner.Commands;
using WPF.Samples.F_LongRunner.Converters;
using Telerik.JustMock;
using Xunit;

namespace WPFTests.F_LongRunner.Commands
{
    [Subject("LoginCommandConcerns"), Tags("LoginCommandConcerns")]
    public class When_Login_Command_Is_Queried_For_Can_Execute
    {
        static LoginCommand _command;
        static IMessenger _messenger;
        Establish context = () =>
        {
            _messenger = Mock.Create<IMessenger>();
            _command = new LoginCommand(_messenger);
        };

        //Because ACTION;

        It Should_Return_True_When_Parameter_Is_Login_Parameter = () => Assert.True(_command.CanExecute(new LoginParameter()));
        It Should_Return_True_When_Parameter_Is_Not_Login_Parameter = () => Assert.False(_command.CanExecute("test"));
        It Should_Return_True_When_Parameter_Is_Null = () => Assert.False(_command.CanExecute(null));
        
    }
}