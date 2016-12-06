using System.Windows.Input;

namespace WPF.Samples.Commands.Commands.Core
{
    public abstract class CommandModel
    {
        protected CommandModel()
        {
            Command = new RoutedCommand();
        }
        public RoutedCommand Command { get; private set; }
        public virtual void OnQueryEnabled(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        public abstract void OnExecute(object sender, ExecutedRoutedEventArgs e);
    }
}