   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   )    #SGI.View.Inventarios.VisorTraspasos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Consulta de traspasos��5   	   $
��1100��5   	   $	��688��5	   	    � 	Resources 5
       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      ]� .+�5   
   �� $��2q�6   $	��Top=�5      $��Filtros��5      .��5      � $	��130��6   $��2,5,2,2q�6     � ColumnDefinitions 5      �� 5      $	��100 �6'   �� 5      $	��200 �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5       � RowDefinitions 5      �� 5       $��40 �6$   �� 5!      $��40 �6$   �� 5"      $��40 �6$   �� 5#      $��* �6$   .+�5&      �� $��0��6   $��0��5'      $
��Left=�5(      $��Fecha Inicial:��5)      (  "System.Windows.Controls.DatePicker  5*      $��0��6   $��1��5+      $��30��5,      $��5,2,5,2q�5-         styleDatePicker#��[  5/         SelectedDate 5.      �� *FechaInicial+5/      �� 51      $��0��6   $��2��52      $��Center=�53      $��Fecha Final:��54        56      $��0��6   $��3��57      $	��150��58      $��30��59      $��5,2,5,2q�5:      #��[  5=       5;      �� *
FechaFinal+ �� Mode$ TwoWay=�5=      �� 5?      $��0��6   $��4��5@      $��Center=�5A      $��Ubicación Origen:��5B      �� 5D      $��0��6   $��5��5E      $	��150��5F      $��35��5G      $��2q�5H       �� DisplayMemberPath$ Nombre��5I       �� SelectedValuePath$ Id��5L      ��5J      �� *Ubicaciones+	 �� SelectedValue	 5K      �� *IdUbicacion+5L      �� 5\      $��1��6   $��0��5]      $��Center=�5^      $��Guia:��5_      �� 5a      $��1��6   $��1��5b      $��3��5c      ��5d      �� *Guia+$ TwoWay=��� 5g      $��2��6   $��6��5h      
 �� Orientation$
 
Horizontal=�5i      .+�5j      �� $	��120��6   $��35��5k      $��2q�5l      $
��Left=�5m      $��Buscar��5o      ��5n      �� *	BuscarCmd+5o      �� 5p      $	��120��6   $��35��5q      $��2q�5r      $
��Left=�5s      $��Limpiar��5u      ��5t      �� *
LimpiarCmd+5u      �� 5w      $	��120��6   $��35��5x      $��2,0,0,0q�5y      $
��Left=�5z      $��Recibir Productos��5|      ��5{      �� *
RecibirCmd+5|      �� 5~      $	��100��5      $��35��5�      $��2q�5�      $��Right=�5�      $��Exportar��5�       � ToolTip$ Exportar a Excel��5�      ��5�   2   �� *ExportarCmd+y�5�      �� *
IsModeAuto+5�      5�      5�      � 5�   
    5�      �� 5�      6%   �� 5�      6%   .+�5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  -   5          Name$ dgSuppliers��5�   &   $��0��5�   !   $��5,0,5,5q�5�   "   &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�   "   �� *MovInventario+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6.   �� *SelectedITemGridClick+   CommandParameter 6X   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 6)    	  CanUserResize .  	  Header$ Fecha Salida��5�   %    	  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   %   �� *FechaSalida+5�   %     5�      $ *
 6)    . $
 Guia��5�   %    .  5�   %   �� *Guia+5�   %     5�      $ *
 6)    . $ Origen��5�   %    .  5�   %   �� *Origen+5�   %     5�      $ *
 6)    . $ Destino��5�   %    .  5�   %   �� *	Destino+5�   %     5�      $ *
 6)    . $ 
Paqueteria��5�   %    .  5�   %   �� *
Paqueteria+5�   %   5�      ]� 5�      $��1��6   .+�5�      �� $��Detalle��6   $	��Top=�6*   $��Center=�6?   $��2q�6c     5�      $��1��5�   !   $��5,0,5,5q�5�   "    .  
������� .   . ��5�   "   �� *MovInventarioDetalle+ .  5�        5�      $ *
 6)    . $ Producto��5�   %    .  5�   %   �� *
Producto+5�   %     5     $	 100
 6)    . $ Cantidad��5  %    .  5  %   �� *CantidadDisponible+5  %     5     $
 auto
 6)    . $ 	Pedimento��5  %    .  5	  %   �� *	Pedimento+5  %   5     5     5     5     5     