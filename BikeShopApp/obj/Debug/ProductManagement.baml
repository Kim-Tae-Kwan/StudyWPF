   M S B A M L   `   `   `  ����F  BBikeShopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BikeShopAppBikeShopApp  5      #    BikeShopApp.ProductManagement   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BikeShopApp     5        N� Title$  ProductManagement��5	         Page_Background N� 
Background# [  5
      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��0��6   $��2��6,    5      �� 5      $	��100 �6#   �� 5      .+�5      �� $��0��6   $��SEARCH��6(   $	��100��66   $��Center=�6B    �� TextAlignment$ Center=�5      $��20(�6/   �� 5      -   5         ��Name$ 	TxtSearch��5      $��1��6)   $
��10,5q�69   6G   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ 
GrdProduct��5       $��1��6'   $��0��64   $��10q�6D      
IsReadOnly . 6P   �� 5"   
   $��1��6   $��1��6   $��10q�6.   
��� d �
�������$��2q�5#       � DataContext 6%   �� *SelectedItem+	 �� ElementName$	 
GrdProduct��._�5$      �� $��10q�6   .+�5&      �� $��Product Details��6   $��15(�62   $��	ExtraBold"�6@   $��Center=�5'      �� 5)      $��Title��6   �� 5*      ��6   �� *Title+�� 5,      $��Color��6   �� 5-      ��6   �� *Color+�� 5.      $��20��6   ��6%   �� *Color+�� 50      $��Price��6   �� 51      ��6   �� *Price+�� 53      $��	Reference��6   �� 54      ��6   �� *	Reference+56      57      58      59      