// Exercise 7.6: Sphere.cs
// Calculate the volume of a sphere.
using System;

public class Sphere
{
   // obtain radius from user and display volume of sphere
   public static void Main( string[] args )
   {
      Console.Write( "Enter radius of sphere: " );
      double radius = Convert.ToDouble( Console.ReadLine() );

      Console.WriteLine( "Volume is {0:F3}", SphereVolume( radius ) );
   } // end Main

   // calculate and return sphere volume
   public static double SphereVolume( double radius )
   {
      double volume = ( 4.0 / 3.0 ) * Math.PI * Math.Pow( radius, 3 );
      return volume;
   } // end method SphereVolume
} // end class Sphere
 