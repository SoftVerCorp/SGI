   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   -clr-namespace:SGI.AutoComboSGI.AutoCombo  5	   	   #    SGI.View.Ventas.RealizarVenta   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   F BWpfControls, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null$combo2http://wpfcontrols.com/  5   	   X	 TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46wpfext)http://schemas.xceed.com/wpf/xaml/toolkit 	 5   	   'comboclr-namespace:SGI.AutoCombo 	 5	   	     � Title$  Realizar una Venta��5
   	   $
��1200��6&   $	��688��5   	    � 	Resources 5      !   SGI.AutoCombo.ClientSuggest   ClientesProvider/   )SGI.AutoCombo.ProductosSuggestionProvider  ProductosProvider  clienteTemplate �� Padding � ColumnDefinitions � RowDefinitions �� Path  productosTemplate��%p  &	        &	      &	 &     &	 �      5   
   6     5   
   6,   �� 5   
   .R�5      �� $ 5q�6   ._�5      �  5      �� 5      $��40 �6+   �� 5       5      �� 5      �� 5      .+�5      �� $��2��6   $��32��5      $��32��5      $��Center=�5      $��Center=�5      $#��/Resources/Images/cliente.png��5       �� 5!      $
��Bold"�5"       $��1��5#       $��0��5$       $��Segoe UI)�5%       
�������$��Bottom=�5&       
���   ���5!       �� $ NombreFiscal�5&   ;   �� 5'      $��1��5(       $��1��5)       
�������$	��Top=�5*       
���������5'       �� $ NombreComercial�5*   8   5+      5,      5-      �� 5/   
   .R�50      �� $ 5q�6   ._�51      �  52      �� 53      $��40 �6+   �� 54       56      �� 57      �� 58      .+�5:      �� $��2��6   $��32��5;      $��32��5<      $��Center=�5=      $��Center=�5>      $%��/Resources/Images/productos.png��5?      �� 5@      $
��Bold"�5A       $��1��5B       $��0��5C       $��Segoe UI)�5D       
�������$��Bottom=�5E       
���   ���5@       �� $ NombreProducto�5E   ;   �� 5F      $��1��5G       $��1��5H       
�������$	��Top=�5I       
���������5F       �� $ Detalle�5I   8   5J      5K      5L      5M      .��5N      ]� .+�5O   
   �� $	��Top=�6   $��2q�5P      $��Datos del cliente��5Q      .��5T      � $	��160��6    5U      �� 5V      $
