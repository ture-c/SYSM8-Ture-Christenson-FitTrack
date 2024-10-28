using System.Windows;
using System.Windows.Controls;
using static FitTrack.Person1;

namespace FitTrack
{
    public partial class UserDetailsWindow : Window
    {
        private User thisUser;

        public UserDetailsWindow(User thisUser)
        {
            InitializeComponent();
            this.thisUser = thisUser;

            
            UsernameTextBox.Text = thisUser.Username;
            LoadCountryList();
            CountryComboBox.SelectedItem = thisUser.Country;
        }

        private void LoadCountryList()
        {
            
            thisUser.LoadCountryList(CountryComboBox);
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (PasswordBox.Password != NewPasswordBox.Password)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            if (string.IsNullOrEmpty(UsernameTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // Updaterar användarens information.
            thisUser.Username = UsernameTextBox.Text;
            thisUser.Password = PasswordBox.Password;
            if (CountryComboBox.SelectedItem != null)
            {
                thisUser.Country = CountryComboBox.SelectedItem.ToString();
            }

            MessageBox.Show("User details updated successfully!");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
        }
    }
}