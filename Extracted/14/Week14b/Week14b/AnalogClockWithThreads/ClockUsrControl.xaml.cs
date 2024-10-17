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

namespace AnalogClockWithThreads
{
    /// <summary>
    /// Interaction logic for ClockUsrControl.xaml
    /// </summary>
    public partial class ClockUsrControl : UserControl
    {
        private bool suspended;
        public ClockUsrControl()
        {
            InitializeComponent();
            Thread tictac = new Thread(TicTac);
             tictac.Start();
          
        }

        private void TicTac()
        {
            if (HourHand == null || MinuteHand == null || SecondHand == null)
            { return; }
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    while (suspended)
                    {
                        lock (this)
                        {
                            Monitor.Wait(this);
                        }

                    }
                    MoveClockHands();
                }
                catch (ThreadAbortException ) {

                    Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);

                }
            }
        }
        /// <summary>
        /// Will be  executed by the Current thread (not the UI thread)
        /// </summary>
        private void MoveClockHands()
        {

            this.Dispatcher.Invoke(new Action(() =>
            {
                var hour = DateTime.Now.Hour;
                var minute = DateTime.Now.Minute;
                var second = DateTime.Now.Second;
                HourHand.Angle = hour * 30 + minute * 0.5;
                MinuteHand.Angle = minute * 6;
                SecondHand.Angle = second * 6;
            }));
        }
        /// <summary>
        /// Will be  executed by the UI thread
        /// </summary>
        public void StartClock()
        {
            if (suspended)
            {
                lock (this)
                {
                    Monitor.Pulse(this);
                }
                suspended = false;
            }
        }
        /// <summary>
        /// Will be  executed by the UI thread
        /// </summary>
        public void StopClock()
        {

            suspended = true;

        }
    }
}
