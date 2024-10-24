using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using static FitTrack.Person1;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

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
            public virtual void SignIn(string username, string password)
            {

            }




        }
        public class User : Person
        {
            public string Country { get; private set; }
            public string SecurityQuestion { get; private set; }
            public string SecurityAnswer { get; private set; }


            public User(string username, string password, string country, string SecurityQuestion, string SecurityAnswer)
                : base(username, password)
            {
                Country = country;
                this.SecurityQuestion = SecurityQuestion;
                this.SecurityAnswer = SecurityAnswer;
            }


            public override void SignIn(string username, string password)
            {

            }


            public bool ResetPassword(string username, string answer, string newPassword)
            {

                foreach (User user in RegisterWindow.ActiveUsers)
                {
                    if (SecurityAnswer == answer && Username == username)
                    {
                        Password = newPassword;
                        MessageBox.Show("Reset successful!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or answer.");
                        return false;
                    }

                }
                MessageBox.Show("Wrong Username Or Answer.");
                return false;



            }


            public class AdminUser : User
            {
                public AdminUser(string username, string password, string country, string securityquestion, string securityanswer)
                : base(username, password, securityanswer, securityquestion, country)
                {

                }

                public static bool IsAdmin(string username, string password)
                {
                    return true;
                }




                public void manageallusers()
                {

                }

                public void manageallworkouts()
                {


                }

            }








        }
    }
}