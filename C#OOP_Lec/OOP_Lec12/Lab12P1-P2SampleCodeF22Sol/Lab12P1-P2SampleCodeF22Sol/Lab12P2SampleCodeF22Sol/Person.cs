using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12SampleCode
{
    public class SalaryEmployee:Person{
 

        private double salary;
        public SalaryEmployee(string name, double salary):base(name)
        {
            Salary = salary;
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Person:  IComparable<Person>
    {
        //Option 1
        private class NewPersonComparerhelpeer : IComparer<Person>
        {

            int IComparer<Person>.Compare(Person? x, Person? y)
            {
                return (x!.Name.CompareTo(y!.Name));
            }
        }
        // Method to return IComparer object for sort helper.
        public static IComparer<Person> SortNameAscending()
        {
            return (IComparer<Person>)new NewPersonComparerhelpeer();
        }
        private readonly string name;
        private readonly DateTime? dateOfBirth;

        public Person(string name)
        {
            this.name = name;
            this.dateOfBirth = null;
        }

        public Person(string name, DateTime? dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
        }


        public override string ToString()
        {
            return "Person: " + name + " " + dateOfBirth;
        }
        //Option 2
        int IComparable<Person>.CompareTo(Person? other)
        {
            return ( Name.CompareTo(other!.Name));
        }
    }
}
