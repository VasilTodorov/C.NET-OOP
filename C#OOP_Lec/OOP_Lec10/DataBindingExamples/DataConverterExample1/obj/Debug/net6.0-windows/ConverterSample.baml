   M S B A M L   `   `   `  ����P  LDataConverterExample1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DataConverterExample1DataConverterExample1  5      +    %DataConverterExample1.ConverterSample   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5local#clr-namespace:DataConverterExample1     5        � Title$  Converter Example 1��5   	   $	��140��6%   $	��300��62    � 	Resources 5      3   -DataConverterExample1.YesNoToBooleanConverter   YesNoToBooleanConverter��%   &	          5   
   6(   5      .��5	      �� $��10q�6   .+�5
   
   �� -   5        $��txtValue��5
      � 5   
   $
��0,10q�6   .+�5      �� $��Current value is: ��6   �� 5      ��6   ��  �� ElementName$ txtValue�� �� Path$
 Text� �� 	Converter# [  5      5      �� 5   
   $	��Yes��5   H    d� 	IsChecked 5      �� $ txtValue��$
 Text�# [  5   H   5      5      