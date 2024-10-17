using System;
/*
namespace System
{
public delegate void EventHandler(object sender, EventArgs e);
}
*/
namespace EventHandlerSample
{
    class Room
    {
        // Using built-in Event
        public event EventHandler Alert;

        private int temperature;
        public int Temperature
        {
            get { return this.temperature; }
            set
            {
                this.temperature = value;
                if (this.temperature > 60)
                {
                    Alert?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
