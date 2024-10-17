// Fig. 15.12: CircularBufferTest.cs
// Implementing the producer/consumer relationship with a
// circular buffer.
using System;
using System.Threading;
namespace Buffer
{
    class CircularBufferTest
    {
        // create producer and consumer threads and start them

        static void Main()
        {
            // create shared object used by threads
            CircularBuffer shared = new CircularBuffer();

            // Random object used by each thread
            Random random = new Random();

            // display shared state before producer
            // and consumer threads begin execution
            Console.Write(shared.CreateStateOutput());

            // create Producer and Consumer objects
            Producer producer = new Producer(shared, random);
            Consumer consumer = new Consumer(shared, random);

            // create threads for producer and consumer and set 
            // delegates for each thread
            Thread producerThread =
               new Thread(new ThreadStart(producer.Produce));
            producerThread.Name = "Producer";

            Thread consumerThread =
               new Thread(new ThreadStart(consumer.Consume));
            consumerThread.Name = "Consumer";

            // start each thread
            producerThread.Start();
            consumerThread.Start();
        } // end Main
    } // end class CircularBufferTest
}