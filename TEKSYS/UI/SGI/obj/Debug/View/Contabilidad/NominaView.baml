   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SGI.View.ContabilidadSGI.View.Contabilidad  5   	   -clr-namespace:SGI.AutoComboSGI.AutoCombo  5	   	   'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   &     SGI.View.Contabilidad.NominaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SGI.View.Contabilidad     5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46wpfext)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   F BWpfControls, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null$combo2http://wpfcontrols.com/  5   	   'comboclr-namespace:SGI.AutoCombo  5	   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   !bhclr-namespace:SGI.Stuffs  5   	   F	 BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter 	 5   	     � Title$  
NominaView��5   	   $
��1280��5   	   $
��Auto��5   	    � WindowState$ 	Maximized=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   .+�5      &   System.Windows.Controls.Calendar     DisplayMode$ Month=�6      SelectionMode$ 
SingleDate=�6+   $��0��6m      SelectedDate 6F   �� *SelectedDate+5       �� 5"      $��1��6   $��Datos��6$   $��1��64   .��5$      �  5%      �� 5&      $
��Auto �6(   68   �� 5'      $
��Auto �6(   68   .+�5*      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�5+      �� $��Nomina:��6    64   �� 5,      ��6    �� *
YearNomina+6A   �� 5-      $��
 Quincena ��6    67   �� 5.      ��6    �� *
WeekNomina+6A   5/      � 51      $��1��6    52      �� 53      $
��Auto �6,   6<   �� 54      $
��Auto �6,   6<   �� 55      $
��Auto �6,   6<   �� 56      $
��Auto �6,   6<    58      �� 59      $	��150 �6/   6=   �� 5:      $��* �6/   6;   .+�5=      �� $��0��6    $��0��60   $��Concepto��6=   6R   �� 5>      $��1��6    $��0��60   ��6=   �� *
Concepto+6\   �� 5@      $��0��6    $��1��60   $��Periodo��6=   6Q   �� 5A      $��1��6%   $��1��65   $ 
Horizontal=�6C   .+�5B      �� ��6%   �� *	BeginDate+6E   �� 5C      $��al��6%   64   �� 5D      ��6%   �� *	EndDate+6C   5E      �� 5G      $��0��6    $��2��60   $��Fecha de Pago��6=   6W   �� 5H      $��1��6    $��2��60   ��6=   �� *	FechaPago+6]   5J      5L      5M      5O      � 5Q   
   $��2��6    5R      �� 5S      $
��Auto �6    60   �� 5T      $��* �6    6-   .+�5W      �� $��0��6   $ 
Horizontal=�6&   .+�5X      �� $	��120��66   $��40��6B   ��6   �� *
SalirCmd+.��5Y      �� $ 
Horizontal=�6"   $
��Left=�6;   $	��Top=�6V   .+�5[      �� $��Salir [Shift-Esc]��6$   $��Center=�6=   6\   5\      5]      �� 5^      $	��150��66   $��40��6B   ��6   �� *
SalirCmd+.��5_      �� $ 
Horizontal=�6"   $
��Left=�6;   $	��Top=�6V   .+�5a      �� $��Generar Nomina del Mes��6$   $��Center=�6B   6a   5b      5c      5d      �� 5g      $��1��6   $��Nominas��6$   .��5h      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  
�������	   SelectionMode$	 Single=�5l      
   FrozenColumnCount$
 1��5m      $
��Auto=�5n      ��5k      �� *ChecadasMes+ �� IsAsync .    Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      ,  &System.Windows.Controls.DataGridColumn   Header$ Empleado��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6?   6M     5r      $	 RFC��6-   $	 200 6:   6H     5s      $
 Pago��6-   $	 100 6;   6I     5t      $ Percepciones��6-   $	 100 6C   6Q     5u      $ Deducciones��6-   $	 100 6B   6P     5v      $
 Pago��6-   $	 100 6;   6I     5w      $	 ISR��6-   $	 100 6:   6H   5z      5{      5}      5      5�      