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
            SelectCountries();
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
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string country = CountryComboBox.SelectedItem?.ToString() ?? "";
            string securityQuestion = SecurityQuestionTextBox.Text;
            string securityAnswer = SecurityAnswerTextBox.Text;

            Person1.User newUser = new Person1.User(username, password, country, securityQuestion, securityAnswer);
            newUser.RegisterUser(this, confirmPassword);
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