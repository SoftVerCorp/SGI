   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SGI.AutoComboSGI.AutoCombo  5   	   'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   4    .SGI.View.Inventarios.TransferenciaDeInventario   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   'comboclr-namespace:SGI.AutoCombo  5   	   F BWpfControls, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null$combo2http://wpfcontrols.com/  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   -   5          �Name$  viewTransferInv��5	   -    � Title$! Transferencia De Inventario��6	   $	��850��5
   	   $	��688��5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $- '/Resources/Styles/ItemsFilterStyle.xaml?�6%   �� 5      $ /Resources/Templates.xaml?�6%   %    5      .��5      ]� .+�5   
   �� $��2q�6   $	��Top=�5      $��Datos de la Transferencia��5      .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��80��6   $
��Left=�5      $��5,0,0,0q�6:   $��Origen:��5      �� 5      $��0��6   {�.  $��1��5      $��30��5       $	��220��6&   $��5,2,5,2q�5!       �� DisplayMemberPath$ Nombre��6+    �� SelectedValuePath$ Id��6F   ��6_   �� *Origen+ �� SelectedValue 6~   �� *IdUbicacionOrigen+5#      �� 5%      $��80��6   $��5,0,0,0q�5&      $
��Left=�5'      $��Destino:��5(      �� 5*      $��0��6   $��3��5+      $	��220��5,      $��30��5-      $��5,2,5,2q�5.      $ Nombre��5/      	 �� SelectedIndex$	 0��51      $ Id��53      ��50      �� *	Destino+ 52      �� *IdUbicacionDestino+53      56      �� 58      $��0,2,0,0q�6   $ 
Horizontal=�6.   .+�5;      �� $��80��6   $��5,0,0,0q�5<      $
��Left=�5=      $��Fecha Envio:��5>      (  "System.Windows.Controls.DatePicker  5@      $	��170��6!      styleDatePicker#��[  5C   !   
   SelectedDate
 5A   !   �� *FechaSeleccionada+ �� UpdateSourceTrigger$ PropertyChanged=�5C   !   �� 5E      $��0��6   $��2��5F      $��5,0,0,0q�5G      $
��Left=�5H      $��No Guia:��5I      �� 5K      $	��170��6   ��6*   �� *Guia+$ PropertyChanged=��� 5M      $��80��6   $��5,0,0,0q�5N      $
��Left=�5O      $��Paqueteria:��5P      �� 5R      $��0��6   $��3��5S      $	��220��5T      $��30��5U      $��5,2,5,2q�5V      $ Nombre��5W      $	 0��5Y      $ Id��5[      ��5X      �� *Paqueterias+ 5Z      �� *IdPaqueteriaSeleccionada+5[      5]      5^      5`      �� 5b   
   $��2q�6   $	��Top=�5c      $��Datos del Producto��5d      .��5g      �� $ Vertical=�6   .+�5h      �� $ 
Horizontal=�6   .+�5i      �� $��1��6   $��90��6)   $��0��5j      $��5,0,0,0q�5k      $
��Left=�5l      $��	Producto:��5m      -  'WpfControls.Editors.AutoCompleteTextBox  5o      -   5          Name$ comboproductos2��5o   1   $��1��5p   1   $��1��5q   1   $	��695��5r   1   $��35��5s   1   $��5,0,0,0q�5t   1   $��Center=�5u   1      DisplayMember$ NombreMostrar��5v   1      IconPlacement$
 Left=�5w   1      IconVisibility$ Visible=�5x   1    " productosTransferenciaTemplate   ItemTemplate# [ 5y   1    " ProductosTransferenciaProvider   Provider# [ 5z   1      	Watermark$ Buscar por nombre��5{   1      SelectedItem 5|      �� 5}       �� Mode$ TwoWay=�6&    �� Path$ SelectedProducto�64    �� ValidationRules 5~   "   *   $SGI.AutoCombo.RequiredValidationRule  5   &   5�         LoadingContent 5�      �� 5�      $��5q�6(   
�������$��14(�5�   (   
���   �$��Cargando...��5�   (      Icon 5�      �� 5�      $��20��6%   $��20��60   ._�5�   "   �� $��16��6(   $��16��5�   (   $��Center=�5�   (   $��Center=�5�   (   $'��!/Resources/Images/search_icon.png��5�   (   5�      5�      5�      �� 5�      $��0,2,0,0q�6   $ 
Horizontal=�6.   .+�5�      �� $��5,0,0,0q�6   $
��Left=�5�      $��Descripción :��5�      $��90��64   �� 5�      $	��695��6   $��5,0,0,0q�6*    �� 
IsReadOnly . ��5�      �� *	Detalle+5�      �� 5�      $��0,2,0,0q�6   $ 
Horizontal=�6.   .+�5�      �� $��3��6   $��90��6)   $��2��5�      $��5,0,0,0q�5�      $
��Left=�5�      $��Usuario:��5�      �� 5�      $��3��6   $��3��5�      $	��300��5�      $��30��5�      $��7,2,5,2q�5�       . ��5�      �� *UsuarioLogueado+�� 5�      $��3��6   $��2��5�      $��5,0,0,0q�5�      $
��Left=�5�      $��
Pedimento:��5�      �� 5�      $��0��6   $��1��5�      $	��300��5�      $��30��5�      $��10,2,5,2q�5�      $	 0��5�      ��5�      �� *
Pedimentos+ 5�      �� *PedimentoSeleccionado+5�      �� 5�      $��0,5,0,0q�6   $ 
Horizontal=�6.   .+�5�      �� $	��120��6   $��35��5�      $��2q�5�      $
��Left=�5�      $��Nuevo��5�      ��5�      �� *NuevoProductoCmd+5�      �� 5�      $	��120��6   $��35��5�      $��2q�5�      $
��Left=�5�      $��Añadir��5�      ��5�      �� *AgregarProductoAlGridCmd+5�      �� 5�      $	��120��6   $��35��5�      $��2q�5�      $
��Left=�5�      $��Realizar Transpaso��5�      ��5�      �� *CrearTraspasoCmd+5�      5�      5�      5�      �� 5�   
   $��7��6   
�������$	��Top=�5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ dgSuppliers��5�   "   $��4��5�   "   $��5,0,5,5q�5�   "   &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�   "   �� *
Detalles+   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5     ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)       CanUserResize  . !   Header$! Producto��5  )   "   
IsReadOnly" .  #   CellTemplate# 5     �� 5     .R�5	     �� $��1,1,4,1q�6$   $
��Left=�5
  $   $��Center=�5  $   ��5  $   �� *
Producto+$ TwoWay=�$ PropertyChanged=�5     5       5     $	 100 6)     . $! 	Pedimento��5  )   " .  # 5     �� 5     .R�5     �� $��1,1,4,1q�6$   $
��Left=�5  $   $��Center=�5  $   ��5  $   �� *	Pedimento+$ TwoWay=�$ PropertyChanged=�5      5#       5%     $
 auto 6)     . $! Cantidad Disponible��5'  )   " .  # 5)     �� 5*     .R�5+     �� $��1,1,4,1q�6$   $
��Left=�5,  $   $��Center=�5-  $   ��5.  $   �� *CantidadDisponible+$ TwoWay=�$ PropertyChanged=�51     54       57     $
 auto 6)     . $! Cantidad Traspaso��59  )   " .  # 5;     �� 5<     .R�5=     �� $��1,1,4,1q�6&   $��Center=�5>  &   $��Center=�5?  &   ��5@  &   �� *
Cantidad+$ TwoWay=�$ PropertyChanged=�5C     $   CellEditingTemplate$ 5F     �� 5G     .R�5H     �� $��1,1,1,1q�6&   $��Center=�5I  &   $��Center=�5J  &   ��5K  &   �� *
Cantidad+$ PropertyChanged=�$ TwoWay=�.��5M  C   .	  (System.Windows.Interactivity.Interaction% 	  Triggers% 5N  "   /
  )System.Windows.Interactivity.EventTrigger
  5O  &   & 
  	EventName$& Loaded��65   .  (System.Windows.Interactivity.TriggerBase'   Actions.' 5P  *   8   2SGI.Stuffs.TakeFocusAndSelectTextOnVisibleBehavior  5Q  '   .��5R  :   5S     5T     (   	CellStyle( 5W     �� 5X     ) �� 
TargetType*  $System.Windows.Controls.DataGridCell")  6    .�5Y     �� * �� Property* �@ 	IsEditing+ �� Value+ . 6:   , �� Triggers, 5Z     P� 5[  "   - P� Property- �@ 
IsSelected. P� Value. . . �5\  &   �� * � ��+ �#ff99006C   �� 5]  &   * � ��
+ �   �6C   �� 5^  &   * � ��
+ ���� 6D   �� 5_  &   * � ��$+ 0q�6H   5`  #   5b     5d       5h     $ 50 6)   # 5i     �� 5j     .R�5k     �� ��6&   �� / �� ElementName$/ viewTransferInv��$% DataContext.EliminarElementoCmd���5l  &   �� .��5m  "   �� $��25��6(   $��30��5n  (   $'��!/Resources/Images/imgDelete32.png��5o  (   $
��Fill=�5p  (   5q     5r     5t     5{     5|     5}     