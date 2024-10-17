using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6   // Problem 6 solution
{/// <summary>
/// Look at line #1: how does the compiler know that textBox1 is not actually 
/// a RichTextBox or other classes derived from TextBox? 
/// If it is, you certainly must not be able to access TypeText! 
/// So, the compiler is unable to statically prove that
/// the access is always legal and because of that it has to disallow this code.
/// Even, if the compiler does have enough information to prove that the access is legal 
/// but it still will not allow the code to compile
/// </summary>
    public class TestPolymorphismProtected  
    {
        public static void Main(string[] args)
        {
            // Execute version of TypeText() from the base class
            TextBox[] textBoxes = { new EditTextBox(), new RichTextBox(), new MultiLineTextBox() };
            // or
            TextBox textBox1 = (TextBox)(new RichTextBox());
            // Compiler error, TestPolymorphismProtected ISNOT TextBox            

            //foreach (var tb in textBoxes)
            //{
            //    tb.TypeText();//not from derived class - protected
            //}
            //textBox1.text = "Disallowed"; // Error
            //Note: A protected member is accessible within its class and by derived class instances”. 

        }
    }
    public abstract class TextBox
    {
        protected string text ;
        protected string baseText ;
        public TextBox()
        {
            text = $"{(GetType())}: Type text";
            baseText = $"{(GetType())}: Type base text";
        }
        protected virtual void TypeText() { Console.WriteLine(text); }
        public abstract void EditTextAllowed();

        public abstract void EditTextDisAllowed();

    }

    public class RichTextBox : TextBox
    {
        protected new string text; // hide inherited variable
        public RichTextBox()
        {
            text = $"{(GetType())}: Type text";
        }
        //protected override void TypeText() { Console.WriteLine(text); }
        public override void EditTextAllowed()
        {
            base.TypeText();//OK because it is still called from RichTextBox
            Console.WriteLine(base.text);//OK
        }
        public override void EditTextDisAllowed()
        {
            
            // Execute version of TypeText() from the base class
            TextBox textBox1 = new RichTextBox();
            // or
            TextBox textBox2 = (TextBox)(new RichTextBox());
            // or
            TextBox textBox3 = (TextBox)this;


            // the compiler does have enough information to prove that the access is legal 
            // but it still will not allow the code to compile
            //textBox1.TypeText(); // Compiler error

            //!!!protected member within derived class can only be accessed from the derived class type .TextBox isnt RichTextBox.!!!
            //TypeText() is being accessed from TextBox is not type RichTextBox

            //textBox2.TypeText(); // Compiler error
            //textBox3.TypeText(); // Compiler error

            //textBox1.text = "Not allowed to change this"; // Compiler error
            //textBox2.text = "Not allowed to change this"; // Compiler error
            //textBox3.text = "Not allowed to change this"; // Compiler error
        }
    }

    public class MultiLineTextBox : RichTextBox
    {
        protected new string text; // hide inherited variable
        //protected override void TypeText() { Console.WriteLine(text); }
        public MultiLineTextBox()
        {
            text = $"{(GetType())}: Type text";
        }
        public override void EditTextAllowed()
        {
            base.TypeText();//OK
            Console.WriteLine(base.text);//OK
            Console.WriteLine(base.baseText);//OK
        }
        public override void EditTextDisAllowed()
        {
            // Execute version of TypeText() from the base class
            TextBox textBox1 = new MultiLineTextBox();
            // or
            TextBox textBox2 = (TextBox)(new MultiLineTextBox());
            // or
            TextBox textBox3 = (TextBox)this;


            // the compiler does have enough information to prove that the access is legal 
            // but it still will not allow the code to compile
            //textBox1.TypeText(); // Compiler error
            //textBox2.TypeText(); // Compiler error
            //textBox3.TypeText(); // Compiler error

            //textBox1.text = "Not allowed to change this"; // Compiler error
            //textBox2.text = "Not allowed to change this"; // Compiler error
            //textBox3.text = "Not allowed to change this"; // Compiler error
        }
    }
    public class EditTextBox : TextBox
    {
        protected new string text ; // hide inherited variable
        protected override void TypeText() { Console.WriteLine(text); }
        public EditTextBox()
        {
            text = $"{(GetType())}: Type text";
        }
        public override void EditTextAllowed()
        {   // Execute version of TypeText() from the base class
            base.TypeText();//OK
            Console.WriteLine(base.text);//OK
        }
        public override void EditTextDisAllowed()
        {
            // Execute version of TypeText() from the base class
            TextBox textBox1 = new EditTextBox();
            // or
            TextBox textBox2 = (TextBox)(new EditTextBox());
            // or
            TextBox textBox3 = (TextBox)this;


            // the compiler does have enough information to prove that the access is legal 
            // but it still will not allow the code to compile
            //textBox1.TypeText(); // Compiler error
            //textBox2.TypeText(); // Compiler error
            //textBox3.TypeText(); // Compiler error
            //textBox3.baseText = ""; // Compiler error
            //textBox1.text = "Not allowed to change this"; // Compiler error
            //textBox2.text = "Not allowed to change this"; // Compiler error
            //textBox3.text = "Not allowed to change this"; // Compiler error
        }
    }
}
