// Fig. 8.6: BarChart.cs
// Bar chart displaying application.
using System;

public class BarChart
{
   public static void Main( string[] args )
   {
      int[] array = { 0, 0, 0, 0, 0, 0, 1, 2, 4, 2, 1 }; // distribution

      Console.WriteLine( "Grade distribution:" );

      // for each array element, output a bar of the chart
      for ( int counter = 0; counter < array.Length; ++counter )
      {
         // output bar labels ( "00-09: ", ..., "90-99: ", "100: " )
         if ( counter == 10 )
            Console.Write( "  100: " );
         else
            Console.Write( "{0:D2}-{1:D2}: ",
               counter * 10, counter * 10 + 9 );

         // display bar of asterisks
         for ( int stars = 0; stars < array[ counter ]; ++stars )
            Console.Write( "*" );

         Console.WriteLine(); // start a new line of output
      } // end outer for
   } // end Main
} // end class BarChart
 