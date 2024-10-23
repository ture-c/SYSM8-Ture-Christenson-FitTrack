using System.Configuration;
using System.Diagnostics.Eventing.Reader;
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
using static FitTrack.Person1;

namespace FitTrack
{
   
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            //person = new Person1.User("admin", "testtest123-", "Country", "What is your favorite color?", "Blue");
        }


        public void Register()
        {
            RegisterWindow registerwindow = new RegisterWindow();

            registerwindow.Show();
            this.Close();
            

        }
        public void SignIn(string username, string password)
        {
            foreach (User user in RegisterWindow.ActiveUsers)
            {
                if (user.Username == username && user.Password == password)
                {
                    
                    MessageBox.Show("Login successful!");
                   
                    WorkoutsWindow workoutwindow = new WorkoutsWindow();
                    workoutwindow.Show();
                    this.Close();
                }
            }
            MessageBox.Show("Wrong username or password.");
        }






      private void LogInbtn_Click(object sender, RoutedEventArgs e) 
        {
            string username = UserNameTextBox.Text; 
            string password = PasswordBox.Password; 

            SignIn(username, password);
        }
        private void NewUserbtn_Click(object sender, RoutedEventArgs e) { Register(); }
        

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = passwordBox.Password;
        }



        private void ForgotP_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword forgotwin = new ForgotPassword();
            forgotwin.Show();

        }

    }
}