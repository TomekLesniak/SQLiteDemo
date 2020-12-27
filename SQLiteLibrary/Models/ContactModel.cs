using System;

namespace SQLiteLibrary
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string FullContact => $"{Name} ({PhoneNumber})";
    }
}
