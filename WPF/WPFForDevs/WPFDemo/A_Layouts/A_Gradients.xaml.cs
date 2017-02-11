#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - A_Gradients.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Windows;

namespace WPFDemo.A_Layouts
{
    /// <summary>
    /// Interaction logic for SelectorExamples.xaml
    /// </summary>
    public partial class Gradients
    {
        public Gradients()
        {
            InitializeComponent();
        }

        private void cmdAsk_Click(object sender, RoutedEventArgs e)
        {
            txtAnswer.Text = txtQuestion.Text;
            Cursor = null;
        }
        
    }
}