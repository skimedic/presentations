#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Launch_Command_Is_Executed_With_Valid_Window_As_Parameter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using Machine.Specifications;
using WPF.Helpers;
using WPF.Samples.A_Launcher.Commands;
using WPF.Samples.A_Launcher.ViewModels;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace WPFTests.A_Launcher.Commands
{
    [Subject("LaunchCommand"), Tags("LaunchCommand")]
    public class When_Launch_Command_Is_Executed_With_Valid_Window_As_Parameter
    {
        static LaunchCommand _command;
        static IWindowLauncher _launcher;
        Establish context = () =>
        {
            _launcher = Mock.Create<IWindowLauncher>();
            _launcher.Arrange(x => x.Show()).Occurs(1);
            _command = new LaunchCommand(_launcher);
        };
        Because Command_Is_Executed = () => _command.Execute(ApplicationWindowsEnum.ValidationSample);
        It Should_Show_The_Window = () => _launcher.Assert();
    }
}