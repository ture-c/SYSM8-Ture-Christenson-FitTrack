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

            if (thisUser.Username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters.");
                return;
            }
            //En så kallad lambda expression. Denna kollar om användarnamnet redan finns
            if (User.ActiveUsers.Any(user => user.Username.Equals(thisUser.Username, StringComparison.OrdinalIgnoreCase) && user != thisUser))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            // Tar informationen från Ui. 
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password; //Nuvarande lösenordet
            string newPassword = NewPasswordBox.Password; // Gamla lösenordet
            string country = CountryComboBox.SelectedItem?.ToString();
            

            // Validerar lösenordet via isFilled i person
            if (!thisUser.isFilled(username, newPassword, country))
            {
                return; // om validering är fel.
            }

            // ser till så att om nya lösenordet inte matchar så slutar den.
            if (newPassword != NewPasswordBox.Password)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Updaaterar personens info
            thisUser.Username = username;
            thisUser.Password = newPassword; // Updaterar nya lösenordet. 

            if (country != null)
            {
                thisUser.Country = country;
            }

            MessageBox.Show("User details updated successfully!");

            
            WorkoutsWindow win = new WorkoutsWindow(thisUser);
            win.Show();
            this.Close();
        }   

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            WorkoutsWindow win = new WorkoutsWindow(thisUser);
            win.Show();
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