   M S B A M L   `   `   `  ����  SGI"    SGI.View.Ventas.DetalleVenta   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Detalle de la Venta��5   	   $	��500��6%   $
��1000��62   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  $��1��6   $��0��6    $��5,0,5,5q�5         AutoGenerateColumns .     AlternatingRowBackground �#d5d5d5   CanUserAddRows .     
IsReadOnly .     CanUserResizeRows . ��5      �� *DetalleVenta+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6%      CanUserResize . 	   Header$	 Producto��5   %   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� *
Producto+5        5      $	 150 6%    . $	 Clave��5   %   
 .  5   %   �� *Clave+5        5      $	 150 6%    . $	 	Pedimento��5!   %   
 .  5   %   �� *	Pedimento+5#        5&      $	 100 6%    . $	 Cantidad��5)   %   
 .  5'   %   �� *
Cantidad+5+        5-      $	 100 6%    . $	 Precio Unitario��50   %   
 .  5.   %   �� *PrecioUnitario+52        54      $	 100 6%    . $	 	Descuento��57   %   
 .  55   %   �� *	Descuento+59        5=      $ * 6%    . $	 Total $��5@   %   
 .  5>   %   �� *Total+ �� StringFormat$ {0:C}��   ElementStyle 5B      �� 5C       �� 
TargetType" ��6    .�5D      ��  �� Property � �� �� Value$ Center=�6D   5E      5G      5K      5L      5M      