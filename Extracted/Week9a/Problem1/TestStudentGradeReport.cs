using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class TestStudentGradeReport
    {

        static void OnPassing(object sender, EventArgs e)
        {
            var message = $"Congratulations.Passing subject{ e}";

            Console.WriteLine(  message);
        }

        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>()
            {
                new Subject() {Title="CSharp", Grades= new int[]{100,50,110 } },
                new Subject() {Title="Python", Grades= new int[]{80,50,110,30} }
             } ;
            Console.WriteLine(string.Join(", ", new int[] { 100, 50, 110 })
             );
            foreach (var item in subjects)
            {
                Console.WriteLine(item);
            }
            
            StudentGradeReport student = new StudentGradeReport(subjects) ;
            student.Passing += OnPassing;
            student.ProcessReport();
            
        }
    }
}
