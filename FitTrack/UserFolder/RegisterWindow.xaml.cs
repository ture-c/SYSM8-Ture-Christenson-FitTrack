using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using System.Windows.Shapes;
using static FitTrack.Person1;

namespace FitTrack
{

    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            CountrySelect();
            

        }

        private void CountrySelect()
        {
            //Instansen är gjord för att hämta LoadCountry till combobox
            User user = new User("", "", "", "", "");
            user.LoadCountryList(CountryComboBox);
        }




        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text;
                string password = PasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;
                string country = CountryComboBox.SelectedItem?.ToString();
                string securityQuestion = SecurityQuestionCombobox.SelectedItem?.ToString();
                string securityAnswer = SecurityAnswerTextBox.Text;

                if (username.Length < 3)
                {
                    MessageBox.Show("Username must be at least 3 characters.");
                    return;
                }

                if (User.ActiveUsers.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }
                //Se om country, säkerhetsfrågorna är ifyllda/valda.
                if (string.IsNullOrEmpty(country))
                {
                    MessageBox.Show("Please select a country.");
                    return;
                }
                

                if (string.IsNullOrEmpty(securityQuestion))
                {
                    MessageBox.Show("Please select a security question.");
                    return;
                }

                if (string.IsNullOrEmpty(securityAnswer))
                {
                    MessageBox.Show("Please enter an answer for the security question.");
                    return;
                }


                User user = new User(username, password, country, securityQuestion, securityAnswer);
                user.Register(username, password, country, securityQuestion, securityAnswer);
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}");
            }
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {




        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
