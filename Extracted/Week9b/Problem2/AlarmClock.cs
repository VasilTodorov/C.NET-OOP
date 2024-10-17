using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class AlarmClock : INotifyPropertyChanged
    {
        public event EventHandler<AlarmEventArgs>? Alarm;
        public event PropertyChangedEventHandler? PropertyChanged;


        private int rings;
        private int ringTime;

        public AlarmClock()
        {
            Rings = 3;
            RingTime = 3;
        }

        #region Properties  
        public int RingTime
        {
            get { return ringTime; }
            set { ringTime = value >= 0 ? value : 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RingTime)));
            }
        }

        public int Rings
        {
            get { return rings; }
            set { rings = value >= 0 ? value : 1; }
        }
        #endregion

        protected void OnAlarm(AlarmEventArgs e)
        {
            //Invoke the event handler.
            Alarm?.Invoke(this, e);
        }


        public void Start()
        {
            // wait for time to ring
            using (var task = Task.Delay(ringTime))
            {
                task.Wait();
            }
            for (; ; )
            {
                rings--;
                if (rings < 0)
                {
                    break;
                }
                else
                { // ring as subscriber has defined
                    using (var task = Task.Delay(600))
                    {
                        task.Wait();
                    }
                    AlarmEventArgs e = new AlarmEventArgs(rings);
                    OnAlarm(e);
                }
            }
        }

    }
}
