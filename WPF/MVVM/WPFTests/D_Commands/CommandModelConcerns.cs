using System;
using System.Windows.Input;
using Machine.Specifications;
using MbUnit.Framework;
using WPF.Samples.Commands.Commands;

namespace WPFTests.Commands
{
    [Subject("CommandModel"), Tags("CommandModel")]
    public class When_Working_With_Command_Models
    {
        static ICommand _command;
        static CanExecuteRoutedEventArgs _canExecuteArgs;
        Establish context = () =>
        {
            _command = new CommandModelBasedCommand();
            Type[] types = { typeof(ICommand), typeof(object) };
            object[] param = {_command.Command, true };
            var privateCanExecuteArgs = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(typeof(CanExecuteRoutedEventArgs), types, param);
            _canExecuteArgs = (CanExecuteRoutedEventArgs)privateCanExecuteArgs.Target;

        };

        Because OnQueryEnabledWasCalled = () => _command.OnQueryEnabled(null, _canExecuteArgs);

        It Should_Not_Execute_When_On_Query_Enabled_Is_False = ()=>
        {
            Assert.AreEqual(true, _canExecuteArgs.CanExecute);
        };
        
    }
}