using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using Dapper;

namespace SQLiteLibrary
{
    public class SqliteDataAccess : IDataAccess
    {
        public void AddContact(ContactModel contact)
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Execute("Insert into Contacts(Name, PhoneNumber) values (@Name, @PhoneNumber)", contact);
        }

        public List<ContactModel> LoadContacts(string filterName = "")
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());

            var query = "select * from Contacts";
            if(string.IsNullOrWhiteSpace(filterName) == false)
            {
                query += $" where Name = {filterName}";
            }
            
            return connection.Query<ContactModel>(query).ToList();
        }

        private string LoadConnectionString(string name = "Default")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
