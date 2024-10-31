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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FitTrack
{
    public partial class WorkoutDetailsWindow : Window
    {
        private bool isEdit = false;
        public WorkoutDetailsWindow(Workout selectedWorkout)
        {
            InitializeComponent();
            DataContext = selectedWorkout;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Workout details saved successfully!");
            EditButton_Click(sender, e);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
             isEdit = !isEdit;

            //Aktiverar edit
            DateTextBox.IsReadOnly = !isEdit;
            TypeTextBox.IsReadOnly = !isEdit;
            DurationTextBox.IsReadOnly = !isEdit;
            CaloriesTextBox.IsReadOnly = !isEdit;
            DistanceTextBox.IsReadOnly = !isEdit;
            RepetitionsTextBox.IsReadOnly = !isEdit;
            NotesTextBox.IsReadOnly = !isEdit;

            // Uppdaterar buttons
            EditButton.Content = isEdit ? "Cancel" : "Edit";
            SaveButton.IsEnabled = isEdit;
        }
    }
}


    