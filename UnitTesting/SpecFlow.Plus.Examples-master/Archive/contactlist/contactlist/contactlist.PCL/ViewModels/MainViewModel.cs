using System.Collections.ObjectModel;
using System.Windows.Input;
using contactlist.PCL.Data;
using contactlist.PCL.Entities;

namespace contactlist.PCL.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly INavigation _navigation;
        public ObservableCollection<Contact> Contacts { get; set; }
        private readonly Database _database;
        private string _searchString;

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _database = new Database();
            Contacts = new ObservableCollection<Contact>(_database.SearchContacts(""));
            AddCommand = new Command(ShowAddWindow);
        }

        private void ShowAddWindow()
        {
            _navigation.OpenNewContact();
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString) return;
                _searchString = value;
                Search(value);
                OnPropertyChanged();
            }
        }

        private void Search(string value)
        {
            Contacts.Clear();

            var result = _database.SearchContacts(value);
            foreach (var contact in result)
            {
                Contacts.Add(contact);
            }         
        }

        public ICommand AddCommand { get; set; }


        public void Refresh()
        {
            Search(SearchString);
        }
    }
}
