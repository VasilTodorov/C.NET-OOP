using System;
using System.Collections;
using System.Timers;
using System.Windows.Threading;

namespace DelegatesWPFlab
{
	public class Ticker
	{
        public delegate void Tick(int hh, int mm, int ss);

        private Tick? tickers;
        private readonly DispatcherTimer ticking;

        public Ticker()
		{
            ticking = new DispatcherTimer(); 
            ticking.Tick += this.OnTimedEvent!;
            ticking.Interval = new TimeSpan(0, 0, 1); // 1 second
            ticking.Start();
        }

		public void Add(Tick newMethod)
		{
			this.tickers += newMethod;
		}
		
		public void Remove(Tick oldMethod)
		{
			tickers -= oldMethod;
		}

		private void Notify(int hours, int minutes, int seconds)
		{
            if (tickers != null)
                tickers(hours, minutes, seconds);
        }
	
		private void OnTimedEvent(object source, EventArgs args)
		{
            DateTime now = DateTime.Now;
            int hh = now.Hour;
            int mm = now.Minute;
            int ss = now.Second;
            Notify(hh, mm, ss);
		}


	}
}
