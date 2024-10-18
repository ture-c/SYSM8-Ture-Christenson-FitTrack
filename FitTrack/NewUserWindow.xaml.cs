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
    public partial class NewUserWindow : Window
    {
        private string userPassword = "";
        public NewUserWindow()
        {
            InitializeComponent();
            SelectCountries();
        }

        private void SelectCountries()
        {
            List<string> countryselect = new List<string>
            {
                "United States", "Canada",
                "United Kingdom",
                "France", "China",
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            userPassword = passwordBox.Password; 
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            string password = userPassword;
            string specialCharacters = "@\\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            string numbers = "1234567890";

            bool hasSpecial = false;
            bool hasNumber = false;

            
            foreach (char c in password)
            {
                if (specialCharacters.Contains(c))
                {
                    hasSpecial = true;
                    break;
                }
            }

            
            foreach (char c in password)
            {
                if (numbers.Contains(c))
                {
                    hasNumber = true;
                    break;
                }
            }

          
            if (hasSpecial && hasNumber)
            {
                MessageBox.Show("Password is valid.");
            }
            else
            {
                MessageBox.Show("Password must contain at least one special character and one number.");
            }



        }
    }
}
