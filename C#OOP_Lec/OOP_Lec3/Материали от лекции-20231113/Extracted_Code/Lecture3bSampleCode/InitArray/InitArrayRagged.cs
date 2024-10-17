// Fig. 8.19: InitArray.cs
// Initializing rectangular and jagged arrays.
using System;

public class InitArray
{
   // create and output rectangular and jagged arrays
   public static void Main( string[] args )
   {
      // with rectangular arrays,
      // every row must be the same length.
      int[ , ] rectangular = { { 1, 2, 3 }, { 4, 5, 6 } };

      // with jagged arrays,
      // we need to use "new int[]" for every row,
      // but every row does not need to be the same length.
      int[][] jagged = { new int[] { 1, 2 }, 
                         new int[] { 3 }, 
                         new int[] { 4, 5, 6 } };

      OutputArray( rectangular ); // displays array rectangular by row
      Console.WriteLine(); // output a blank line
      OutputArray( jagged ); // displays array jagged by row
   } // end Main

   // output rows and columns of a rectangular array
   public static void OutputArray( int[ , ] array )
   {
      Console.WriteLine( "Values in the rectangular array by row are" );

      // loop through array's rows
      for ( int row = 0; row < array.GetLength( 0 ); ++row )
      {
         // loop through columns of current row
         for ( int column = 0; column < array.GetLength( 1 ); ++column )
            Console.Write( "{0}  ", array[ row, column ] );

         Console.WriteLine(); // start new line of output
      } // end outer for 
   } // end method OutputArray

   // output rows and columns of a jagged array
   public static void OutputArray( int[][] array )
   {
      Console.WriteLine( "Values in the jagged array by row are" );

      // loop through each row
      foreach ( int[] row in array )
      {
         // loop through each element in current row
         foreach ( int element in row )
            Console.Write( "{0}  ", element );

         Console.WriteLine(); // start new line of output
      } // end outer foreach
   } // end method OutputArray
} // end class InitArray

 