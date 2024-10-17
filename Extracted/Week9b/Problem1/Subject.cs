using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{

    /// <summary>
    /// Event object
    /// </summary>
    public class Subject : EventArgs
    {
        public const int MAX_GRADE_VALUE = 150;
        private int[]? grades ;
        public string? Title { get; set; }

        #region Constructors

        /// <summary>
        /// General purpose constructor
        /// </summary>
        /// <param name="grades"></param>
        /// <param name="title"></param>
        public Subject(int[]? grades, string? title)
        {
            Title = title ?? string.Empty;
            Grades = grades!;

        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Subject() : this(new int[0], "Unknown title")
        {

        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s"></param>
        public Subject(Subject s) : this(s.grades, s.Title) { }


        #endregion

        #region Properties  
        public int[] Grades
        {
            get
            {
                var temp = new int[grades!.Length];
                for (int i = 0; i < grades.Length; i++)
                {
                    temp[i] = grades[i];
                }
                return temp;
            }
            set
            {
                if (value != null)
                {
                    grades = new int[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        grades[i] = Math.Min(value[i], MAX_GRADE_VALUE);
                    }
                }
                else
                    grades = new int[0];
            }
        }
        #endregion


        public override string ToString()
        {
            return $"Title = {Title}\nGrades =[{string.Join(", ", grades!)}]";
        }


    }
}
