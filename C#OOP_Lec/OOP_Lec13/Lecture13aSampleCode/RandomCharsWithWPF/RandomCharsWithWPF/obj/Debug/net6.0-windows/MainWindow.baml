   M S B A M L   `   `   `  ����M  IRandomCharsWithWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfGUIThreadsWpfGUIThreads  5   	       WpfGUIThreads.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfGUIThreads     5   	   -   5          � Title$  WPF GUI Threads��5   	   $��200.647��6!   $��609.529��62   $��14(�6B   .��5	      � $	��160��6   $	��Top=�6   $��4,4,4,-3q�60    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��11* �6   �� 5      $	��13* �6   .+�5   
   �� -   5         ��Name$ thread1Label��5      $��Thread 1��6&   $��Center=�69   $��10q�6V   $	��246��6b   $��Arial)�6n   $��20(�6�   
������6�   �� 5   
   -   5         ��Name$ thread1CheckBox��5      $��	Suspended��6,   $��1��6@   $
��Left=�6P   $��	36,10,0,0q�6k   $	��Top=�6~   $��33��6�   $	��257��6�   $��20(�6�   $��Arial)�6�   $
��Bold"�6�   6  �� 5   
   -   5        $ thread2Label��5      $��Thread 2��6'   $��Center=�6:   $��10q�6W   $	��246��6c   $��Arial)�6o   $��20(�6�   $��1��6�   
������6�   �� 5   
   -   5        $ thread2CheckBox��5      $��	Suspended��6,   $��1��6@   $
��Left=�6P   $��	36,10,0,0q�6k   $	��Top=�6~   $��34��6�   $	��257��6�   $��20(�6�   $��Arial)�6�   $
��Bold"�6�   $��1��6�   6  �� 5   
   -   5        $ thread3Label��5      $��Thread 3��6'   $��Center=�6:   $��10q�6W   $	��246��6c   $��Arial)�6o   $��20(�6�   $��2��6�   
������6�   �� 5   
   -   5        $ thread3CheckBox��5      $��	Suspended��6,   $��1��6@   $
��Left=�6P   $��	36,10,0,0q�6k   $	��Top=�6~   $��33��6�   $	��257��6�   $��20(�6�   $��Arial)�6�   $
��Bold"�6�   $��2��6�   6  5      5      