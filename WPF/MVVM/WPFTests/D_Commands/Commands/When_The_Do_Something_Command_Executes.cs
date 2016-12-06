#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_The_Do_Something_Command_Executes.cs
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

namespace WPFTests.D_Commands.Commands
{
    [Subject("CommandsConcerns"), Tags("CommandsConcerns")]
    public class When_The_Do_Something_Command_Executes
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

        Because ACTION = () => _command.Execute(true);

        It Should_Show_Message = () => _messenger.Assert();
    }
}