��auto �6'   �� 5W      $
��auto �6'   �� 5X      $
��auto �6'   �� 5Y      $��* �6'   �� 5Z      $
��auto �6'   �� 5[      $
��auto �6'   �� 5\      $
��auto �6'   �� 5]      $��* �6'   �� 5^       5`      �� 5a      $��40 �6$   �� 5b      $��40 �6$   �� 5c      $��40 �6$   �� 5d      $��* �6$   .+�5g      �� $��0��6   $��0��5h      $��Center=�5i      $��Cliente:��5j      -  'WpfControls.Editors.AutoCompleteTextBox  5m      -   5          Name$
 Actb��5w   "   $��Center=�5m   -   $��0��5n   "   $��1��5o   "   $��7��62   $��30��5p   "      DisplayMember$ NombreFiscal��5q   "      ItemTemplate# [ 5r   "   	   	Watermark$	 Buscar por nombre��5s   "   
   IconPlacement$

 Left=�5t   "      IconVisibility$ Visible=�5u   "      Provider# [  5v   "   |�.    SelectedItem 5{      �� 5|      $ SelectedCliente�6"    �� Mode$ TwoWay=�69    �� ValidationRules 5}      *   $SGI.AutoCombo.RequiredValidationRule  5~   "   5�         LoadingContent 5�      �� 5�      $��Cargando...��6$   $��5q�5�      
�������$��14(�5�      
���   �6+      Icon 5�      �� 5�      $��20��6!   $��20��6,   ._�5�      �� $'��!/Resources/Images/search_icon.png��6$   $��16��5�   $   $��16��5�   $   $��Center=�5�   $   $��Center=�5�   $   5�      5�      �� 5�      $��0��6   $��9��5�      $��Center=�5�      $��Center=�5�      $��Center=�5�      $��14(�5�      $��SemiBold"�6)   $��Center=�5�      $��Sin huella digital��5�       d� 	IsChecked 68   �� *SinHuellaDigital+5�      �� 5�      $��1��6   $��0��5�      $��Center=�5�      $��
Direccion:��5�      �� 5�      $��1��6   $��3��6'   $��1��5�      $��30��5�       �� 
IsReadOnly . ��5�      �� *SelectedCliente.Direccion+5�      �� 5�      $��2��6   $��0��5�      $��Center=�5�      $
��RFC:��5�      �� 5�      $��2��6   $��1��5�      $	��140��5�       . ��5�      �� *SelectedCliente.RFC+5�      �� 5�      $��2��6   $��2��5�      $��Center=�5�      $
��C.p:��5�      �� 5�      $��2��6   $��3��5�       . ��5�      �� *SelectedCliente.CP+5�      �� 5�      $��1��6   $��4��5�      $��Center=�5�      $��Ciudad:��5�      �� 5�      $��1��6   $	��120��5�      $��5��5�       . ��5�      �� *SelectedCliente.Ciudad+5�      �� 5�      $��1��6   $��6��5�      $��Center=�5�      $��Estado:��5�      �� 5�      $��1��6   $��2��5�      $��7��5�      ��5�      �� *SelectedCliente.Estado+�� 5�      $��2��6   $��4��5�      $��Center=�5�      $��
Ubicacion:��5�      �� 5�      $��2��6   $��5��5�      $��3��5�      $��30��5�      
�������$	��1pxq�5�      
���������5�      �� *	Ubicacion+5�      �� 5�      $��3��6   $��0��5�      $��Center=�5�      $��Tipo de venta:��5�      �� 5�      $��1��6   $��3��5�      $��30��5�       �� DisplayMemberPath$ Nombre��5�       �� SelectedValuePath$ Id��5�      ��5�      �� *TiposDeVenta+ �� SelectedValue 5�      �� *IdTipoDeVenta+�� 5�      $��3��6   $��0��6,   $��9��6<    �� Orientation$ 
Horizontal=�6P   $��Right=�6i   .+�5�      �� $��35��6   $��Limpiar��6)   $	��120��6Z   $
��Left=�6f   $��2q�6�   ��6;   �� *
LimpiarCmd+6�   �� 5�      $��35��6   $��Realizar Venta��6)   $	��120��6g   $
��Left=�6s   ��6B   �� *RealizarVentaCmd+6s   5�      5�      5      �� 5  
   $��Bottom=�6   $��Right=�6.   $ 
Horizontal=�6J   .+�5     �� $��2��6   $��0��5     $��Center=�5     $��35��6<   $��TOTAL : ��5     $��17(�6,   $��SemiBold"�6:   
����  �6P   $ 	 Xceed.Wpf.Toolkit.DoubleUpDown  5     $��35��6#   � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   AutoSelectBehavior$ OnFocus=�6/   , 	 &Xceed.Wpf.Toolkit.Primitives.InputBase   
IsReadOnly . � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ShowButtonSpinner .  $	��150��5	     $��18(�6*   $
��Bold"�68   $��Center=�6L      	Watermark$ Total��5
         FormatString$ C2��63      Value 5     �� *
TotalTotal+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5     �� 5  
   $��Detalle de venta��6   $��2q�6-   .��5     ]� .+�5     � $	��Top=�6    5     �� 5     $
��auto �6+   �� 5     $��* �6+   �� 5     $
��Auto �6+   �� 5     $
��Auto �6+   �� 5     $
��Auto �6+   �� 5     $
��Auto �6+   .+�5     �� $��0��6   $��Center=�5     $��	Producto:��5     $��70��6,     5     -   5        $ comboproductos��5&  "   $��Center=�5  1   $��1��6L   $��30��5  "   $ NombreMostrar��5   "   # [ 5!  "   $	 Buscar por nombre��5"  "   $

 Left=�5#  "   $ Visible=�5$  "   # [ 5%  "    5'     �� 5(     $ SelectedProducto�6&   $ TwoWay=�6>    5)  "     5*  &   5,      5.     �� 5/     $��Cargando...��6(   $��5q�50     
�������$��14(�51     
���   �6+    53     �� 54     $��20��6%   $��20��60   ._�55  "   �� $'��!/Resources/Images/search_icon.png��6(   $��16��56  (   $��16��57  (   $��Center=�58  (   $��Center=�59  (   5:     5<     �� 5>     $��	Pedimento��6   $��2��60   �� 5@     $��3��6   $	��250��6/   $��30��6;   ��6G   �� *
Pedimentos+ 5A     �� *PedimentoSeleccionado+%	 	 Xceed.Wpf.Toolkit.IntegerUpDown	  5C     �
 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  AutoSelectBehavior$ OnFocus=�6,   $��4��6I   $��30��6Y   $��90��5D     $��14(�6)   $
��Bold"�67     
  	Increment$  1X�6J   $��Center=�6X   � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]!   Minimum$! 0X�5E     $ Cantidad��6+   "   DefaultValue$" 1X�6@   #   Value# 5F     �� *SelectedProducto.Cantidad+$ TwoWay=�$ PropertyChanged=��� 5G     $��5��6!   $ 
Horizontal=�61   .+�5H     �� $��35��6!   $��Añadir��6-   $��60��6e   $
��Left=�6p   ��6>   �� *AgregarProductoCmd+6p   �� 5I     $��35��6!   $��Series..��6-   $��60��6h   $
��Left=�6s   ��6@   �� *EliminarProductoCmd+6s   �� 5J     $��35��6!   $��Eliminar��6-   $��60��6h   $
��Left=�6s   ��6@   �� *EliminarProductoCmd+6s   5K     5L     &   System.Windows.Controls.DataGrid  5M     -   5        $  Name$$ dgSuppliers��5M     %   AutoGenerateColumns% .  &   AlternatingRowBackground& �#d5d5d5'   CanUserAddRows' .  (   
IsReadOnly( .  )   CanUserResizeRows) . ��5R     �� *ProductosCompra+* �� SelectedItem* 6;   �� *SelectedProductoVenta+$ TwoWay=�+   Columns+ 5T     0  *System.Windows.Controls.DataGridTextColumn  5V     ,  &System.Windows.Controls.DataGridColumn,   Width5  /System.Windows.Controls.DataGridLengthConverter$, * 6-   -   CanUserResize- . .   Header$. Producto��5Y  %   /   
IsReadOnly/ . 1  +System.Windows.Controls.DataGridBoundColumn0   Binding0 5W  %   �� *NombreProducto+5[       5]     $
, 0.5* 6-   - . $. Clave��5`  %   / . 0 5^  %   �� *CveTeknobike+1   ElementStyle1 5b     �� 5c  "   2 �� 
TargetType"2 ��6(   .�5d  &   �� 3 �� Property3 � ��4 �� Value$4 Center=�6L   5e  #   5g       5i     $	, 150 6-   - . $. 	Pedimento��5l  %   / . 0 5j  %   �� *NombreProducto+5n     4  .System.Windows.Controls.DataGridTemplateColumn  5p     $	, 100 61   - . $. Cantidad��5r  )   / .  5   CellTemplate5 5u     �� 5v  "   .R�5w  &   �� $��Center=�5x  (   ��5y  (   �� *
Cantidad+5z  #   6   CellEditingTemplate6 5|     �� 5}  "   .R�5~  &   �� $��Center=�6.   ��6S   �� *
Cantidad+$ PropertyChanged=�.��6�   .��5�  E   5�  '   5�  #   7   	CellStyle7 5�     �� 5�  "   *  $System.Windows.Controls.DataGridCell"2  6(   .�5�  &   �� 3 �@ 	IsEditing4 . 6B   8 �� Triggers8 5�  &   P� 5�  *   9 P� Property9 �@ 
IsSelected: P� Value: . . �5�  .   �� 3 � ��4 �#ff99006K   �� 5�  .   3 � ��
4 �   �6K   �� 5�  .   3 � ��
4 ���� 6L   �� 5�  .   3 � ��$4 0q�6P   5�  +   5�  #   5�       5�     $
, auto 6-   - . $. Precio unidad $��5�  %   / . 0 5�  %   �� *PrecioUnitario+; �� StringFormat$; {0:C}��1 5�     �� 5�  "   "2 ��6(   .�5�  &   �� 3 � ��$4 Center=�6L   5�  #   5�       5�     $
, auto 6-   - . $. Costo $��5�  %   / . 0 5�  %   �� *TotalProducto+$; {0:C}��1 5�     �� 5�  "   "2 ��6(   .�5�  &   �� 3 � ��$4 Center=�6L   5�  #   5�       5�     $	, 100 6-   - . $. Desc. %��5�  %   / . 0 5�  %   �� *	Descuento+$; {0:0} %��1 5�     �� 5�  "   "2 ��6(   .�5�  &   �� 3 � ��$4 Center=�6L   �� 5�  &   3 �@�ToolTip4 6@   �� *TipoDescuento+5�  #   5�       5�     $	, 100 6-   - . $. Desc. $��5�  %   / . 0 5�  %   �� *PrecioDescuento+$; {0:C}��1 5�     �� 5�  "   "2 ��6(   .�5�  &   �� 3 � ��$4 Center=�6L   �� 5�  &   3 �@�ToolTip4 6@   �� *TipoDescuento+5�  #   5�       5�     $	, 100 6-   - . $. Total��5�  %   / . 0 5�  %   �� *
TotalTotal+$; {0:C}��1 5�     �� 5�  "   "2 ��6(   .�5�  &   �� 3 � ��$4 Center=�6L   5�  #   5�     5�     5�     5�     5�     5�     