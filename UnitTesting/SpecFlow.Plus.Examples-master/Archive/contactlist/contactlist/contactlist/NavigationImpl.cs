using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using contactlist.PCL;

namespace contactlist
{
    class NavigationImpl : INavigation
    {
        public void GoBack()
        {
            var frame = Window.Current.Content as Frame;
            frame.GoBack();
        }

        public void OpenNewContact()
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(NewContactPage));
        }
    }
}
