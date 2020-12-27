using System.Collections.Generic;

namespace SQLiteLibrary
{
    public interface IDataAccess
    {
        void AddContact(ContactModel contact);
        List<ContactModel> LoadContacts(string filterName = "");
    }
}