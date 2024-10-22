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
        internal static List<User> ActiveUsers = new List<User>();
        public RegisterWindow()
        {
            InitializeComponent();
            CountrySelect();


        }

        private void CountrySelect()
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

            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string country = CountryComboBox.SelectedItem?.ToString();
            string securityQuestion = SecurityQuestionTextBox.Text;
            string securityAnswer = SecurityAnswerTextBox.Text;


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
            bool hasSpecialChar = false;
            bool hasNum = false;

            foreach (char c in password)
            {
                if (specialCharacters.Contains(c))
                {
                    hasSpecialChar = true;
                }
                if (char.IsDigit(c))
                {
                    hasNum = true;
                }

            }
            if (!hasSpecialChar || !hasNum)
            {
                MessageBox.Show("Must contain a number and special character.");
            }

            if (password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }




            User newUser = new User(username, password, country, securityQuestion, securityAnswer);
            ActiveUsers.Add(newUser);
            MessageBox.Show("User registered successfully!");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();



        }



        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {




        }
    }
}


