   M S B A M L   `   `   `  ����  SGI&     SGI.View.CreditoYCobranza.Abonar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Abonar��5   	   $	��500��6   $	��700��6%   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      6   �� 5	      $	��140 �6   6+   .+�5   
   �� $��Abonar��6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Cantidad��6   �� 5      $	��150��6   ��6&   �� *
Cantidad+�� 5      $��10,0,0,0q�6   $��Fecha de abono��6*   (  "System.Windows.Controls.DatePicker  5         styleDatePicker#��[  6   $	��150��6e      SelectedDate 6F   �� *Fecha+6e   �� 5      $��Realizar Abono��6   $	��120��62   $��35��6>   $��10,0,0,0q�6h   ��6J   �� *	AbonarCmd+6h   5      5      &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��0��6    $��5,0,5,5q�5         AutoGenerateColumns .     AlternatingRowBackground �#d5d5d5   CanUserAddRows .     
IsReadOnly .     CanUserResizeRows . ��5      �� *Abonos+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 180 6%      CanUserResize .    Header$ Fecha��5"   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5    %   �� *
FechaAbono+5$        5&      $
 * 6%    . $ Total $��5)   %    .  5'   %   �� *
Cantidad+ �� StringFormat$ {0:C}��   ElementStyle 5+      �� 5,       �� 
TargetType" ��6    .�5-      ��  �� Property � �� �� Value$ Center=�6D   5.      50      53      � 55   
   $��2��6    56      �� 57      �� 58      �� 59      �� 5:       � ColumnDefinitions 5=      �� 5>      �� 5?      �� 5@      �� 5A      .+�5C      �� $��Abonos��6   $��0��6%   $��2��62   �� 5D      $��0��6   $��3��6#    �� 
IsReadOnly . ��63   �� *TotalAbonos+6P   �� 5E      $��Restan��6   $��1��6%   $��2��62   �� 5F      $��1��6   $��3��6#    . ��63   �� *Restan+6K   �� 5G      $��Total��6   $��2��6$   $��2��61   �� 5H      $��2��6   $��3��6#    . ��63   �� *
TotalVenta+6O   5I      5K      5L      