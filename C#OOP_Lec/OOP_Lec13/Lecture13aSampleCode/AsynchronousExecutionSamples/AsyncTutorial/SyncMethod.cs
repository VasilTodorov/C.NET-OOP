using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTutorial
{
    class SyncMethod
    {
        int count = 0;

        /// <summary>
        /// Increments the value of count in a thread-safe manner.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Increment()
        {
            count++;
        }

        /// <summary>
        /// Gets the current value of count.
        /// </summary>
        public int Count
        {
            get { return count; }
        }
    }
}
