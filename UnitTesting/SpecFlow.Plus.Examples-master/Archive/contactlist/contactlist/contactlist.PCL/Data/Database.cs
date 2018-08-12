using System;
using System.Collections.Generic;
using System.Linq;
using contactlist.PCL.Entities;

namespace contactlist.PCL.Data
{
    class Database
    {
        private static readonly List<Contact> _contacts = new List<Contact>()
                                                 {
                                                     new Contact() {Firstname = "Javier", Lastname = "Knutson", EMail = "javier.knutson@example.org", Phone = "0064563214" },
                                                     new Contact() {Firstname = "Nydia", Lastname = "Butler", EMail = "nb@example.org", Phone = "+43 0155 0048 - 15"},
                                                     new Contact() {Firstname = "Milo", Lastname = "Van Oirschot", EMail = "milo@van-oirschot.example.org", Phone = "-"}
                                                 };

        public List<Contact> SearchContacts(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                return _contacts;

            return _contacts.Where(c => c.Firstname.Contains(name)).ToList();
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }
    }
}
