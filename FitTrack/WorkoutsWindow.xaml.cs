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


        public WorkoutsWindow()
        {
            InitializeComponent();

            
            

            DataContext = this;
        }

        
        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addworkoutwin = new AddWorkoutWindow();
            addworkoutwin.Show();


        } 

        
        private void RemoveWorkout_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
        private void OpenDetails_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void userdetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Infobtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }





    
}