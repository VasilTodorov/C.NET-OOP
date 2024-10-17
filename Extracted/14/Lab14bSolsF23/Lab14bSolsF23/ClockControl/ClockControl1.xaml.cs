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

namespace ClockControl
{
    /// <summary>
    /// Interaction logic for ClockControl1.xaml
    /// </summary>
    public partial class ClockControl1 : UserControl
    {
        private bool suspended;
        public ClockControl1()
        {
            InitializeComponent();
            suspended = false;
            Thread thread = new Thread(TicTac);
            thread.Start();

        }

        private void TicTac()
        {
            if (hourRot == null || minRot == null || secRot == null) { return; }

            while (true)
            {
                Thread.Sleep(1000);
                lock (this)
                {
                    while (suspended)
                    {
                        Monitor.Wait(this);
                    }
                }
                SetTime();// Move clock hands and then continue with next loop
            }
        }
        /// <summary>
        /// To be executed by the UI thread
        /// </summary>
        public void Resume()
        {
            lock (this)
            {

                if (suspended)
                {
                    suspended = false; // start thread
                    Monitor.Pulse(this);
                }
            }

        }

        public void Suspend()
        {
            suspended = true;

        }
        private void SetTime()
        {
            try
            {// delegate the work to the Dispatcher associated with the UI thread.
                this.Dispatcher.Invoke(new Action(
                    () =>

                     {
                         int hour, min, sec;
                         hour = DateTime.Now.Hour;
                         min = DateTime.Now.Minute;
                         sec = DateTime.Now.Second;

                         hourRot.Angle = hour * 30 + min * 0.5;
                         minRot.Angle = min * 6;
                         secRot.Angle = sec * 6;
                         //a synchronous operation; therefore,
                         //control will not return to the calling object
                         //until after the callback returns
                     }
               ));
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Task cancelled. ");
                Environment.Exit(0);
            }
        }
    }
}
