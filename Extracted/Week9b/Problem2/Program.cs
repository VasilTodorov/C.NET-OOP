using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Problem2
{
    internal class Program
    {
        static AlarmClock alarmClock = new AlarmClock();
        static void Main(string[] args)
        {
            Console.WriteLine("Testing alarm clock...");
           
            alarmClock.Alarm += Ring1!;
            alarmClock.PropertyChanged += ProcessRingTimeChange!;

            alarmClock.Start();
            alarmClock.RingTime = 1000;
 

        }

        public static void Ring1(object sender, AlarmEventArgs e)
        {
            var ring = e.NRings;
            Console.Beep();
            Console.WriteLine($"Ringing ... {ring} time.");
        }

        public static void ProcessRingTimeChange(object sender, PropertyChangedEventArgs e)
        {
            //var propertyName = e.PropertyName;
            Console.WriteLine($"New ringtime allocated ... current ring time is {alarmClock.RingTime} " );
        }
    }
}