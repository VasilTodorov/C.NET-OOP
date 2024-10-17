// Fig. 7.12: Power.vb
// Optional argument demonstration with method Power.
using System;

class CalculatePowers
{
   // call Power with and without optional arguments
   public static void Main( string[] args )
   {
      Console.WriteLine( "Power(10) = {0}", Power( 10 ) );
      Console.WriteLine( "Power(2, 10) = {0}", Power( 2, 10 ) );
   } // end Main

   // use iteration to calculate power
   public static int Power( int baseValue, int exponentValue = 2 )
   {
      int result = 1; // initialize total 

      for ( int i = 1; i <= exponentValue; i++ )
         result *= baseValue;
      
      return result; 
   } // end method Power
} // end class CalculatePowers
 