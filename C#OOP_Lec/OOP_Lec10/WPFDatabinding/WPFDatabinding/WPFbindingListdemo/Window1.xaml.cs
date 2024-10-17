using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPFDatabinding
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        List<Person> people = new List<Person>();

        public Window1()
        {
            InitializeComponent();

            Binding b = new Binding
            {
                //b.ElementName = "TextBox1";
                ElementName = "TextBox1",
                Path = new PropertyPath("Text")
            };

            TextBox3.SetBinding(TextBox.TextProperty, b);

            people.Add(new Person("Bill Steele", 39, "b_steele_2.jpg"));
            people.Add(new Person("Amanda Steele", 16, "amanda.jpg"));
            people.Add(new Person("Ron Cundiff", 40, "r_cundiff_2.jpg"));

            this.MyStackPanel.DataContext = people;
            
        }

        // classic way of doing binding - in code!
        void TextBox1_Changed(object o, EventArgs e)
        {
            try
            {
                if (this.TextBox1.Text.Length > 0)
                    this.TextBox2.Text = this.TextBox1.Text;
            }
            catch { }
        }
    }

    public class Person
    {
        public Person(string Name, int Age, string Image)
        {
            name = Name;
            age = Age;
            image = Image;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
	
    }

    public class MyValidationRule : ValidationRule
    {
        private string validName;

        public string ValidName
        {
            get { return validName; }
            set { validName = value; }
        }	

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string enteredName = value.ToString();

            if (enteredName == ValidName)
            {
                return new ValidationResult(false, "Hey, That's Me!");
            }
            else
            {
                return new ValidationResult(true, null);
            }           
        }
    }
        
}