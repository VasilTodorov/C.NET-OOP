   M S B A M L   `   `   `  ����C  ?Patterns, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Patterns.UtilitiesPatterns.Utilities  5   	   +clr-namespace:Patterns.AMBPatterns.AMB  5   	       Patterns.AsyncModel   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:Patterns.Utilities     5   	   *ambclr-namespace:Patterns.AMB     5   	     � Title$!  Sample: Async Model Binding��5   	   $	��300��6-   $	��300��6:    � DataContext 5      !   Patterns.AMB.AsyncViewModel  5	   
    � 	Resources 5      *   $Patterns.Utilities.CoalesceConverter   CoalesceConverter*   $Patterns.Utilities.HasValueConverter  HasValueConverter��%:   &	        &	        5   
   6"     5   
   6"   5      .��5      � $��Stretch=�6   $��Stretch=�5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      �� 5      .+�5    
   �� $��1��6   $��3��5!      ��5"      �� *Movies+��5#      �� 5$      .R�5%      ��  �� Orientation$ 
Horizontal=�6!   .+�5&      �� $��64��5'       $��64��5(       $��5q�5)       ��5&       �� *BoxArtSmallUrl+5)       �� 5*      $��5q�6%   $ Vertical=�5+   %   .+�5,      �� $��20(�5-   (   ��5,   (   �� *Title+5-   (   �� 5.      ��6(   �� *Url+5/      50      51      53      �� 55   
   $��5q�6   $��0��56      $��0��57      $��Center=�58      ��59      �� *Query+ �� Mode$ TwoWay=��� 5;   
   $��Fetch��6   $��5q�5<      $��0��5=      $��1��5>      ��5?      �� *Fetch+�� 5A   
   $��Cancel��6   $��5q�5B      $��0��5C      $��2��5D      ��5E      �� *Cancel+� 5G   
   $��5q�6   $��2��5H      $��2��5I       � Maximum$ 1Q�5K   �    � IsIndeterminate 5J      �� *
Progress+$ OneWay=�	 �� 	Converter#	 [ 
 �� ConverterParameter$
 False�� � Value 5K      �� *
Progress+$ OneWay=�#	 [  $
 0��6�   �� 5M   
   $��5q�6   $��2��5N      $��0��5O      $��2��5P      $��Center=�5R      $��Right=�5S      ��5Q      �� *ProgressText+5S      5T      5U      