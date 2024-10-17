using System.Windows;
using System.Threading;
namespace WpfGUIThreads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RandomLetters letter1; // first RandomLetters object
        private RandomLetters letter2; // second RandomLetters object
        private RandomLetters letter3; // third RandomLetters object
        public MainWindow()
        {
            InitializeComponent();
        }
   
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }// end method GUIThreadsForm_FormClosing
         // suspend or resume the corresponding thread
        private void threadCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == thread1CheckBox)
                letter1.Toggle();
            else if (sender == thread2CheckBox)
                letter2.Toggle();
            else if (sender == thread3CheckBox)
                letter3.Toggle();
        }// end method threadCheckBox_CheckedChanged

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // create first thread
            letter1 = new RandomLetters(thread1Label);
            Thread firstThread = new Thread(letter1.GenerateRandomCharacters);
            firstThread.Name = "Thread 1";
            firstThread.Start();

            // create second thread
            letter2 = new RandomLetters(thread2Label);
            Thread secondThread = new Thread(letter2.GenerateRandomCharacters);
            secondThread.Name = "Thread 2";
            secondThread.Start();

            // create third thread
            letter3 = new RandomLetters(thread3Label);
            Thread thirdThread = new Thread(letter3.GenerateRandomCharacters);
            thirdThread.Name = "Thread 3";
            thirdThread.Start();
        }
    }
}
