﻿// Fig. 16.21: TextEditor.xaml.cs
// Code-behind class for a simple text editor.
using System.Windows;
using System.Windows.Input;

namespace TextEditor
{
   public partial class TextEditorWindow : Window
   {
      public TextEditorWindow()
      {
         InitializeComponent();
      } // end constructor

      // exit the application
      private void closeCommand_Executed( object sender, 
         ExecutedRoutedEventArgs e )
      {
         Application.Current.Shutdown();
      } // end method closeCommand_Executed
   } // end class TextEditorWindow
} // end namespace TextEditor

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/