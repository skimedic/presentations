using System.Windows;
using System.Windows.Input;

namespace WPF.Samples.Commands.Commands.Core
{
    public static class CreateCommandBinding
    {
        //http://blogs.msdn.com/dancre/archive/2006/09/15/756095.aspx Dan Crevier
        public static readonly DependencyProperty CommandProperty = 
            DependencyProperty.RegisterAttached(
                "Command", typeof(CommandModel), typeof(CreateCommandBinding),
                new PropertyMetadata(
                    new PropertyChangedCallback(onCommandInvalidated)));

        public static CommandModel GetCommand(DependencyObject sender)
        {
            return (CommandModel)sender.GetValue(CommandProperty);
        }
        public static void SetCommand(DependencyObject sender, CommandModel command)
        {
            sender.SetValue(CommandProperty, command);
        }
        private static void onCommandInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            // Clear the exisiting bindings on the element we are attached to.
            var element = (UIElement)dependencyObject;
            element.CommandBindings.Clear();
            // If we're given a command model, set up a binding
            var commandModel = e.NewValue as CommandModel;
            if (commandModel != null)
            {
                element.CommandBindings.Add(
                    new CommandBinding(
                        commandModel.Command, 
                        commandModel.OnExecute, 
                        commandModel.OnQueryEnabled));
            }
            // Suggest to WPF to refresh commands
            CommandManager.InvalidateRequerySuggested();
        }
    }
}