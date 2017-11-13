#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Command_Parses_Valid_WindowType_Parameter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using Machine.Specifications;
using WPF.Samples.A_Launcher.Commands;
using WPF.Samples.A_Launcher.ViewModels;
using Xunit;

namespace WPFTests.A_Launcher.Commands
{
    [Subject("LaunchCommand"), Tags("LaunchCommand")]
    public class When_Command_Parses_Valid_WindowType_Parameter
    {
        static LaunchCommand _command;
        Establish context = () =>
        {
            _command = new LaunchCommand();
        };
        It Should_Return_Valid_Window_Enum = () => 
            Assert.Equal(
            ApplicationWindowsEnum.ValidationSample, 
            _command.ParseParameter(ApplicationWindowsEnum.ValidationSample));
    }
}