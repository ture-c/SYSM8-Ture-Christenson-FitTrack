using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace FitTrack
{ 
    internal class Person1
    {
        public abstract class Person
        {

            public string Username { get; set; }
            public string Password { get; set; }

            public Person(string username, string password)
            {
                Username = username;
                Password = password;


            }
            public virtual void SignIn(string username, string password, MainWindow mainWindow)
            {
                
                if (Username == username && Password == password)
                {
                    WorkoutsWindow workoutwin = new WorkoutsWindow();
                    workoutwin.Show();
                    mainWindow.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            


        }
        public class User : Person
        {
            public string Country { get; set; }
            public string SecurityQuestion { get; set; }
            public string SecurityAnswer { get; set; }


            public User(string username, string password, string country, string SecurityQuestion, string SecurityAnswer) 
                : base(username, password)
            {
                Country = country;
                this.SecurityQuestion = SecurityQuestion;
                this.SecurityAnswer = SecurityAnswer;
            }

            



            public void RegisterUser(RegisterWindow registerwindow, string confirmPassword)
            {
                string username = registerwindow.UsernameTextBox.Text;
                string password = registerwindow.PasswordBox.Password;
                
            
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                    MessageBox.Show("Username and password cannot be empty.");
                    return;
                    }

                    if (password.Length < 8)
                    {
                    MessageBox.Show("Password must be at least 8 characters.");
                    return;
                    }
                string specialCharacters = "@\\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                bool hasSpecialChar = false;
                bool hasNum = false;

                foreach (char c in password)
                {
                    if (specialCharacters.Contains(c))
                    {
                        hasSpecialChar = true;
                    }
                    if (char.IsDigit(c))
                    {
                        hasNum = true;
                    }

                }
                if (!hasSpecialChar || !hasNum)
                {
                    MessageBox.Show("Must contain a number and special character.");
                }

                    


                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }



                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                registerwindow.Close();
            }

            public void ResetPassword()
            {
                if (SecurityQuestion == SecurityAnswer)
                {

                }
            }


        

            



            //public class AdminUser : Person
            //{
            //    public override void SignIn()
            //    {
            //        return;
            //    }

            //    public void ManageAllWorkouts()
            //    {

            //        return;
            //    }

            //}

        }
    }
}
