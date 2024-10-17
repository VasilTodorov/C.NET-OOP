using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataBindingExample3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding
            { // Initialze the same attributes as in XAML
                ElementName = "TxtBox1",
                Path = new PropertyPath("Text")

            };
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TxtBox3.SetBinding(TextBox.TextProperty, b);

            people.Add(new Person("Ivan Ivanov", 39));
            people.Add(new Person("Petar Petrov", 21));
            people.Add(new Person("John Atanasoff", 80));
            StcPanel.DataContext = people; 
        }
    }
}
