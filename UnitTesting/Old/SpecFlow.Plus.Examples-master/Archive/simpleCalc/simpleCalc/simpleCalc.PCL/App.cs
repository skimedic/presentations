using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleCalc.PCL.View;
using Xamarin.Forms;

namespace simpleCalc.PCL
{
    public class App : Application
    {
        public App()
        {
            MainPage = new MainView();
            MainPage.BindingContext = new MainViewModel();
        }
    }
}
