using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public virtual void SignIn()
            {

            }

        }
        public class User : Person
        {
            public string Country {  get; set; }
            public string SecurityQuestion { get; set; }
            public string SecurityAnswer { get; set; }

            public override void SignIn()
            {
               
            }

            public void ResetPassword() 
            { 
                if(SecurityAnswer == SecurityAnswer)
                {

                }
            }
            public class AdminUser : Person
            {
                public override void SignIn()
                {
                    
                }

                public void ManageAllWorkouts()
                {


                }

            }

    }
}
