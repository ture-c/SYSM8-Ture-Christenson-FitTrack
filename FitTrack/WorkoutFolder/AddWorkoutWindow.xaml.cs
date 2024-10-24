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
        private WorkoutsWindow parentWindow; //Refererar till förälderfönstret
        public AddWorkoutWindow(WorkoutsWindow parent)
        {
            InitializeComponent();
            parentWindow = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SaveWorkout();
        }


        public void SaveWorkout()
        {
            try
            {
                if (string.IsNullOrEmpty(DateInput.Text) || !DateTime.TryParse(DateInput.Text, out DateTime dateInput))
                {
                    MessageBox.Show("Please enter a valid date.");
                    return;
                }

                string workoutType = WorkoutTypeComboBox.Text;
                if (string.IsNullOrEmpty(workoutType))
                {
                    MessageBox.Show("Please select a workout type.");
                    return;
                }

                
                if (string.IsNullOrEmpty(DurationInput.Text) || !double.TryParse(DurationInput.Text, out double durationMinutes))
                {
                    MessageBox.Show("Please enter a valid duration.");
                    return;
                }
                TimeSpan duration = TimeSpan.FromMinutes(durationMinutes);

               
                if (string.IsNullOrEmpty(CaloriesBurnedInput.Text) || !int.TryParse(CaloriesBurnedInput.Text, out int caloriesBurned))
                {
                    MessageBox.Show("Please enter a valid number of calories burned.");
                    return;
                }

                string notes = NotesInput.Text;

                
                Workout work;

                if (workoutType == "Cardio")
                {
                    
                    if (string.IsNullOrEmpty(DistanceInput.Text) || !int.TryParse(DistanceInput.Text, out int distance))
                    {
                        MessageBox.Show("Please enter a valid distance for Cardio.");
                        return;
                    }

                    work = new CardioWorkout(dateInput, workoutType, notes, duration, caloriesBurned, distance);
                }
                else if (workoutType == "Strength")
                {
                    
                    if (string.IsNullOrEmpty(RepetitionsInput.Text) || !int.TryParse(RepetitionsInput.Text, out int repetitions))
                    {
                        MessageBox.Show("Please enter a valid number of repetitions for Strength.");
                        return;
                    }

                    work = new StrengthWorkout(dateInput, workoutType, notes, duration, caloriesBurned, repetitions);
                }
                else
                {
                    MessageBox.Show("Invalid workout type.");
                    return;
                }

                
                parentWindow.AddWorkoutToList(work);
                MessageBox.Show("Workout saved successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void WorkoutTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWorkoutType = ((ComboBoxItem)WorkoutTypeComboBox.SelectedItem).Content.ToString();

            if (selectedWorkoutType == "Cardio")
            {
                DistanceInput.Visibility = Visibility.Visible;
                RepetitionsInput.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                DistanceInput.Visibility = Visibility.Collapsed;
                RepetitionsInput.Visibility = Visibility.Visible;
            }
        }
    }
}
