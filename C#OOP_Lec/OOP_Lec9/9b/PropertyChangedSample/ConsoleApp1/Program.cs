using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Room myRoom = new Room();
            //Subcribe to an event
            myRoom.Alert += OnAlert;
            //Alert Event will invoke
            myRoom.Temperature = 65;
        }
        private static void OnAlert(object o)
        {
            Room room = (Room)o;
            Console.WriteLine("Shutting down. Room temp is {0}", room.Temperature);
        }
    }
}
