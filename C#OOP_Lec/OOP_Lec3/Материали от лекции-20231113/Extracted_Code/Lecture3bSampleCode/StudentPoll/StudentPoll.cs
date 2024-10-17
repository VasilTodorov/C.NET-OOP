// Fig. 8.8: StudentPoll.cs
// Poll analysis application.
using System;

public class StudentPoll
{
   public static void Main( string[] args )
   {
      // student response array (more typically, input at run time)
      int[] responses = { 1, 2, 5, 4, 3, 5, 2, 1, 3, 3, 1, 4, 3, 3, 3, 
         2, 3, 3, 2, 14 };
      int[] frequency = new int[ 6 ]; // array of frequency counters

      // for each answer, select responses element and use that value 
      // as frequency index to determine element to increment
      for ( int answer = 0; answer < responses.Length; ++answer )
      {
         try
         {
            ++frequency[ responses[ answer ] ];
         } // end try
         catch ( IndexOutOfRangeException ex )
         {
            Console.WriteLine( ex.Message );
            Console.WriteLine("   responses({0}) = {1}\n",
               answer, responses[ answer ] );
         } // end catch
      } // end for

      Console.WriteLine( "{0}{1,10}", "Rating", "Frequency" );

      // output each array element's value
      for ( int rating = 1; rating < frequency.Length; ++rating )
         Console.WriteLine( "{0,6}{1,10}", rating, frequency[ rating ] );
   } // end Main
} // end class StudentPoll

 