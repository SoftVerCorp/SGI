   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   %    SGI.View.OrdenesDeCompraRecibir   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  OrdenesDeCompra��5   	   $	��950��5   	   $	��656��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      ]� .+�56   
   �� $	��140��6   $��2q�57      $	��Top=�58      $��14(�59      $"��Información Orden de Compra��5:      .��5;      �  � ColumnDefinitions 5<      �� 5=      $
��auto �6'   �� 5>      $
��auto �6'   �� 5?      $
��auto �6'   �� 5@      �� 5A      $
��auto �6'   �� 5B       � RowDefinitions 5D      �� 5E      �� 5F      �� 5G      .+�5J      �� $��0��6   $��0��5K      $��	Número: ��5L      �� 5M      $��0��6   $��1��5N      $	��150��5O       �� 
IsReadOnly . ��5Q      �� *Number+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5U      $��0��6   $��2��5V      $��Fecha de emisión: ��5W      �� 5Y      $��0��6   $��3��5Z      $	��175��5[      $
��Left=�5\       . ��5^      �� *
DateOutPut+$ PropertyChanged=��� 5k      $��0��6   $��4��5l      $��Proveedor: ��5m      �� 5n      $��0��6   $��5��5o      $	��190��5p      $
��Left=�5q       . ��5s      �� *SupplierName+$ TwoWay=�$ PropertyChanged=��� 5�      $��1��6   $��0��5�      $��Condición de pago: ��5�      �� 5�      $��1��6   $��1��5�      $	��150��5�       . ��5�      �� *SelectedTypePay+$ TwoWay=�$ PropertyChanged=��� 5�      $��1��6   $��2��5�      $��Dias: ��5�      �� 5�      $��1��6   $��3��5�      $	��175��5�      $
��Left=�5�       . ��5�      �� *Days+$ TwoWay=�$ PropertyChanged=��� 5�      $��1��6   $��4��5�      $��	Estatus: ��5�      �� 5�      $��1��6   $��5��5�      $	��190��5�      $
��Left=�5�       . ��5�      �� *	EstatusOC+$ TwoWay=�$ PropertyChanged=��� 5�      $��2��6   $��4��5�      $��2��5�      $
��Auto��5�      $��5,10,5,2q�5�      $��Right=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� -   5        $��btnAutorizar��5�      $	��120��5�      $��25��5�      $��0 0 2 0q�5�      $��Right=�5�      $��	Autorizar��5�      ��5�      �� *Accept+5�      5�      5�      5�      �� 5�   
   $��4��6   $ Vertical=�6"   .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ dgOrderBuyDetail��5�      $��0��5�      $��2,5,2,5q�5�      	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     CanUserResizeRows . ��5�      �� *DetailOrderList+ �� IsAsync .    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6)      CanUserResize .    Header$ Linea��5�   )      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   )   �� *Line+5�   )     5�      $
 0.5* 6)    . $ Clave TeknoBike��5�   )    .  5�   )   �� *ClaveTeknoBike+5�   )     5�      $
 0.6* 6)    . $ Clave Proveedor ��5�   )    .  5�   )   �� *ClaveProveedor+5�   )     5�      $
 0.5* 6)    . $ Descripción��5�   )    .  5�   )   �� *ProductDescription+5�   )     5�      $
 0.5* 6)    . $ Cantidad��5�   )    .  5�   )   �� *
Quantity+5�   )     5�      $
 0.5* 6)    . $ Precio unitario��5�   )    .  5�   )   �� *	UnitPrice+5�   )     5     $
 0.5* 6)    . $ Total��5  )    .  5	  )   �� *Total+5  )   5     �� 5     $��2,5,5,2q�6   $��Right=�5     $ 
Horizontal=�5     .+�5     �� $��Total General: ��6   �� 5     $	��175��6   $
��Left=�5      . ��5     �� *TotalGeneral+$ TwoWay=�$ PropertyChanged=�5     5     5     5      