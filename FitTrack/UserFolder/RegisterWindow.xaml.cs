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
            User user = new User("", "", "", "", "");
            user.LoadCountryList(CountryComboBox);
        }




        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text;
                string password = PasswordBox.Password;
                string country = CountryComboBox.SelectedItem?.ToString();
                string securityQuestion = SecurityQuestionCombobox.SelectedItem?.ToString();
                string securityAnswer = SecurityAnswerTextBox.Text;



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
    }
}
