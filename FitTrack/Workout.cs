using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    internal class Workout1
    {
        public abstract class Workout
        {
            public string Type { get; set; }
            public string Notes { get; set; }
            public TimeSpan Duration { get; set; }

            public int Calories { get; set; }

            public Workout(string type, string notes, TimeSpan duration, int calories)
            {
                Type = type;
                Notes = notes;
                Duration = duration;
                Calories = calories;
            }
            public abstract int CalculateCaloriesBurned();

        }
        public class CardioWorkout : Workout
        {
            public int Distance { get; set; }

            public CardioWorkout(string type, string notes, TimeSpan duration, int calories, int distance)
        : base(type, notes, duration, calories)
            {
                Distance = distance;
            }
            public override int CalculateCaloriesBurned()
            {

                return (int)(Duration.TotalMinutes * Distance);
            }


        }
        public class StrengthWorkout : Workout
        {
            public int Repetitions { get; set; }

            public StrengthWorkout(string type, string notes, TimeSpan duration, int calories, int repetitions)
        : base(type, notes, duration, calories)
            {
                Repetitions = Repetitions;
            }
            public override int CalculateCaloriesBurned()
            {

                return (int)(Duration.TotalMinutes * Repetitions);



            }
        }
    }
}

    