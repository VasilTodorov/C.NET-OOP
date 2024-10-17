// Fig. 7.13: MethodOverload.cs
// Overloaded method declarations.
using System;

public class MethodOverload
{
   // test overloaded square methods
   public void TestOverloadedMethods()
   {
      Console.WriteLine( "Square of integer 7 is {0}", Square( 7 ) );
      Console.WriteLine( "Square of double 7.5 is {0}", Square( 7.5 ) );
   } // end method TestOverloadedMethods

   // square method with int argument
   public int Square( int intValue )
   {
      Console.WriteLine( "Called square with int argument: {0}",
         intValue );
      return intValue * intValue;
   } // end method Square with int argument

   // square method with double argument
   public double Square( double doubleValue )
   {
      Console.WriteLine( "Called square with double argument: {0}",
         doubleValue );
      return doubleValue * doubleValue;
   } // end method Square with double argument
} // end class MethodOverload

 