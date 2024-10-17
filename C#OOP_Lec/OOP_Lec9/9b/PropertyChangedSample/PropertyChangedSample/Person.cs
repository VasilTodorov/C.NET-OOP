using System.ComponentModel;

namespace CustomEvent
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        public Person()
        {
        }
        public Person(string value)
        {
            this.name = value;
        }
        public string PersonName
        {
            get { return name; }
            set
            {
                name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("PersonName");// signal change of property "PersonName"
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (name.Equals(nameof(PersonName))) // check for property name
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
