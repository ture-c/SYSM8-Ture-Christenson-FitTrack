using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using static FitTrack.Person1;
using static FitTrack.Workout1;

namespace FitTrack
{
    public partial class AdminWindow : Window
    {
        private AdminUser thisAdminUser;

        public AdminWindow(AdminUser adminUser)
        {
            thisAdminUser = new AdminUser("admin", "password", "Sweden", "What is your pet's name?", "Fredrik");
            InitializeComponent();
            adminUser = thisAdminUser;
            LoadUsers();
            LoadWorkouts();
        }

        private void LoadUsers()
        {
            UsersListBox.ItemsSource = thisAdminUser.GetAllUsers();
        }

        private void LoadWorkouts()
        {
            WorkoutsListBox.ItemsSource = thisAdminUser.GetAllWorkouts();
        }
        
        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is User selectedUser)
            {
                thisAdminUser.RemoveUser(selectedUser);
                LoadUsers();
                LoadWorkouts();
            }
            else
            {
                MessageBox.Show("Select a user to remove.");
            }
        }
        //Tar bort vald träning samt vem den tillhör. 
        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            if (WorkoutsListBox.SelectedItem is Workout selectedWorkout &&
                UsersListBox.SelectedItem is User selectedUser)
            {
                thisAdminUser.RemoveWorkout(selectedUser, selectedWorkout);
                LoadWorkouts();
            }
            else
            {
                MessageBox.Show("Select a workout and a user to remove.");
            }
        }
    }
}
