using System;
using System.ComponentModel;

namespace CustomEvent
{
    class Room
    {
        public event Action<object> Alert;
        private int temperature;
        public int Temperature
        {
            get { return this.temperature; }
            set
            {
                this.temperature = value;
                if (temperature > 60)
                {
                    Alert?.Invoke(this);
                }
            }
        }
    }
}
