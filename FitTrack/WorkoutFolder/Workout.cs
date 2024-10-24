using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public abstract class Workout1
    {
        public abstract class Workout
        {
            public DateTime Date { get; set; }
            public string Type { get; set; }
            public string Notes { get; set; }
            public TimeSpan Duration { get; set; }

            public int Calories { get; set; }

            public Workout(DateTime date, string type, string notes, TimeSpan duration, int calories)
            {
                Date = date;
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

            public CardioWorkout(DateTime date, string type, string notes, TimeSpan duration, int calories, int distance)
        : base(date, type, notes, duration, calories)
            {
                Distance = distance;
            }
            public override int CalculateCaloriesBurned()
            {

                return (int)(Distance * 0.7 * Duration.TotalMinutes);
            }


        }
        public class StrengthWorkout : Workout
        {
            public int Repetitions { get; set; }

            public StrengthWorkout(DateTime date, string type, string notes, TimeSpan duration, int calories, int repetitions)
        : base(date, type, notes, duration, calories)
            {
                Repetitions = repetitions;
            }
            public override int CalculateCaloriesBurned()
            {

                return (int)(Repetitions * 0.5 * Duration.TotalMinutes);



            }
        }

    }
}

