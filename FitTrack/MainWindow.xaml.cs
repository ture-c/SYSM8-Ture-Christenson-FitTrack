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
using static FitTrack.Person1;

namespace FitTrack
{
    

    public partial class MainWindow : Window
    {
        private Person thisPerson;
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
            ForgotPassword forgotwin = new ForgotPassword();
            forgotwin.Show();

        }

    }
}