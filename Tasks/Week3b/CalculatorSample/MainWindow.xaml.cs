using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml(Calcolator)
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Datemembers

        private double firstNumber;
        private double secondNumber;
        private double memory;
        private double temp;
        private double result;
        private enum Operation
        {
            NO_OPERATION, ADDITION,
            SUBSTRACTION, DIVISION, MULTIPLYCTION
        }
        private Operation operation;

        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            memory = 0;
            result = 0;
        } 
        #endregion

        #region Methods
        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Event handler for digit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            var digit = ((Button)sender).Content.ToString();

            if (result == 0) TxtInput.Text = "0";
            if (TxtInput.Text == "0")
            {
                TxtInput.Text = digit;
            }
            else
            {
                if (digit == "." && TxtInput.Text.Contains(".")) { return; }
                TxtInput.Text = $"{TxtInput.Text}{digit}";
            }

            if (TxtInput.Text == "00")
                TxtInput.Text = "0";

            if (!double.TryParse(TxtInput.Text, out result))
            {
                MessageBox.Show("Wring input. Try again.");
                TxtInput.Text = "0";
                result = 0;
                return;
            }
        }
        /// <summary>
        /// Event handler for arithmetic operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            //read first opernt
            if (!double.TryParse(TxtInput.Text, out firstNumber))
            {
                MessageBox.Show("Wring input. Try again.");
                TxtInput.Text = "0";
                result = 0;
                return;
            }

            string operationSign = ((Button)sender).Content.ToString()!;

            operation = operationSign switch
            {
                "+" => Operation.ADDITION,
                "-" => Operation.SUBSTRACTION,
                "x" => Operation.MULTIPLYCTION,
                "/" => Operation.DIVISION,
                _ => Operation.NO_OPERATION
            };

            result = 0;
        }
        /// <summary>
        /// Event handler for computation of arithmetic operations "="
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            // read second operand
            if (!double.TryParse(TxtInput.Text, out secondNumber))
            {
                MessageBox.Show("Wring input. Try again.");
                TxtInput.Text = "0";
                result = 0;
                return;
            }
            // Compute selected operation
            result = operation switch
            {
                Operation.ADDITION => firstNumber + secondNumber,
                Operation.SUBSTRACTION => firstNumber - secondNumber,
                Operation.MULTIPLYCTION => firstNumber * secondNumber,
                Operation.DIVISION => firstNumber / secondNumber,
                _ => 0
            };
            // display result
            operation = Operation.NO_OPERATION;
            TxtInput.Text = "" + result;
            result = 0;
        }
        /// <summary>
        /// Event handler for memory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Memory_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TxtInput.Text, out temp))
            {
                MessageBox.Show("Wring input. Try again.");
                TxtInput.Text = "0";
                result = 0;
                return;
            }

            string memorySign = ((Button)sender).Content.ToString()!;

            memory = memorySign switch
            {
                "M" => temp,                      //memory store
                "M+" => memory + temp,            //add to memory
                "M-" => memory - temp,            //substract from memory
                "MC" => 0,                              //memory clear
                _ => memory
            };

            if (memorySign == "MR")                     //memory recall
                TxtInput.Text = memory.ToString();

            result = 0;
        }
        /// <summary>
        /// Event handler for clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            operation = Operation.NO_OPERATION;                         //C => Clear
            TxtInput.Text = "0";                                        //C/A => Clear All
            result = 0;
            string cleatSign = ((Button)sender).Content.ToString()!;
            if (cleatSign == "C/A")
                memory = 0;

        }
        /// <summary>
        /// Event handler for math operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Math_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TxtInput.Text, out temp))
            {
                MessageBox.Show("Wring input. Try again.");
                TxtInput.Text = "0";
                result = 0;
                return;
            }

            string mathSign = ((Button)sender).Content.ToString()!;

            result = mathSign switch
            {
                "EXP" => Math.Exp(temp),
                "SIN" => Math.Sin(temp),
                "COS" => Math.Cos(temp),
                "SQRT" => Math.Sqrt(temp),
                "LOG" => Math.Log(temp),
                "1/x" => 1 / temp,
                _ => 0
            };

            TxtInput.Text = "" + result;

            result = 0;
        } 
        #endregion
    }
}
