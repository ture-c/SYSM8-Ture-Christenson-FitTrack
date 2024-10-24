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
using static FitTrack.Person1;

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private User thisUser;
        public UserDetailsWindow()
        {
            InitializeComponent();
            getUserDetails();
        }

        private void getUserDetails()
        {

            
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }



        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e) { }
        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

    }
}
