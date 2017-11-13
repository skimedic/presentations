#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPFTests - When_Launch_Command_Is_Queried_For_Can_Execute.cs
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
    public class When_Launch_Command_Is_Queried_For_Can_Execute
    {
        static LaunchCommand _command;
        Establish context = () =>
        {
            _command = new LaunchCommand();
        };
        It Should_Not_Be_Able_To_Execute_If_Parameter_Is_Null = () => Assert.False(_command.CanExecute(null));
        It Should_Be_Able_To_Execute_If_Parameter_Is_Valid_Value = () => Assert.True(_command.CanExecute(ApplicationWindowsEnum.ValidationSample));
    }
}