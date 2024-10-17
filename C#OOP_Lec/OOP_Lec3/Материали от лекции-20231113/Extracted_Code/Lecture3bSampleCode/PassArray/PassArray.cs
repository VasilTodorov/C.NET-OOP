// Fig. 8.13: PassArray.cs
// Passing arrays and individual array elements to methods.
using System;

public class PassArray
{
   // Main creates array and calls ModifyArray and ModifyElement
   public static void Main( string[] args )
   {
      int[] array = { 1, 2, 3, 4, 5 };

      Console.WriteLine(
         "Effects of passing reference to entire array:\n" +
         "The values of the original array are:" );

      // output original array elements 
      foreach ( int value in array )
         Console.Write( "   {0}", value );

      ModifyArray( array ); // pass array reference
      Console.WriteLine( "\n\nThe values of the modified array are:" );

      // output modified array elements 
      foreach ( int value in array )
         Console.Write( "   {0}", value );

      Console.WriteLine(
         "\n\nEffects of passing array element value:\n" +
         "array[3] before ModifyElement: {0}", array[ 3 ] );

      ModifyElement( array[ 3 ] ); // attempt to modify array[ 3 ]
      Console.WriteLine(
         "array[3] after ModifyElement: {0}", array[ 3 ] );
   } // end Main

   // multiply each element of an array by 2 
   public static void ModifyArray( int[] array2 )
   {
      for ( int counter = 0; counter < array2.Length; ++counter )
         array2[ counter ] *= 2;
   } // end method ModifyArray

   // multiply argument by 2
   public static void ModifyElement( int element )
   {
      element *= 2;
      Console.WriteLine(
         "Value of element in ModifyElement: {0}", element );
   } // end method ModifyElement  
} // end class PassArray

 