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
