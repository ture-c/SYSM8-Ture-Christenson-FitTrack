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
using static FitTrack.Person1;

namespace FitTrack
{
    
    public partial class ForgotPassword : Window
    {
        

        public ForgotPassword()
        {
            InitializeComponent();
             
        }


        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var ConfirmPasswordBox = sender as PasswordBox;

            string confirmpassword = ConfirmPasswordBox.Password;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text; 
            string answer = SecurityAnswerTextBox.Text; 
            string newPassword = PasswordBox.Password;
            string confirmpassword = ConfirmPasswordBox.Password;

            if (newPassword != confirmpassword)
            {
                MessageBox.Show("Passwords do not match.");
            }

            //Hitta användaren
            User userToReset = User.ActiveUsers.FirstOrDefault(u => u.Username.Equals(username));

            
            if (userToReset != null)
            {
                
                if (userToReset.ResetPassword(username, answer, newPassword))
                {
                    
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            var passwordBox = sender as PasswordBox;

            string password = passwordBox.Password;
        }
            
    }
    


}
