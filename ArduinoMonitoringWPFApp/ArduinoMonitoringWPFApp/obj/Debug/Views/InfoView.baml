   M S B A M L   `   `   `  ����R  NArduinoMonitoringWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ArduinoMonitoringWPFApp.ViewsArduinoMonitoringWPFApp.Views  5      Q-clr-namespace:ArduinoMonitoringWPFApp.HelpersArduinoMonitoringWPFApp.Helpers  5      ,    &ArduinoMonitoringWPFApp.Views.InfoView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:ArduinoMonitoringWPFApp.Views     5      >help-clr-namespace:ArduinoMonitoringWPFApp.Helpers     5      $	��500��5	      $	��800��6   
�������.��5      �   � RowDefinitions  5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $
��1.5* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��6* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6   $��6��6-   $��20q�6>   $��/ViewInfo/images.png��5      $
��Fill=�6.   �� 5   
   $��0��6   $��1��6!   $��5q�61   ��5      �� 5       $��	제품명��6   
�������$��15(�6:   .��5"      �� -   5         ��Name$ ProductName��5"      5#      �� 5%   
   $��1��6   $��1��6!   $��5q�61   ��5&      �� 5'      $��버전��6   
�������$��15(�69   .��5)      �� -   5        $ Version��5)      5*      �� 5,   
   $��2��6   $��1��6!   $��5q�61   ��5-      �� 5.      $��버전��6   
�������$��15(�69   .��50      �� -   5        $ 	Copyright��50      51      �� 53   
   $��3��6   $��1��6!   $��5q�61   ��54      �� 55      $��	회사명��6   
�������$��15(�6:   .��57      �� -   5        $ CompanyName��57      58      �� 5:   
   $��4��6   $��2��6!   $��1��62   $��5q�6B   ��5;      �� 5<      $��설명��6   
�������$��15(�69   .��5>      �� -   5         ��Name$ Description��5>      6   0ArduinoMonitoringWPFApp.Helpers.TextBoxBehaviors   AutoScrollToEnd .  �� TextWrapping$
 Wrap=�5?   C    �� AcceptsReturn .  �� 
IsReadOnly . 5@   +   5B      �� 5E   
   $��5��6   $��2��6   $��10q�6.   $��	확인(O)��5F      $��10(�6!    �� IsCancel . 
�������6?   5G      5H      