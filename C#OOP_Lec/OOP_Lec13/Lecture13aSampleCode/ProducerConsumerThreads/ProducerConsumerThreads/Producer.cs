// Fig. 15.5: Producer.cs
// Producer produces ten integer values in the shared buffer.
using System;
using System.Threading;
namespace Buffer
{
    // class Producer's Produce method controls a thread that
    // stores values from 1 to 10 in sharedLocation
    public class Producer
    {
        private readonly IBuffer sharedLocation;
        private readonly Random randomSleepTime;

        // constructor
        public Producer(IBuffer shared, Random random)
        {
            sharedLocation = shared;
            randomSleepTime = random;
        } // end constructor

        // store values 1-10 in object sharedLocation
        public void Produce()
        {
            // sleep for random interval up to 3000 milliseconds
            // then set sharedLocation's Buffer property
            for (int count = 1; count <= 10; count++)
            {
                Thread.Sleep(randomSleepTime.Next(1, 3001));
                sharedLocation.Buffer = count;
            } // end for

            Console.WriteLine("{0} done producing.\nTerminating {0}.",
               Thread.CurrentThread.Name);
        } // end method Produce
    } // end class Producer
}