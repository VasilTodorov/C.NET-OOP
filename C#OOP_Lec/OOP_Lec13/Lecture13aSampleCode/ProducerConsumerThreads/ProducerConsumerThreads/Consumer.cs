// Fig. 15.6: Consumer.cs
// Consumer consumes ten integer values from the shared buffer.
using System;
using System.Threading;
namespace Buffer
{

    // class Consumer's Consume method controls a thread that
    // loops ten times and reads a value from sharedLocation
    public class Consumer
    {
        private IBuffer sharedLocation;
        private Random randomSleepTime;

        // constructor
        public Consumer(IBuffer shared, Random random)
        {
            sharedLocation = shared;
            randomSleepTime = random;
        } // end constructor

        // read sharedLocation's value ten times
        public void Consume()
        {
            int sum = 0;

            // sleep for random interval up to 3000 milliseconds then
            // add sharedLocation's Buffer property value to sum
            for (int count = 1; count <= 10; count++)
            {
                Thread.Sleep(randomSleepTime.Next(1, 3001));
                sum += sharedLocation.Buffer;
            } // end for

            Console.WriteLine(
               "{0} read values totaling: {1}.\nTerminating {0}.",
               Thread.CurrentThread.Name, sum);
        } // end method Consume
    } // end class Consumer
}