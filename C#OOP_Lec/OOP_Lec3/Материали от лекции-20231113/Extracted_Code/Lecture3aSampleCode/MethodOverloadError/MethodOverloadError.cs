// Fig. 7.11: MethodOverload.cs
// Overloaded methods with identical signatures 
// cause compilation errors, even if return types are different.
public class MethodOverloadError
{
   // declaration of method Square with int argument
   public static int Square( int x )
   {
      return x * x;
   } // end method Square

   // second declaration of method Square with int argument 
   // causes compilation error even though return types are different
   public static double Square( int y )
   {
      return y * y;
   } // end method Square
} // end class MethodOverloadError
 