   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   R NArduinoMonitoringWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ArduinoMonitoringWPFAppArduinoMonitoringWPFApp 5
   	   Q-clr-namespace:ArduinoMonitoringWPFApp.HelpersArduinoMonitoringWPFApp.Helpers 5   	   ,   &ArduinoMonitoringWPFApp.Views.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   h dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^	 ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af
 bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  	 
                    5   	   hlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  	 
                    5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullZ VMaterialDesignThemes.MahApps, Version=0.1.4.1513, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	   3local%clr-namespace:ArduinoMonitoringWPFApp   5
   	   :help-clr-namespace:ArduinoMonitoringWPFApp.Helpers   5   	     � Title$  Arduino Monitoring��5   	   $	��800��6$   $	��600��61   (  "MahApps.Metro.Controls.MetroWindow   IconTemplate 5      �� 5   
   .R�5      1  +MahApps.Metro.IconPacks.PackIconSimpleIcons     Kind$ Arduino=�6,   $��Center=�6;   $��Center=�6X   
�������5   ,   5      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��0.8* �6   �� 5      $��1* �6   �� 5      $
��2.5* �6   �� 5      $��3* �6   �� 5      $��6* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $
��0.5* �6   �� 5#      $��2* �6   .+�5&   
   � $��0��6   $��4��6   $��3q�60   .+�5'      o� .@�5(      m� $��파일��6    m� Icon 5)      .  (MahApps.Metro.IconPacks.PackIconBoxIcons  5*         Kind$ SolidFileBlank=�65   .@�5,      m� $��열기��6    5-        5.      $ RegularDoorOpen=�69   50      m� 51      $��저장��6    52        53      $ RegularSave=�69   55      �� 56      m� 57      -   5         m�Name$ ProgramExit��57      $��	끝내기��64    58        59      $ 	SolidExit=�69   5;      5<      m� 5=      $��시뮬레이션��6    5>        5?      $ RegularLineChart=�65   .@�5A      m� -   5        $ SimStart��5A      $��시작��61    5B      1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5C         Kind$ PlayCircleSolid=�6<   5E      m� 5F      -   5        $ SimStop��5F      $��중지��60    5G        5H      $ BanSolid=�6<   5J      5K      m� 5L      $��	도움말��6    5M      .  (MahApps.Metro.IconPacks.PackIconMaterial  5N      	   Kind$	 AccountQuestionOutline=�65   .@�5P      m� -   5        $
 Info��5P      $��정보��6-    5Q      ,  &MahApps.Metro.IconPacks.PackIconModern  5R      
   Kind$
 InformationCircle=�67   5T      5U      5V      5W      �� 5X   
   -   5         ��Name$ ConnTime��5X      $��5q�6'   $��1��5Y      $��0��6!   $��2��61   $��15(�5Z      $
��Left=�6"   $��Center=�5[      �� 5]   
   -   5         ��Name$ SensorCount��5]      $��1��6'   $��2��64   $��2q�5^      $��25��6   $��50��6)   $��Center=�5_       �� 
IsReadOnly . 6/   �� 5a   
   $��2��6   $��3��6    $��5q�64   ��5b      �� 5c      $��포토 레지스터��6   
�������$��15(�6>   .��5e      �� .+�5f      � -   5         �Name$ PgbPhotoRegistor��5f      $��30��68   $��5q�6D    � Maximum$
 1024Q�6O   �� 5g      -   5        $ LblPhotoRegistor��5g      $��Center=�65   5h      5i      �� 5k   
   -	   5        $ RtbLog��5k      $��3��6"   $��3��6/   $��5q�6C   
������� . 6  0ArduinoMonitoringWPFApp.Helpers.TextBoxBehaviors   AutoScrollToEnd . 5m   $   �� 5o   
   $��1��6   $��4��6    $��3��60   $��5q�5p         MaterialDesignGroupBox#��[  6   ��5q      �� 5r      $��포트��6   
�������$��15(�69   .��5t      � $��5q�6    5u      �� 5v      �� 5w      �� 5x      �� 5y      $��2* �6$   .+�5{      �� -
   5         ��Name$ CboSerialPort��5{      $��0��62   $��5q�6?    �� SelectedItem 5|      �� *SelectedPort+{�6A   �� *	CboEnable+�� 5      -   5         ��Name$ 
BtnConnect��5      $��1��6-   $��5q�6:   $��CONNECT��6E   $��20(�5�      
�������6(   �� 5�      -   5        $ BtnDisconnect��5�      $��2��60   $��5q�6=   $��
DISCONNECT��6H   $��20(�5�      
�������6(   �� 5�      -   5        $ BtnPortValue��5�      $��3��6/   $��5q�6<   $��30(�5�      $��90��6'   
�������63   5�      5�      #   LiveCharts.Wpf.CartesianChart  5�   
   $��4��6   $��4��6*   &	    LiveCharts.Wpf.Charts.Base.Chart 	  AxisX 5�      
   LiveCharts.Wpf.Axis
   
  Title$ 	Time(sec)��6    
  MaxValue 6-   �� *
AxisXMax+ 
  MinValue 6K   �� *
AxisXMin+ 	  AxisY 5�      
  $ Photo Value��6   $ 0Q�6/   $
 1023Q�6<    	  Series 5�         LiveCharts.Wpf.LineSeries     LiveCharts.Wpf.Series   Fill
 �����   Stroke
 ����   StrokeThickness$ 3Q�5�   !      Title$ Photo Value��65      Values 5�   !   �� *
LineValues+5�   5   5�      � 5�   
   $��5��6   $��4��6   $��5q�60    5�      �� 5�      �� 5�      .+�5�      �� -   5        $ AllValue��5�      $��0��6'   $��10q�67   $��60��6C   $��	ALL VALUE��5�      
�������$��20(�6<   �� 5�      -   5        $
 Zoom��5�      $��1��6#   $��10q�63   $��60��6?   $
��ZOOM��5�      
�������$��20(�67   5�      5�      5�      