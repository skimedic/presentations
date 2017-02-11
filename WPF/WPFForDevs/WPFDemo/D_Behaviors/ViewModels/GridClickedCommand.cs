#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - GridClickedCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using SampleData;
using WPFDemo.B_Commands.Helpers;
using WPFDemo.BaseClasses;

namespace WPFDemo.D_Behaviors.ViewModels
{
    public class GridClickedCommand : CommandBase
    {
        readonly IMessager _messager;

        public GridClickedCommand(IMessager messager)
        {
            _messager = messager;
        }

        public override void Execute(object parameter)
        {

            if (!(parameter is Product))
            {
                return;
            }
            _messager.Show(((Product)parameter).ModelName);
            
        }

        public override bool CanExecute(object parameter) => parameter is Product;
    }
}
