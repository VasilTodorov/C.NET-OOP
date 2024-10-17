// Fig. 15.13: RandomLetters.cs
// Writes a random letter to a WPF label
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;
namespace WpfGUIThreads
{
    public class RandomLetters
    {
        private static Random generator = new Random(); // for random letters
        private bool suspended = false; // true if thread is suspended
        private Label output; // Label to display output
        private string threadName; // name of the current thread

        // RandomLetters constructor
        public RandomLetters(Label label)
        {
            output = label;
        } // end 

        // place random characters in GUI
        public void GenerateRandomCharacters()
        {
            // get name of executing thread
            threadName = Thread.CurrentThread.Name;

            while (true) // infinite loop; will be terminated from outside
            {
                // sleep for up to 1 second
                Thread.Sleep(generator.Next(1001));

                lock (this) // obtain lock
                {
                    while (suspended) // loop until not suspended
                    {
                        Monitor.Wait(this); // suspend thread execution
                    } // end while
                } // end lock

                // select random uppercase letter
                char displayChar = (char)(generator.Next(26) + 65);

                // display character on corresponding Label
                output.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                       new Action<char>((f) => { output.Content = threadName + ": " + f; }),
                       displayChar);
            } // end while
        } // end method GenerateRandomCharacters

        // change the suspended/running state
        public void Toggle()
        {
            suspended = !suspended; // toggle bool controlling state

            // change label color on suspend/resume
            output.Background = suspended ?
                           Brushes.Red : Brushes.LightGreen; // set the Background
            lock (this) // obtain lock
            {
                if (!suspended) // if thread resumed
                    Monitor.Pulse(this);
            } // end lock
        } // end method Toggle
    } // end class RandomLetters
}
