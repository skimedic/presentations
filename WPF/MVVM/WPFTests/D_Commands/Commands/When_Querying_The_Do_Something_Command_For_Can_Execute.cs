#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Querying_The_Do_Something_Command_For_Can_Execute.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using Machine.Specifications;
using WPF.Helpers;
using WPF.Samples.D_Commands.Commands;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using Xunit;

namespace WPFTests.D_Commands.Commands
{
    [Subject("CommandsConcerns"), Tags("CommandsConcerns")]
    public class When_Querying_The_Do_Something_Command_For_Can_Execute
    {
        static IMessenger _messenger;
        static DoSomethingCommand _command;
        Establish context = () =>
        {
            _messenger = Mock.Create<IMessenger>();
            _messenger.Arrange(x => x.Show(string.Empty))
                .IgnoreArguments().Occurs(1);
            _command = new DoSomethingCommand(_messenger);
        };

//        Because ACTION;

        It Should_Return_True_When_Parameter_Is_True = () => 
            Assert.True(_command.CanExecute(true));
        It Should_Return_False_When_Parameter_Is_Not_True = () => 
            Assert.False(_command.CanExecute(false));
        It Should_Return_False_When_Parameter_Is_Null = () => 
            Assert.False(_command.CanExecute(null));
    }
}
