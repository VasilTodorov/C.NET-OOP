   M S B A M L   `   `   `  ����M  IWPFbindingListdemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFDatabindingWPFDatabinding  5          WPFDatabinding.Window1   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      0myStuffclr-namespace:WPFDatabinding     5        � Title$  WPFDatabinding��5      $	��300��6   $	��300��6)    � 	Resources 5         oopsTemplate �� Orientation��%�   &	        �� 5	      .R�5
      �� $ 
Horizontal=�6   .+�5      �� 
���  ��$��20(�6!   *62   5      5      5      .��5      � .+�5      �� -   5         ��Name$ MyStackPanel��5      .+�5      �� -   5         ��Name$ TextBox1��5   ,   ��6>   �� *Name+�� 5      -   5        $ TextBox2��5      �� 5      -   5        $ TextBox3��5      �� 5      ��6   ��  �� ElementName$ TextBox1�� �� Path$
 Text��� 5      ��6   �� *Text+$ TextBox1���� 5      -   5         ��Name$ 	MyListBox��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�68   ��6    �� ��5      �� 5      .R�5      �� $	��200��6   $��50��6   $��2q�6'   
��� � �
����ح�	 �� CornerRadius$	 10��6f   ._�5   	   �� $��Center=�6   $ 
Horizontal=�62   .+�5   
   �� $��3q�6   $��45��65   ��6   �� *Image+65   �� 5    
   $��Center=�6   $ Vertical=�61   .+�5"      �� 
 =� ErrorTemplate#
 [  6   .��6M   ��5#      �� 5$      $
 Name�6    �� ValidationRules 5%      %   WPFDatabinding.MyValidationRule  5&         	ValidName$ Amanda M. Steele��6(   5(      .��5)      5*      �� 5,      ��6   �� *Age+5.      5/   
   50   	   51      53      54      55      56      