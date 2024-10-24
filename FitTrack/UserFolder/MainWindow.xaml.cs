using System.Windows;
using System.Windows.Controls;
using static FitTrack.Person1;
using static FitTrack.Person1.User;

namespace FitTrack
{
    

    public partial class MainWindow : Window
    {
        AdminUser adminUser = new AdminUser("admin", "password", "Sweden", "What is your mother name", "Jane Doe" );
           

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
            try
            {
                if (adminUser.Username.Equals(username, 
                    StringComparison.OrdinalIgnoreCase) 
                        && adminUser.Password == password)
                    {
                    MessageBox.Show("Welcome Admin!");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    WorkoutsWindow workoutwindow = new WorkoutsWindow();
                    workoutwindow.Show();
                    this.Close();

                    return;
                }

                foreach (User user in RegisterWindow.ActiveUsers)
                {
                    if (user.Username == username && user.Password == password)
                    {

                        MessageBox.Show("Login successful!");

                        WorkoutsWindow workoutwindow = new WorkoutsWindow();
                        workoutwindow.Show();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password.");
                    }

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