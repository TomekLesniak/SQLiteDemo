using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLiteLibrary;

namespace SQLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataAccess _dataAccess;
        private List<ContactModel> _contacts = new List<ContactModel>();
        
        public MainWindow()
        {
            InitializeComponent();
            _dataAccess = new SqliteDataAccess();
            
            RefreshListBox();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            RefreshListBox(FilterTextBox.Text);
            FilterTextBox.Text = "";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var contact = new ContactModel {Name = NameTextBox.Text, PhoneNumber = PhoneNumberTextBox.Text};
            _dataAccess.AddContact(contact);

            NameTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
         
            RefreshListBox();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var contact = _contacts[ContactsListBox.SelectedIndex];
            _dataAccess.Remove(contact);
            
            RefreshListBox();
        }

        private void LoadContacts(string filter = "")
        {
            _contacts = _dataAccess.LoadContacts(FilterTextBox.Text);
        }

        private void RefreshListBox(string filter = "")
        {
            LoadContacts(filter);
            
            ContactsListBox.ItemsSource = null;
            ContactsListBox.ItemsSource = _contacts;
            ContactsListBox.DisplayMemberPath = "FullContact";
        }

    }
}
