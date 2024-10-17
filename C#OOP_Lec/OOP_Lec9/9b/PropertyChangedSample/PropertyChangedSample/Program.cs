using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.PropertyChanged += OnPropertyChanged;// initialize event handler
            person.PersonName = "Ivan";
        }
        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {   //e.PropertyName the property identifier
            Person person = (Person)sender;// holds the current value of the property
            Console.WriteLine("Property [{0}] has a new value = [{1}]",
            e.PropertyName, person.PersonName);
        }
    }
    //
}
