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

            this.Close();
            WorkoutsWindow win = new WorkoutsWindow(thisUser);
            win.Show();
        }   

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WorkoutsWindow win = new WorkoutsWindow(thisUser);
            win.Show();
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
        }
    }
}