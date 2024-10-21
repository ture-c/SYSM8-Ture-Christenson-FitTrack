using System;
using System.Collections.Generic;
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
using static FitTrack.Workout1;

namespace FitTrack
{

    public partial class AddWorkoutWindow : Window
    {
        public AddWorkoutWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SaveWorkout();
        }



        public void SaveWorkout()
        {
            string workoutType = WorkoutTypeComboBox.Text;
            TimeSpan duration = TimeSpan.FromMinutes(double.Parse(DurationInput.Text)); 
            int caloriesBurned = int.Parse(CaloriesBurnedInput.Text); 
            string notes = NotesInput.Text; 

            Workout work;

            
            int distance = 0;
            int repetitions = 0;

            if (workoutType == "Cardio")
            {
                distance = int.Parse(DistanceInput.Text); 
                work = new CardioWorkout(workoutType, notes, duration, caloriesBurned, distance);
            }
            else
            {
                repetitions = int.Parse(RepetitionsInput.Text); 
                work = new StrengthWorkout(workoutType, notes, duration, caloriesBurned, repetitions);
            }

            MessageBox.Show("Workout saved successfully.");
            this.Close();
        }
    }
}
