   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   .    (SGI.View.Catalogos.CatalogoTipoDeCliente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46wpfext)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
     � Title$"  Catalogo de Tipo de Clientes��5      $	��600��62   $	��688��5	   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��115 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5   
   $��1��6   $��0��5      $��5,10,5,2q�5      $
��Auto=�5       .��5!      ��  �� Orientation$ Vertical=�6   .+�5"      �� $ 
Horizontal=�6   .+�5$      �� $��Nombre:��6   �� 5%      $��1��6   $	��300��5&       �� 	MaxLength$	 100��5'      ��5(      �� *TipoCliente+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5,      $��Descuento %:��6   $  Xceed.Wpf.Toolkit.DoubleUpDown  5-      $��1��6*   $	��100��5.      $��14(�6*   $
��Bold"�68   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ F1��6J      	Increment$ 1X�6\   $��Center=�6j   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]	   Minimum$	 0X�5/      
   Maximum$	
 100X�6*   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ Introduce el %��68      Value 50      �� *	Descuento+$ TwoWay=�$ PropertyChanged=�54      �� 56      $��5 15 0 0q�6   ._�57      �� $ 
Horizontal=�6!   .+�58      �� $��40��6!   $��35��59   !   $��2q�5:   !    � Cursor$
 Hand��5<   !    � ToolTip$ Guardar Cambios��5=   !   ��5;   !   �� *InsertarTipoClienteCmd+��5>      �� 5?   "   $%��/Resources/Images/imgSave32.png��6(   $
��Fill=�6Q   5A      �� 5B      $��40��6!   $��35��5C   !   $��2q�5D   !   $ Eliminar Elemento��5F   !   ��5E   !   �� *EliminarTipoDeClienteCmd+��5G      �� 5H   "   $'��!/Resources/Images/imgDelete32.png��6(   $
��Fill=�6S   5J      �� 5K      $��40��6!   $��35��5L   !   $��2q�5M   !   $ Nuevo��5O   !   ��5N   !   �� *Clean+��5P      �� 5Q   "   $#��/Resources/Images/Clean32.png��6(   $
��Fill=�6O   5S      �� 5T      $��40��6!   $��35��5U   !   $��2q�5V   !   $ Exportar a Excel��5X   !   ��5W   !   �� *ExportarCmd+��5Y      �� 5Z   "   $"��/Resources/Images/Excel3.png��6(   $
��Fill=�6N   5\      5]      5^      5_      5`      �� 5a   
   $��2��6   $��0��5b      $��7��5c      $��1 3 1 1q�5d      $��Stretch=�5e      
�������5f      �� 5h   
   $��3��6   $��0��5i      $��2,2,2,2q�5j      $ Vertical=�5k      .+�5l      �� $��3��6   $��Buscar por:��6!   �� 5n      $ 
Horizontal=�6   .+�5o      �� $��Tipo de Cliente:��6   �� 5p      $��3��6   $��1��5q      $	��300��5r      $��5,2,5,2q�5s      $ 50��5t      ��5u      �� *TipoClienteFiltro+$ PropertyChanged=�5      �� 5�      $��7 5 0 5q�6   $ 
Horizontal=�6*   .+�5�      �� -   5        $��
btnRefresh��5�      $	��100��5�      $��35��5�      $��	Refrescar��5�      ��5�      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ dgColor��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *TipoDeClientes+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5�      
   SGI.Stuffs.EventToCommand
   
  Command 6*   �� *SelectedITemGridClick+ 
  CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.7* 6%      CanUserResize .    Header$ Tipo de cliente��5�   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   %   �� *TipoClientes+5�   %     5�      $
 0.3* 6%    . $ Descuento %��5�   %    .  5�   %   �� *
Descuentos+5�   %   5�      5�      5�      