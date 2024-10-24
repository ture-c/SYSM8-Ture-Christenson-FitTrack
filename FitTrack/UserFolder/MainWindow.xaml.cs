using System.Windows;
using System.Windows.Controls;
using static FitTrack.Person1;
using static FitTrack.Person1.User;

namespace FitTrack
{

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
                else if (user is AdminUser adminUser && adminUser.Username == username && adminUser.Password == password)
                {
                    MessageBox.Show("Welcome Admin!");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    WorkoutsWindow workoutwindow = new WorkoutsWindow();
                    workoutwindow.Show();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong username or password.");
                }
            }

        }




        private void LogInbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UserNameTextBox.Text;
                string password = PasswordBox.Password;

                SignIn(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }
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