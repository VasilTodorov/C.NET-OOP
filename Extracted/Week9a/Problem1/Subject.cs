using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Subject : EventArgs
    {
        public const int MAX_GRADES = 150;
        private int[]? grades;
        public string Title { get; set; }


        #region Constructors
        public Subject(int[] grades, string title)
        {
            Grades = grades;
            Title = title;
        }
        public Subject() : this(new int[0], "Unknown title")
        {

        }
        public Subject(Subject s) : this(s.grades!, s.Title) { }


        #endregion

        #region Properties 
        public int[] Grades
        {
            get
            {
                var copy = new int[grades.Length];
                for (int i = 0; i < copy.Length; i++)
                    copy[i] = grades[i];
                return copy;
            }

            set
            {
                if (value != null)
                {
                    var grades = new int[value.Length];
                    for (int i = 0; i < grades.Length; i++)
                    {
                        grades[i] = value[i];
                    }
                    
                }
                else
                {
                    grades = new int[0];
                }

            }
        }
        #endregion

        public override string ToString()
        => $"Title = {Title}\nGrades= [{string.Join(", ", grades!)}]";
    }

}
