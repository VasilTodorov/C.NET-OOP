﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyHanndling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && ((TextBox)e.Source).IsKeyboardFocused)
            {
                MessageBox.Show(((TextBox)e.Source).Text);
                
            }

        }

        private void TextBlock_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && ((TextBox)e.Source).IsKeyboardFocused)
            {
                MessageBox.Show(((TextBox)e.Source).Text);
            }
        }
    }
}