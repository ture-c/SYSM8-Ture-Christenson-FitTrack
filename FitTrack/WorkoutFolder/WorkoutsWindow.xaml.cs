using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static FitTrack.Workout;


namespace FitTrack
{
    public partial class WorkoutsWindow : Window
    {
        // Håller listan av workouts. Updaterar även ui automatiskt efter inmatning.
        public ObservableCollection<Workout> WorkoutList { get; set; } = new ObservableCollection<Workout>();
        //Förvarar inloggade användaren(admin eller vanlig).
        public User thisUser;
        
        //Konstruktor som initierar fönstret och dess komponenter.
        public WorkoutsWindow(User user)
        {
            InitializeComponent();

            this.thisUser = user;
            //ger listan baserad på vem som är användaren.
            getWorkouts();

            DataContext = this;
        }

        
        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addworkoutwin = new AddWorkoutWindow(this);
            addworkoutwin.Show();


        }
        //Denna metod kollar om användaren är admin. Och då har den tillgång till alla träningspass. Samt vilken lista som ska användas.
        private void getWorkouts()
        {
            WorkoutList.Clear();  

            if (thisUser is AdminUser adminUser && adminUser.Admin)
            {
                foreach (var workout in User.AllWorkouts)
                {
                    WorkoutList.Add(workout);
                }
            }
            else
            {
                foreach (var workout in thisUser.WorkoutList)
                {
                    WorkoutList.Add(workout);
                }
            }

            workoutDataGrid.ItemsSource = WorkoutList;
        }

        //Tar bort vald träningspass.
        public void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorkout = workoutDataGrid.SelectedItem as Workout;
            if (selectedWorkout != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove?",
                     "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    WorkoutList.Remove(selectedWorkout);
                }
                else { MessageBox.Show("Please select a workout you want to remove"); }

            }
            
            
        }

        
        private void OpenDetails_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void userdetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userdetailswindow = new UserDetailsWindow(thisUser);
            userdetailswindow.Show();
            this.Close();
        }

        private void Infobtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        public void AddWorkoutToList(Workout newWorkout)
        {
            WorkoutList.Add(newWorkout);


        }
    }
    



    

}