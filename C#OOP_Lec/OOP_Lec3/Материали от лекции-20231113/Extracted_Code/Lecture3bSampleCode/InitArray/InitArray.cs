// Fig. 8.2: InitArray.cs
// Creating an array.
using System;

public class InitArray
{
   public static void Main( string[] args )
   {
      int[] array; // declare array named array

      // create the space for array and initialize to default zeros
      array = new int[ 5 ]; // 5 int elements

      Console.WriteLine( "{0}{1,8}", "Index", "Value" ); // headings

      // output each array element's value 
      for ( int counter = 0; counter < array.Length; ++counter )
         Console.WriteLine( "{0,5}{1,8}", counter, array[ counter ] );
   } // end Main
} // end class InitArray
 