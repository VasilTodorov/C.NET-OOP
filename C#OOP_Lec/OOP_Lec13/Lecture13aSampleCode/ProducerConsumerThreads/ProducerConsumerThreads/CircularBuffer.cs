// Fig. 15.11: CircularBuffer.cs
// A circular shared buffer for the producer/consumer relationship.
using System;
using System.Threading;

namespace Buffer
{
    // implement the an array of shared integers with synchronization
    public class CircularBuffer : IBuffer
    {
        // each array element is a buffer
        private readonly int[] buffers = { -1, -1, -1 };

        // occupiedBufferCount maintains count of occupied buffers
        private int occupiedBufferCount = 0;

        private int readLocation = 0; // location of the next read
        private int writeLocation = 0; // location of the next write

        // property Buffer
        public int Buffer
        {
            get
            {
                // lock this object while getting value 
                // from buffers array
                lock (this)
                {
                    // if there is no data to read, place invoking 
                    // thread in WaitSleepJoin state
                    if (occupiedBufferCount == 0)
                    {
                        Console.Write("\nAll buffers empty. {0} waits.",
                           Thread.CurrentThread.Name);
                        Monitor.Wait(this); // enter the WaitSleepJoin state
                    } // end if

                    // obtain value at current readLocation
                    int readValue = buffers[readLocation];

                    Console.Write("\n{0} reads {1} ",
                       Thread.CurrentThread.Name, buffers[readLocation]);

                    // just consumed a value, so decrement number of 
                    // occupied buffers
                    --occupiedBufferCount;

                    // update readLocation for future read operation,
                    // then add current state to output
                    readLocation = (readLocation + 1) % buffers.Length;
                    Console.Write(CreateStateOutput());

                    // return waiting thread (if there is one) 
                    // to Running state
                    Monitor.Pulse(this);

                    return readValue;
                } // end lock
            } // end get
            set
            {
                // lock this object while setting value 
                // in buffers array
                lock (this)
                {
                    // if there are no empty locations, place invoking
                    // thread in WaitSleepJoin state
                    if (occupiedBufferCount == buffers.Length)
                    {
                        Console.Write("\nAll buffers full. {0} waits.",
                           Thread.CurrentThread.Name);
                        Monitor.Wait(this); // enter the WaitSleepJoin state
                    } // end if

                    // place value in writeLocation of buffers
                    buffers[writeLocation] = value;

                    Console.Write("\n{0} writes {1} ",
                       Thread.CurrentThread.Name, buffers[writeLocation]);

                    // just produced a value, so increment number of 
                    // occupied buffers
                    ++occupiedBufferCount;

                    // update writeLocation for future write operation,
                    // then add current state to output
                    writeLocation = (writeLocation + 1) % buffers.Length;
                    Console.Write(CreateStateOutput());

                    // return waiting thread (if there is one) 
                    // to Running state
                    Monitor.Pulse(this);
                } // end lock
            } // end set
        } // end property Buffer

        // create state output
        public string CreateStateOutput()
        {
            // display first line of state information
            string output = "(buffers occupied: " +
               occupiedBufferCount + ")\nbuffers: ";

            for (int i = 0; i < buffers.Length; i++)
                output += " " + string.Format("{0,2}", buffers[i]) + "  ";

            output += "\n";

            // display second line of state information
            output += "         ";

            for (int i = 0; i < buffers.Length; i++)
                output += "---- ";

            output += "\n";

            // display third line of state information
            output += "         ";

            // display readLocation (R) and writeLocation (W)
            // indicators below appropriate buffer locations
            for (int i = 0; i < buffers.Length; i++)
            {
                if (i == writeLocation &&
                   writeLocation == readLocation)
                    output += " WR  ";
                else if (i == writeLocation)
                    output += " W   ";
                else if (i == readLocation)
                    output += "  R  ";
                else
                    output += "     ";
            } // end for

            output += "\n";
            return output;
        } // end method CreateStateOutput
    } // end class HoldIntegerSynchronized
}