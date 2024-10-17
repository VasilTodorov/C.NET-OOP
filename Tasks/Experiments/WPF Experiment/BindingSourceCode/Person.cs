using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BindingSourceCode
{
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string? name;
        private int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name
        {
            get { return name!; }
            set 
            { 
                if(this.name != value)
                {
                    this.name = value;
                    NotifyPropertyChanged(nameof(Name));
                } 
            }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public void NotifyPropertyChanged(string propName)
        { // raise the PropertyChanged event
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propName));

            //if(PropertyChanged != null)
            //{
            //    var n = PropertyChanged.GetInvocationList();

            //    MessageBox.Show("WOW=" + n[0].Method.Name);
            //}
        }


    }
}
