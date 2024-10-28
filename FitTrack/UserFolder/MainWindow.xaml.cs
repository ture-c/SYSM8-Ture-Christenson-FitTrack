using System.Windows;
using System.Windows.Controls;
using static FitTrack.Person1;
using static FitTrack.Person1.User;
using static FitTrack.Person1.AdminUser;

namespace FitTrack
{
    

    public partial class MainWindow : Window
    {
        AdminUser adminUser = new AdminUser("admin", "password", "Sweden", "What is your mother name", "Jane Doe" );
           

        public MainWindow()
        {

          
           InitializeComponent();
            UserNameTextBox.Text = adminUser.Username;
            PasswordBox.Password = adminUser.Password;

        }

        public void Register()
        {
            RegisterWindow registerwindow = new RegisterWindow();

            registerwindow.Show();
            this.Close();


        }
        public void SignIn(string username, string password)
        {
            try
            {
              
                if (adminUser.SignIn(username, password))
                {
                    MessageBox.Show("Welcome Admin!");
                    AdminWindow adminWindow = new AdminWindow();
                    WorkoutsWindow workoutwindow = new WorkoutsWindow(adminUser);
                    adminWindow.Show();
                    workoutwindow.Show();
                    this.Close();
                    return;
                }

                bool userFound = false;
                foreach (User user in User.ActiveUsers)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        MessageBox.Show("Login successful!");
                        WorkoutsWindow workoutwindow = new WorkoutsWindow(user);
                        workoutwindow.Show();
                        this.Close();
                        userFound = true;
                        break; 
                    }
                }

                if (!userFound)
                {
                    MessageBox.Show("Wrong username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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