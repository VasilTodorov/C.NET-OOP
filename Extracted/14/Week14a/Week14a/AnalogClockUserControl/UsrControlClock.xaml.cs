using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AnalogClockUserControl
{
    /// <summary>
    /// Interaction logic for UsrControlClock.xaml
    /// </summary>
    public partial class UsrControlClock : UserControl
    {
        private bool suspended = false;
        public UsrControlClock()
        {
            InitializeComponent();
            Thread clock = new Thread(new ThreadStart( SetTime));
            clock.Start();
        }

        private void SetTime()
        {
            if (HourHand == null || 
                MinHand  == null || 
                SecHand == null) { return; }
            
            while (true)// TicTac
            {
                lock (this)
                {
                    while (suspended)
                    {
                        Monitor.Wait(this);
                    }
                }
                AdjustClockHands();
                Thread.Sleep(1000);
            }
        }

        private void AdjustClockHands()
        {
            try
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    var hour = DateTime.Now.Hour;
                    var minute = DateTime.Now.Minute;
                    var second = DateTime.Now.Second;
                    HourHand.Angle = hour * 30 + minute * 0.5;
                    MinHand.Angle = minute * 6;
                    SecHand.Angle = second * 6;
                }));
            }
            catch (ThreadInterruptedException e){
                Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            }

        
        }

        public void Resume()
        {
            lock (this)
            {
                if (suspended)
                {
                    Monitor.Pulse(this);
                }
            }
            suspended = false;
        }

        public void Stop()
        {
            if (!suspended) { suspended = true; }
        }
    }
}
