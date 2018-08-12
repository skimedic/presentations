using Windows.UI.Xaml.Controls;
using contactlist.PCL.Entities;
using contactlist.PCL.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace contactlist
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewContactPage : Page
    {
        public NewContactPage()
        {
            this.InitializeComponent();
            DataContext = new ContactViewModel(new NavigationImpl(), new Contact());
        }
    }
}
