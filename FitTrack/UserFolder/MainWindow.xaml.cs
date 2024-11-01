using System.Windows;
using System.Windows.Controls;
using static FitTrack.Person1;
using static FitTrack.Person1.User;
using static FitTrack.Person1.AdminUser;
using System.Collections.ObjectModel;
using System.Xml.Linq;
namespace FitTrack
{


    public partial class MainWindow : Window
    {
        User adminUser = new AdminUser("admin", "password", "Sweden", "What is your mother name", "Jane Doe", true);

        User testuser = new User("user", "password", "Sweden", "What is your mother name", "Jane Doe");
       
        public MainWindow()
        {
            InitializeComponent();
            DefaultUserWorkouts(testuser);
            User.ActiveUsers.Add(testuser);
            
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
                    WorkoutsWindow workoutwindow = new WorkoutsWindow(adminUser);
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
        private void DefaultUserWorkouts(User user)
        {
            var workout1 = new CardioWorkout(new DateTime(2024, 5, 6), "Cardio", "Springtur i parken", TimeSpan.FromMinutes(20), 0, 20);
            var workout2 = new StrengthWorkout(new DateTime(2024, 5, 7), "Repetitions", "Gym sesh", TimeSpan.FromMinutes(30), 0, 20);
            var workout3 = new CardioWorkout(new DateTime(2024, 5, 9), "Cardio", "Indoor walking", TimeSpan.FromMinutes(60), 0, 20);

            
            user.AddWorkout(workout1);
            user.AddWorkout(workout2);
            user.AddWorkout(workout3);
        }

    }
}