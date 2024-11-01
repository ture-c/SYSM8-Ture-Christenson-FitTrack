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
using static FitTrack.Workout;
using static FitTrack.WorkoutsWindow;
using System.Collections.ObjectModel;

namespace FitTrack
{
    public class Person1
    {
        public abstract class Person
        {

            public string Username { get; set; }
            public string Password { get; set; }

            //Konstruktor
            public Person(string username, string password)
            {
                Username = username;
                Password = password;


            }

            public virtual bool SignIn(string username, string password)
            {
                return Username.Equals(username, StringComparison.OrdinalIgnoreCase) && Password == password;


            }




        }
        public class User : Person
        {
            public string Country { get; set; }
            public string SecurityQuestion { get; private set; }
            public string SecurityAnswer { get; private set; }

            //Konstruktor
            public User(string username, string password, string country, string SecurityQuestion, string SecurityAnswer)
                : base(username, password)
            {
                Country = country;
                this.SecurityQuestion = SecurityQuestion;
                this.SecurityAnswer = SecurityAnswer;
            }

            //Listan av användarer
            public static List<User> ActiveUsers = new List<User>();
            public static List<Workout> AllWorkouts = new List<Workout>();
            public List<Workout> WorkoutList { get; private set; } = new List<Workout>();



            public override bool SignIn(string username, string password)
            {
                return base.SignIn(username, password);
            }


            public void AddWorkout(Workout workout)
            {
                WorkoutList.Add(workout);
                AllWorkouts.Add(workout);
            }

            public void Register(string username, string password, string country, string securityQuestion, string securityAnswer)
            {
                //Ser om användarnamn redan finns
                if (ActiveUsers.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                //när isFilled och Security är klar så skapas en ny användare
                if (isFilled(username, password, country) && Security(securityQuestion, securityAnswer))
                {


                    User newUser = new User(username, password, country, securityQuestion, securityAnswer);
                    ActiveUsers.Add(newUser);
                    MessageBox.Show("User registered successfully!");


                }

            }

            // Ser till så att användaren har fyllt i alla boxar samt fyllt i kriterier som exempelvis lösenordets längd i RegisterWindow och userwindow.
            public bool isFilled(string username, string password, string country)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(country))
                {
                    MessageBox.Show("All fields must be filled out.");
                    return false;
                }

                if (password.Length < 8)
                {
                    MessageBox.Show("Password must be at least 8 characters.");
                    return false;
                }

                string specialCharacters = "@\\|!#$%&/()=?»«@£§€{}.-;'<>_,";

                bool hasSpecialChar = false;
                foreach (char c in password)
                {
                    if (specialCharacters.Contains(c))
                    {
                        hasSpecialChar = true;
                        break;
                    }
                }


                bool hasNum = password.Any(char.IsDigit);

                if (!hasSpecialChar || !hasNum)
                {
                    MessageBox.Show("Password must contain at least one special character and one number.");
                    return false;
                }

                return true;
            }
            public bool Security(string securityQuestion, string securityAnswer)
            {
                if (string.IsNullOrEmpty(securityQuestion) || string.IsNullOrEmpty(securityAnswer))
                {
                    MessageBox.Show("All fields must be filled out.");
                    return false;
                }

                return true;

            }

            //Comboboxlista som används i register och new userwindow. 
            public void LoadCountryList(ComboBox countryComboBox)
            {
                try
                {
                    List<string> countryList = new List<string>
                    {
                    "Austria", "Belgium",
                        "Bulgaria", "Croatia",
                    "Cyprus", "Czech Republic",
                        "Denmark", "Estonia",
                    "Finland", "France",
                        "Germany", "Greece",
                    "Hungary", "Ireland",
                        "Italy", "Latvia",
                    "Lithuania", "Luxembourg",
                        "Malta", "Netherlands",
                    "Poland", "Portugal",
                        "Romania", "Slovakia",
                    "Slovenia", "Spain",
                        "Sweden", "Iceland",
                    "Liechtenstein", "Norway",
                        "Switzerland"
                                                        };

                    countryList.Sort();
                    countryComboBox.ItemsSource = countryList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading country list: {ex.Message}");
                }
            }


            public bool ResetPassword(string username, string answer, string newPassword)
            {


                // Ser så att säkerhetssvaret och användarnamnet överrensstämmer.
                foreach (User user in User.ActiveUsers)
                {
                    if (user.Username == username && user.SecurityAnswer == answer)
                    {
                        user.Password = newPassword;
                        MessageBox.Show("Reset successful!");
                        return true;
                    }
                    
                }

                MessageBox.Show("Wrong Username Or Answer.");
                return false;
            }


        }


        public class AdminUser : User
        {
            public bool Admin { get; set; }
            public AdminUser(string username, string password, string country, string securityQuestion, string securityAnswer, bool admin)
                : base(username, password, country, securityQuestion, securityAnswer)
            {
                Admin = admin;
            }

            public List<Workout> ManageAllWorkouts()
            {
                return Admin ? User.AllWorkouts : new List<Workout>();
            }

        }
    }
}
    
