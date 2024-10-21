using System.Configuration;
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
using static FitTrack.AddWorkoutWindow;

namespace FitTrack
{
    public static class UserData
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static string Country { get; set; }
       
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public void Register()
        {
            RegisterWindow registerwindow = new RegisterWindow();

            registerwindow.Show();
            this.Close();

        }
        public void SignIn()
        {
            string username = UserNameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == UserData.Username && password == UserData.Password)
            {
                WorkoutsWindow workoutwin = new WorkoutsWindow();
                workoutwin.Show();
                this.Hide();

            }
            else if (username == "admin" && password == "password")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Hide();
            }
                

            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }



        private void LogInbtn_Click(object sender, RoutedEventArgs e) { SignIn(); }
        
            
       


        private void NewUserbtn_Click(object sender, RoutedEventArgs e) { Register(); }
        

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = passwordBox.Password;
        }



        private void ForgotP_Click(object sender, RoutedEventArgs e)
        {
            //NewForgetPWindow forgotwin = new NewForgetPWindow();
            //forgotwin.Show();

        }

    }
}