   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   '    !SGI.View.OC.OrdenCompraHomologada   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   #mvvmclr-namespace:SGI.Stuffs  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5      -   5          �Name$  wndOrdenCompraHom��5   A    � Title$ OrdenCompraHomologada��6	   $	��700��6'   $
��1100��64   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5         SGI.Stuffs.EventToCommand     Command 6"   �� *Loaded+   CommandParameter 6=   ��  �� ElementName$ wndOrdenCompraHom��5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��80 �6   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      .+�5   
   �� $��0��6   $��Datos del Proveedor��6    .��5   
   � 	 � ColumnDefinitions	 5      �� 5      $
��auto �6'   �� 5      �� 5      $
��auto �6'   �� 5      �� 5       $
��auto �6'    5"      �� 5#      �� 5$      .+�5&      �� $��0��6   $��0��6%   $��	Proveedor��65   �� 5'      $��0��6   $��1��6'   ��67   �� *	Proveedor+�� 5(      $��2��6   $��0��6(   $��	Direccion��65   �� 5)      $��0��6   $��3��6'   $��2��6R   ��67   �� *	Direccion+6R   �� 5*      $��0��6   $��1��6(   $��Condición de pago��65   �� 5+      $��1��6   $��1��6'   ��67   �� *
TipoDePago+�� 5,      $��2��6   $��1��6(   $
��Dias��65   �� 5-      $��1��6   $��3��6'   ��67   �� *Dias+�� 5.      $��1��6   $��4��6&   $	��100��66   $��40��6B   $��Buscar��6N   ��6_   �� *BuscarProveedoresCmd+50      51      �� 53   
   $��2q�6   $��1��6   $	��Top=�54      $��14(�55      $"��Información Orden de Compra��56      $��2q�57      .��58      � $��Center=�6   	 59      �� 5:      $
��auto �6'   �� 5;      $��* �6'   �� 5<      $
��auto �6'   �� 5=      $��* �6'   �� 5>      $
��auto �6'   �� 5?      $
��0.5* �6'   �� 5@      $
��auto �6'   �� 5A      $��* �6'    5C      �� 5D      .+�5G      �� $��0��6   $��0��5H      $��Fecha: ��5I      (  "System.Windows.Controls.DatePicker  5J      $��0��6   $��1��5K         styleDatePicker#��[  5L      
   SelectedDate
 5K   *   �� *Fecha+5L      �� 5O      $��0��6   $��2��5P      $��Ubicación: ��5Q      �� 5S      $��0��6   $��3��5T      $��3��5U      $��30��5V      $��0q�5W       �� DisplayMemberPath$ Nombre��5X       �� SelectedValuePath$ Id��67   ��5Y      �� *Ubicaciones+ �� SelectedValue 6?   �� *UbicacionSeleccionada+�� 5�      $��0��6   $��6��5�      $��Usuario Genera: ��5�      �� 5�      $��0��6    �� 
IsReadOnly . $��7��5�      ��5�   :   �� *	Usuario+5�      5�      5�      �� 5�   
     BorderBottom#��[ 6   $��2��67   $��5��6D   /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$	 gr1��5�   "   $��3��5�      $��0��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *OrdenDeCompraProveedor+ �� Mode$ TwoWay=� 5�        5�      $ SelectionChanged��6!   . 5�         6*   �� *CambioSeleccionCmd+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 auto
 6%    	  CanUserResize .  	  Header$ Orden de Compra��5�   %    	  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   %   �� *IdOrdenCompra+5�   %     5�      $
 auto
 6%    . $ 	Proveedor��5�   %    .  5�   %   �� *	Proveedor+5�   %     5�      $
 auto
 6%    . $ 
Ubicación��5�   %    .  5�   %   �� *	Ubicacion+5�   %     5�      $
 0.7*
 6%    . $ Producto��5�   %    .  5�   %   �� *
Producto+5�   %     5�      $
 auto
 6%    . $	 UOM��5�   %    .  5�   %   �� *UOM+5�   %     5�      $
 auto
 6%    . $ 	Impuestos��5�   %    .  5�   %   �� *	Impuestos+5�   %     5�      $
 auto
 6%    . $ Linea��5�   %    .  5�   %   �� *Linea+5�   %     5�      $
 auto
 6%    . $ Precio Unitario��5�   %    .  5�   %   �� *PrecioUnitario+5�   %   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $
 auto
 6)    . $ 	Cantidad ��5�   1    .     CellTemplate 5�      �� 5�      .R�5�      �� $��1,1,4,1q�6&   $��Center=�5�   /   $��Center=�6S   ��5�   0   �� *
Cantidad+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�         CellEditingTemplate 5�      �� 5�      .R�5�      �� $��1,1,1,1q�6&   $��Center=�69   $��Center=�6]   ��5�   &   �� *
Cantidad+$ PropertyChanged=�$ TwoWay=�.��6q    5�   "     5�   &   $ Loaded��65   . 5�   *   8   2SGI.Stuffs.TakeFocusAndSelectTextOnVisibleBehavior  5�   '   .��5�   :   5�      5�       	  	CellStyle 5�      �� 5�       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5�      ��  �� Property �@ 	IsEditing  �� Value  . 6:   ! �� Triggers! 5      P� 5  "   " P� Property" �@ 
IsSelected# P� Value# . . �5  &   ��  � ��  �#ff99006C   �� 5  &    � ��
  �   �6C   �� 5  &    � ��
  ���� 6D   �� 5  &    � ��$  0q�6H   5  #   5     5
       5     $
 auto
 6%    . $ Total��5  %    .  5  %   �� *Total+5  %   5     �� 5  
   #��[ 6   $��4��67   $��5��6D   �� 5  
   $��Guardar��6   $��5��6#   $	��150��60   $��35��6<   $��Center=�6H   $��Right=�6c   ��6   �� *
GuardarCmd+  5  
   -   5        $	 gr2��5  "   $��6��5     $��0��5     $��2,5,2,5q�5      .  
������� .   . ��5#     �� *OrdenDeCompraProveedorTotal+$ �� IsAsync$ .  5&       5'     $ PreviewMouseDown��6!   . 5(        6*   �� *SelectedITemGridClick+ 6T   �� *	EventArgs+% �� RelativeSource% �� *Self+5)      5,       50     $ *
 6%    . $ Producto��53  %    .  51  %   �� *
Producto+54  %     56     $
 0.5*
 6)    . $ 	Cantidad ��58  1    .   5<     �� 5=     .R�5>     �� $��1,1,4,1q�6$   $��Center=�5?  /   $��Center=�6S   ��5@  0   �� *
Cantidad+$ TwoWay=�$ PropertyChanged=�5A     5E       5G     $
 auto
 6%    . $	 UOM��5J  %    .  5H  %   �� *UOM+5K  %     5M     $
 0.4*
 6%    . $ 	Impuestos��5P  %    .  5N  %   �� *	Impuestos+5Q  %     5S     $
 0.4*
 6)    . $ Linea ��5U  1    .   5Y     �� 5Z     .R�5[     �� $��1,1,4,1q�6&   $��Center=�5\  /   $��Center=�6S   ��5]  0   �� *Linea+$ TwoWay=�$ PropertyChanged=�5^      5a     �� 5b     .R�5c     �� $��1,1,1,1q�6&   $��Center=�69   $��Center=�6]   ��5d  &   �� *Linea+$ PropertyChanged=�$ TwoWay=�.��6n    5e  "     5f  &   $ Loaded��65   . 5g  *     5h  '   .��5i  :   5j     5k      5n     �� 5o     "  6    .�5p     ��  �@ 	IsEditing  . 6:   ! 5q     P� 5r  "   " �@ 
IsSelected# . . �5s  &   ��  � ��  �#ff99006C   �� 5t  &    � ��
  �   �6C   �� 5u  &    � ��
  ���� 6D   �� 5v  &    � ��$  0q�6H   5w  #   5y     5{       5}     $
 0.4*
 6%    . $ Precio Unitario��5�  %    .  5~  %   �� *PrecioUnitario+5�  %     5�     $
 0.4*
 6%    . $ Total��5�  %    .  5�  %   �� *Total+5�  %   5�     5�     5�     