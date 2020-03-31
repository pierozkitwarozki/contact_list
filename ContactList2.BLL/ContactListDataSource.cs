using System;
using System.Collections.Generic;

namespace ContactList2.BLL
{
    public static class ContactListDataSource
    {
        public static List<ContactList2.Models.Contact> GetContacts()
        {
            var contacts = new List<ContactList2.Models.Contact>();

            for (int i = 0; i < 20; i++)
            {
                contacts.Add(new ContactList2.Models.Contact(string.Format("My Contact {0}", i + 1),
                                         "fake_email@gmail.com",
                                         "+48 123 123 123"));
            }

            return contacts;
        }
    }
}
