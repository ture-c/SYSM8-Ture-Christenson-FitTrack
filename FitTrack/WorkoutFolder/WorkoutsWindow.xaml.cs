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
using System.Collections.ObjectModel; //Lade till Objectmodel

namespace FitTrack
{
    public partial class WorkoutsWindow : Window
    {
        public ObservableCollection<Workout1.Workout> WorkoutList { get; set; }

        public WorkoutsWindow()
        {
            InitializeComponent();

            WorkoutList = new ObservableCollection<Workout1.Workout>();


            DataContext = this;
        }

        
        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addworkoutwin = new AddWorkoutWindow(this);
            addworkoutwin.Show();


        } 

        
        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorkout = workoutDataGrid.SelectedItem as Workout1.Workout;
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
            UserDetailsWindow userdetailswindow = new UserDetailsWindow();
            userdetailswindow.Show();
            this.Close();
        }

        private void Infobtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void AddWorkoutToList(Workout1.Workout newWorkout)
        {
            WorkoutList.Add(newWorkout); 
        }
    }





    
}