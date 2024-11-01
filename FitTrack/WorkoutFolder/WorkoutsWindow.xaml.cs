using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class WorkoutsWindow : Window, INotifyPropertyChanged
    {
        // Håller listan av workouts. Updaterar även ui automatiskt efter inmatning.
        public ObservableCollection<Workout> WorkoutList { get; set; } = new ObservableCollection<Workout>();
        //Förvarar inloggade användaren(admin eller vanlig).
        public User thisUser;
        


        public Workout SelectedWorkout
        {
            get { return _selectedWorkout; }
            set
            {
                _selectedWorkout = value;
                OnPropertyChanged(nameof(SelectedWorkout));
            }
        }
        public Workout _selectedWorkout;
        
        //Konstruktor som initierar fönstret och dess komponenter.
        public WorkoutsWindow(User user)
        {
            InitializeComponent();

            this.thisUser = user;
            //ger listan baserad på vem som är användaren.
            getWorkouts();
            



            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                var allWorkouts = adminUser.ManageAllWorkouts();
                foreach (var workout in allWorkouts)
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
            if (SelectedWorkout != null)
            {
                WorkoutDetailsWindow detailsWindow = new WorkoutDetailsWindow(SelectedWorkout);
                detailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a workout to view details.");
            }

        }


        private void userdetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userdetailswindow = new UserDetailsWindow(thisUser);
            userdetailswindow.Show();
            this.Close();
        }

        private void Infobtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("FitTrack is a startup company based in Switzerland that provides users across the EU and EEUA, Workout Management. \n " +
                "You use the app by first register new account. Then you login and add your first workout in Add Workout. You can view details of the workout in Workout details. \n" +
                "In User Details you can change username, country and password.");
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