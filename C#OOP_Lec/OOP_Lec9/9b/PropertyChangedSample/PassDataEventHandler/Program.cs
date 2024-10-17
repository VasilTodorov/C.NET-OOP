using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDataEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Room room = new Room();
            room.Alert += OnAlert;
            room.Temperature = 75;
        }
        private static void OnAlert(object sender, EventArgs e)
        {
            Room room = (Room)sender;
            HotelData data = (HotelData)e;
            Console.WriteLine("Shutting down, Room temp = {0}", room.Temperature);
            Console.WriteLine("{0} has total {1} rooms", data.HotelName, data.TotalRooms);
        }
    }
}

