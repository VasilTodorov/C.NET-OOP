using System;

namespace PassDataEventHandler
{
    class  HotelData : EventArgs
    {
        public string HotelName { get; set; }
        public int TotalRooms { get; set; }
    }

}
