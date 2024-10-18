using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitTrack
{

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LogInbtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "admin" && password == "123")
            {
                //Ny sida
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    

        private void NewUserbtn_Click(object sender, RoutedEventArgs e)
        {
                    NewUserWindow newuserwindow = new NewUserWindow(); 

                    newuserwindow.Show();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
           
        }

        private void ForgotP_Click(object sender, RoutedEventArgs e)
        {
            //NewForgetPWindow forgotwin = new NewForgetPWindow();
            //forgotwin.Show();

        }
        
    }
}