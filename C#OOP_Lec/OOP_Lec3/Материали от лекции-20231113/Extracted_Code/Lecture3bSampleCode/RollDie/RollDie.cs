// Fig. 8.7: RollDie.cs
// Roll a six-sided die 6,000,000 times.
using System;

public class RollDie
{
   public static void Main( string[] args )
   {
      Random randomNumbers = new Random(); // random number generator
      int[] frequency = new int[ 7 ]; // array of frequency counters

      // roll die 6,000,000 times; use die value as frequency index
      for ( int roll = 1; roll <= 6000000; ++roll )
         ++frequency[ randomNumbers.Next( 1, 7 ) ];

      Console.WriteLine( "{0}{1,10}", "Face", "Frequency" );

      // output each array element's value
      for ( int face = 1; face < frequency.Length; ++face )
         Console.WriteLine( "{0,4}{1,10}", face, frequency[ face ] );
   } // end Main
} // end class RollDie
 