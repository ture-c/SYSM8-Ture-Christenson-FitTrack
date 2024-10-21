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

namespace FitTrack
{
    public partial class WorkoutsWindow : Window
    {
        public string UserNameInput { get; set; }
        public string PasswordInput { get; set; }
        public string ConfirmPasswordInput { get; set; }
        public string CountryCombobox { get; set; }

        public ObservableCollection<Workout> WorkoutList { get; set; }

        public WorkoutsWindow()
        {
            InitializeComponent();

            
            WorkoutList = new ObservableCollection<Workout>
            {
                
            };

            DataContext = this;
        }

        
        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addworkoutwin = new AddWorkoutWindow();
            addworkoutwin.Show();


        } 

        
        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            if (workoutDataGrid.SelectedItem != null)
            {
                Workout selectedWorkout = (Workout)workoutDataGrid.SelectedItem;
                WorkoutList.Remove(selectedWorkout); 
                MessageBox.Show("Workout removed!");
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
        private void OpenDetails_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void userdetails_Click(object sender, RoutedEventArgs e)
        {

        }
    }


    public class Workout
    {
        public string Type { get; set; }
        public string Notes { get; set; }
        public TimeSpan Duration { get; set; }

        public int Calories { get; set; }

        public Workout(string type, string notes, TimeSpan duration, int calories)
        {
            Type = type;
            Notes = notes;
            Duration = duration;
            Calories = calories;
        }
    }
}