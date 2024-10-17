// Fig. 8.16: GradeBookTest.cs
// Create GradeBookMultiDimensional object using an array of grades.
public class GradeBookTest
{
   // Main method begins application execution
   public static void Main( string[] args )
   {
      // one-dimensional array of student grades
      int[] gradesArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };

      GradeBookMultiDimensional myGradeBook = new GradeBookMultiDimensional(
         "CS101 Introduction to C# Programming", gradesArray );
      myGradeBook.DisplayMessage();
      myGradeBook.ProcessGrades();
   } // end Main
} // end class GradeBookTest
 