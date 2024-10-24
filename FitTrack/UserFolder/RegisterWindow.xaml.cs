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
                "Austria", "Belgium",
                "Bulgaria", "Croatia",
                "Cyprus", "Czech Republic",
                "Denmark", "Estonia",
                "Finland", "France",
                "Germany", "Greece",
                "Hungary", "Ireland",
                "Italy", "Latvia",
                "Lithuania", "Luxembourg",
                "Malta", "Netherlands",
                "Poland", "Portugal",
                "Romania", "Slovakia",
                "Slovenia", "Spain",
                "Sweden", "Iceland",
                "Liechtenstein",
                "Norway", "Switzerland"


            };

            CountryComboBox.ItemsSource = countryselect;
            countryselect.Sort();
        }




        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {


            if (isFilled())
            {
                User newUser = new User(UsernameTextBox.Text, PasswordBox.Password,
                           CountryComboBox.SelectedItem?.ToString(),
                               SecurityQuestionCombobox.SelectedItem?.ToString(),
                                SecurityAnswerTextBox.Text);

                ActiveUsers.Add(newUser);
                MessageBox.Show("User registered successfully!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }



        }
        private bool isFilled()
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string country = CountryComboBox.SelectedItem?.ToString();
            string securityQuestion = SecurityQuestionCombobox.SelectedItem?.ToString();
            string securityAnswer = SecurityAnswerTextBox.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(country) ||
                string.IsNullOrEmpty(securityQuestion) || string.IsNullOrEmpty(securityAnswer))
            {
                MessageBox.Show("All fields must be filled out.");
                return false;
            }


            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.");
                return false;
            }


            string specialCharacters = "@\\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            bool hasSpecialChar = password.Any(c => specialCharacters.Contains(c));
            bool hasNum = password.Any(char.IsDigit);

            if (!hasSpecialChar || !hasNum)
            {
                MessageBox.Show("Password must contain at least one special character and one number.");
                return false;
            }


            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }


            return true;
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

