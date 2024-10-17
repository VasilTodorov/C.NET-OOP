// Fig. 15.4: Buffer.cs
// Interface for a shared buffer of int.
using System;
namespace Buffer
{
    // this interface represents a shared buffer
    public interface IBuffer
    {
        // property Buffer
        int Buffer
        {
            get;
            set;
        } // end property Buffer
    } // end interface Buffer
}