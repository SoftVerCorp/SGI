   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   -clr-namespace:SGI.AutoComboSGI.AutoCombo  5	   	       SGI.View.Ventas.Abonos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   F BWpfControls, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null$combo2http://wpfcontrols.com/  5   	   X	 TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46wpfext)http://schemas.xceed.com/wpf/xaml/toolkit 	 5   	   'comboclr-namespace:SGI.AutoCombo 	 5	   	   -   5          �Name$  
AbonosView��5
   3    � Title$ Abonos��6	   $	��700��6   $
��1100��6&    � 	Resources 5      -   'SGI.AutoCombo.ClientsSuggestionProvider   ClientesProvider  clienteTemplate �� Padding � ColumnDefinitions � RowDefinitions �� Path��%�  &	        &	        5   
   6*   �� 5   
   .R�5      �� $ 5q�6   ._�5      �  5      �� 5      $��40 �6+   �� 5       5      �� 5      �� 5      .+�5      �� $��2��6   $��32��5      $��32��5      $��Center=�5      $��Center=�5      $#��/Resources/Images/cliente.png��5      �� 5      $
��Bold"�5        $��1��5!       $��0��5"       $��Segoe UI)�5#       
�������$��Bottom=�5$       
���   ���5       �� $ Nombre�5$   ;   �� 5%      $��1��5&       $��1��5'       
�������$	��Top=�5(       
���������5%       �� $ Detalle�5(   8   5)      5*      5+      5,      .��5-      �  5.   
   �� 5/      6!    51   
   �� 52      $	��150 �6   6+   �� 53      6   .+�57   
   �� $��Busqueda��6   $��2��6%   .��58      �  59      �� 5:      $
��auto �6'   �� 5;      �� 5<      $
��auto �6'   �� 5=      �� 5>      $
��auto �6'   �� 5?       5A      �� 5B      �� 5C      �� 5D      .+�5G      �� $��Desde:��6   $��0��6)   $��0��66   (  "System.Windows.Controls.DatePicker  5H        styleDatePicker#���  6   $��0��6m   $��1��6z      SelectedDate 6G   �� *FechaInicial+6z   �� 5J      $��Hasta:��6   $��0��6)   $��2��66     5K      #���  6   $��0��6k   $��3��6x    6G   �� *
FechaFinal+6x   �� 5M      $��Cliente:��6   $��0��6+   $��4��68   -  'WpfControls.Editors.AutoCompleteTextBox  5N      -   5          Name$
 Actb��5X   "   $��Center=�5N   -   $��0��5O   "   $��5��5P   "   $��30��5Q   "   	   DisplayMember$	 Nombre��5R   "   
   ItemTemplate#
 [ 5S   "      	Watermark$ Buscar por nombre��5T   "      IconPlacement$
 Left=�5U   "      IconVisibility$ Visible=�5V   "      Provider# [  5W   "      SelectedItem 5Y      �� 5Z      $ SelectedCliente�6"    �� Mode$ TwoWay=�69    �� ValidationRules 5[      *   $SGI.AutoCombo.RequiredValidationRule  5\   "   5^         LoadingContent 5`      �� 5a      $��Cargando...��6$   $��5q�5b      
�������$��14(�5c      
���   �6+      Icon 5e      �� 5f      $��20��6!   $��20��5g      ._�5h      �� $'��!/Resources/Images/search_icon.png��6$   $��16��5i      $��16��5j      $��Center=�5k      $��Center=�5l      5m      5o      �� 5q      $��0��6   $��1��6*   $��
Ubicación��67   �� 5r      $��1��6   $��1��6+   $��30��5s      $��0q�5t       �� DisplayMemberPath$ Nombre��5u       �� SelectedValuePath$ Id��67   {�5r   9   �� *IsEnableCmbUbicacion+��5v      �� *Ubicaciones+ �� SelectedItem 6?   �� *UbicacionSeleccionada+�� 5�      $��2��6   $��0��6*   $��6��6:    �� Orientation$ 
Horizontal=�6N   $��Center=�6g   $
��Left=�6�   .+�5�      �� $	��120��6   $��35��6)   $��Buscar��65   $��2q�6F   ��6Q   �� *	BuscarCmd+�� 5�      $	��120��6   $��35��6)   $��Limpiar Busqueda��65   $��2q�6o   ��6P   �� *
LimpiarCmd+6o   5�      5�      5�      &   System.Windows.Controls.DataGrid  5�   
   $��1��6   $��0��6    $��5,0,5,5q�5�         AutoGenerateColumns .     AlternatingRowBackground �#d5d5d5   CanUserAddRows .     
IsReadOnly .     CanUserResizeRows . ��5�      �� *Ventas+ 63   �� *VentaSeleccionada+.  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      	   SGI.Stuffs.EventToCommand	    	  Command  6*   �� *SelectedITemGridClick+! 	  CommandParameter! 6T   �� *	EventArgs+" �� RelativeSource" �� *Self+5�      #   Columns# 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn$   Width5  /System.Windows.Controls.DataGridLengthConverter$	$ 150 6%   %   CanUserResize% . &   Header$& Fecha��5�   %   '   
IsReadOnly' . 1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 5�   %   �� *Fecha+5�      
  5�      $	$ 150 6%   % . $& 
Ubicación��5�   %   ' . ( 5�   %   �� *	Ubicacion+5�      
  5�      $	$ 150 6%   % . $& Vendedor��5�   %   ' . ( 5�   %   �� *
Vendedor+5�      
  5�      $	$ 200 6%   % . $& Cliente��5�   %   ' . ( 5�   %   �� *	Cliente+5�      
  5�      $	$ 200 6%   % . $& Tipo de Venta��5�   %   ' . ( 5�   %   �� *TipoDeVenta+5�      
  5�      $
$ auto 6%   % . $& Estatus��5�   %   ' . ( 5�   %   �� *	Estatus+5�      
  5�      $$ * 6%   % . $& Total $��5�   %   ' . ( 5�   %   �� *
MontoTotal+) �� StringFormat$) {0:C}��*   ElementStyle* 5�      �� 5�      + �� 
TargetType"+ ��6    .�5�      �� , �� Property, � ��- �� Value$- Center=�6D   5�      5�      5�      5�      5�      