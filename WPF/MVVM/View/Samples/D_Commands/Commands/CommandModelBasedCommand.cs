using System.Windows;
using System.Windows.Input;
using WPF.Samples.Commands.Commands.Core;

namespace WPF.Samples.Commands.Commands
{
    public class CommandModelBasedCommand :CommandModel
    {
        public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Something Else Clicked");
        }
        public override void OnQueryEnabled(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (e.Parameter != null && (bool)e.Parameter);
        }
    }
}