using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class StudentGradeReport
    {

        public event EventHandler? Passing;
        #region Constructors 
        public StudentGradeReport(List<Subject> subjects)
        {
            ListOfSubjects = subjects;
        }
        public StudentGradeReport() : this(new List<Subject>()) { }

        #endregion

        #region Properties  

        private List<Subject> listOfSubjects;
        public List<Subject> ListOfSubjects
        {
            get
            {
                var subjects = new List<Subject>();
                foreach (var subject in listOfSubjects)
                {

                    subjects.Add(new Subject(subject)); //deep copy required
                }
                return subjects;

            }
            set
            {
                if (value != null)
                {
                    listOfSubjects = new List<Subject>();
                    foreach (var subject in value)
                    {
                        Console.WriteLine(subject);
                        listOfSubjects.Add(new Subject(subject));
                    }
                   
                }
                else
                {
                    listOfSubjects = new List<Subject>();
                }


            }
        }
        #endregion

        public void ProcessReport()
        {
            foreach (var subject in listOfSubjects)
            {

                foreach (var item in subject.Grades)
                {
                    Console.WriteLine( item);
                    if (item > 75) // Passing{
                    {
                        Passing?.Invoke(this, subject);

                    }
                    else
                    {
                        Console.WriteLine($"Not passing {subject}");
                    }
                }
            }
        }
    }
 
}

