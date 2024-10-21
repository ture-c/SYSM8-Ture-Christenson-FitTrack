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
using System.Windows.Shapes;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private string userPassword = "";
        public RegisterWindow()
        {
            InitializeComponent();
            RegisterNewUser();
            SelectCountries();
        }


        public void RegisterNewUser()
        {
            string username = UsernameTextBox.Text;
            string password = userPassword;
            string confirmPassword = ConfirmPasswordBox.Password;

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Username and password cannot be empty.");
                        return;
                    }

                    if (password.Length < 8)
                    {
                        MessageBox.Show("Password must be at least 8 characters.");
                        return;
                    }
                    string specialCharacters = "@\\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            
                    foreach (char c in password)

                        if (!specialCharacters.Contains(c) && !password.Any(char.IsDigit))
                       {
                        MessageBox.Show("Password must contain at least one special character and one number.");
                        return;
                        }
                    if (password != confirmPassword)
                    {
                        MessageBox.Show("Passwords do not match.");
                        return;
                    }

            




            UserData.Username = username;
             UserData.Password = password;

             MessageBox.Show("User registered successfully!");

             UsernameTextBox.Clear();
             PasswordBox.Clear();
             ConfirmPasswordBox.Clear();

             MainWindow loginwindow = new MainWindow();
             loginwindow.Show();
             this.Close();              


        }

        private void SelectCountries()
        {
            List<string> countryselect = new List<string>
            {
                "United States",
                "Canada",
                "United Kingdom",
                "France",
                "China",
                "Norway",
                "Sweden",
                "Denmark",
                "Germany",
                "North Korea",
                "Christmas Island",
                "Burkina Faso",
                "Yemen",
                "Angola",

            };
            
            CountryComboBox.ItemsSource = countryselect;
            countryselect.Sort();

        }



        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterNewUser();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            userPassword = passwordBox.Password;
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
           



        }
    }

}