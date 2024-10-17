using System.Windows.Controls;

namespace DelegatesWPFlab
{
    public class Clock
	{
		private Ticker pulsed ;
        private TextBox display;
        
        public Clock(TextBox displayBox)
        {  
            pulsed = new Ticker();
            this.display = displayBox;
        }

        public void Start()
		{
            // To do
            pulsed.Add(RefreshTime);
        }

		public void Stop()
		{
            // To do
            //pulsed.Remove(RefreshTime);
            //pulsed = null!;
            // version 2
           while(pulsed!= null)
            {
                pulsed.Remove(RefreshTime);
            }
        }

		private void RefreshTime(int hh, int mm, int ss)
		{
			this.display.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
		}


    }
}
