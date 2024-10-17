using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{

    /// <summary>
    /// Event source (callback)
    /// </summary>
    public class StudentCardReport
    {
        public event EventHandler<Subject>? Passing;

        private List<Subject>? listOfSubjects;

        /// <summary>
        /// General purpose constructor
        /// </summary>
        /// <param name="listOfSubjects"></param>
        public StudentCardReport(List<Subject>? listOfSubjects)
        {
            ListOfSubjects = listOfSubjects;
        }


        public List<Subject>? ListOfSubjects
        {
            get
            {
                var subjects = new List<Subject>();
                foreach (var subject in listOfSubjects!)
                {
                    subjects.Add(new Subject(subject)); // deep copy !
                }

                return subjects;
            }
            set
            {
                if (value != null)
                {
                    listOfSubjects = new List<Subject>();
                    foreach (var subject in value!)
                    {
                        listOfSubjects.Add(new Subject(subject)); // deep copy!!
                    }

                }
                else
                {
                    listOfSubjects = new List<Subject>();
                }
            }
        }

        public void ProcessReport()
        {
            Console.WriteLine("Processin subjects ....\n");
            foreach (var item in listOfSubjects!)
            {
                Console.WriteLine($"Subject {item.Title}");
                var grades = item.Grades;
                foreach (var grade in grades)
                {
                    if (grade > 75)
                    {
                        Passing?.Invoke(this, item);/// Attention, test for subscribers!
                    }
                    else
                    {
                        Console.WriteLine("Not passing - F grade.");
                    }
                }
            }
        }

    }
}
