using System.Windows.Input;
using contactlist.PCL.Data;
using contactlist.PCL.Entities;

namespace contactlist.PCL.ViewModels
{
    public class ContactViewModel : ViewModel
    {
        private readonly INavigation _navigation;
        private readonly Contact _contact;

        public ContactViewModel(INavigation navigation, Contact contact)
        {
            _navigation = navigation;
            _contact = contact;
            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {
            var database = new Database();
            database.AddContact(_contact);

            _navigation.GoBack();
        }

        public ICommand SaveCommand { get; set; }

        public string Firstname
        {
            get { return _contact.Firstname; }
            set
            {
                _contact.Firstname = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get { return _contact.Lastname; }
            set
            {
                _contact.Lastname = value;
                OnPropertyChanged();
            }
        }

        public string EMail
        {
            get { return _contact.EMail; }
            set
            {
                _contact.EMail = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get { return _contact.EMail; }
            set
            {
                _contact.EMail = value;
                OnPropertyChanged();
            }
        }
    }
}
