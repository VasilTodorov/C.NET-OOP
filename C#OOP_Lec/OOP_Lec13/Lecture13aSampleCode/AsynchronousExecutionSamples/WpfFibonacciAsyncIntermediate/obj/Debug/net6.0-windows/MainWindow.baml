   M S B A M L   `   `   `  ����X  TWpfFibonacciAsyncIntermediate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WpfFibonacciAsyncIntermediateWpfFibonacciAsyncIntermediate  5   	   .    (WpfFibonacciAsyncIntermediate.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:WpfFibonacciAsyncIntermediate     5   	     � Title$  Responsive GUI��5   	   $	��455��6    $	��478��6-   .��5	      � $��2,2,2,6q�6    � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $	��57* �6   �� 5      $	��44* �6   �� 5      $
��275* �6   �� 5      $	��40* �6   .+�5   
   �� $%��Compute Fibonacci numbers up to��6   $
��Left=�6:   $��
10,10,0,13q�6U   $��Center=�6i   $	��213��6�   $��34��6�   $
��Bold"�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ startButton��5      $(��"Start Asynchronous Fibonacci Calls��6&   $��10,10,192,0q�6S   $��1��6h   $	��Top=�6u   $
��Bold"�6�   $��20��6�    �� 	IsDefault$
 True��6�   �� 5   
   -   5         ��Name$ outputTextBox��5      $��10q�6)   $��2��65    �� TextWrapping$
 Wrap=�6B    �� 
IsReadOnly$
 True��6V   " �� VerticalScrollBarVisibility$ Visible=�6h   $
��True��6�   �� 5   
   -   5        $ 
ExitButton��5      $
��Quit��6%   $��340,10,10,0q�64   $��1��6I   $	��Top=�6V   $
��Bold"�6�   $��20��6�   	 �� IsCancel$
	 True��6�   �� 5   
   -   5        $ txtInput��5      $��0,10,192,12q�6$   $
 Wrap=�69   $��2��6M   
 J� RenderTransformOrigin$
 -0.297,0.592&�6V    �� TextAlignment$ Center=�6{   $
��Bold"�6�   $��5q�6�   $��Right=�6�   $��46��6�   � 5   
   -   5         �Name$ pbStatus��5      $��
10,12,10,8q�6(   $��3��6<    � Minimum$ 0Q�6I    � Maximum$	 100Q�6U   $
 0.502,-0.056&�5      �� 5   
   -   5         ��Name$ pbStatusTextBlock��5      $��3��5      $��207,14,205,10q�6!   $
 0.759,-0.375&�68   $
��Bold"�6]    �� TextAlignment$ Center=�5      ��5   /   ��  �� ElementName$ pbStatus�� �� Path$ Value� �� StringFormat$ {0:0}%��5      5      5      