﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBindingExample7
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        private int age;
        public event PropertyChangedEventHandler PropertyChanged;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged(nameof(Name));
                }
            }
        }
        public void NotifyPropertyChanged(string propName)
        {   // raise the PropertyChanged event
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    this.NotifyPropertyChanged(nameof(Age));
                }
            }

        }
    }
