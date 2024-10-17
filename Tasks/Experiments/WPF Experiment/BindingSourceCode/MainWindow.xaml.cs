using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BindingSourceCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> people = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding
            { // Initialze the same attributes as in XAML
                ElementName = "TxtBox1",
                Path = new PropertyPath("Text")
            };// TextBox.TextProperty is a Dependency property
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TxtBox3.SetBinding(TextBox.TextProperty, b);

            people.Add(new Person("Ivan Ivanov", 39));
            people.Add(new Person("Petar Petrov", 21));
            people.Add(new Person("John Atanasoff", 80));
            // associate the List<Person> with the StackPanel
            StcPanel.DataContext = people; // Databinding setup
            people.Add(new Person("Petya Petrova", 32));// Binding source changes

        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            people.Add(new Person("Petya Assenova", 62));
        }

        private void BtnChangePerson_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox?.SelectedItem != null)
                (MyListBox.SelectedItem as Person)!.Name = "Random Name";

        }
    }
}