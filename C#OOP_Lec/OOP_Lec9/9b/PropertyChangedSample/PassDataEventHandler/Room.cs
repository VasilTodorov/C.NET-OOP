using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDataEventHandler
{
    class Room
    {
        public event EventHandler Alert;
        private int temperature;
        public int Temperature
        {
            get { return this.temperature; }
            set
            {
                this.temperature = value;
                if (this.Temperature > 60)
                {
                    if (Alert != null)
                    {
                        HotelData data = new HotelData
                        {
                            HotelName = "5 Star Hotel",
                            TotalRooms = 450
                        };
                        //Pass event data
                        Alert(this, data);
                    }
                }
            }
        }
    }
}
