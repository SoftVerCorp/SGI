   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   ,    &SGI.View.Catalogos.CatalogoPaqueterias   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      #mvvmclr-namespace:SGI.Stuffs  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
     � Title$  Catalogo de Paqueterias��5      $	��800��6-   $	��688��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��115 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5   
   $��1��6   $��0��5       $��5,10,5,2q�5!      $
��Auto=�5"      .��5#      ��  �� Orientation$ Vertical=�6   y�60   �� *IsModeSearch+.+�5$      �� $ 
Horizontal=�6   .+�5&      �� $��Nombre:��6   �� 5'      $��1��6   $	��300��5(       �� 	MaxLength$	 100��5)      ��5*      �� *Nombre+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5.      $��Dirección:��6   �� 5/      $��1��6   $	��300��50      $	 100��51      ��52      �� *	Direccion+$ TwoWay=�$ PropertyChanged=�56      �� 58      $��5 15 0 0q�6   ._�59      �� $ 
Horizontal=�6!   .+�5:      �� $��40��6!   $��35��5;   !   $��2q�5<   !    � Cursor$
 Hand��5>   !    � ToolTip$ Guardar Cambios��5?   !   ��5=   !   �� *InsertarPaqueteriaCmd+��5@      �� 5A   "   $%��/Resources/Images/imgSave32.png��6(   $
��Fill=�6Q   5C      �� 5D      $��40��6!   $��35��5E   !   $��2q�5F   !   $ Eliminar Elemento��5H   !   ��5G   !   �� *EliminarPaqueteriaCmd+��5I      �� 5J   "   $'��!/Resources/Images/imgDelete32.png��6(   $
��Fill=�6S   5L      �� 5M      $��40��6!   $��35��5N   !   $��2q�5O   !   $ Nuevo��5Q   !   ��5P   !   �� *Clean+��5R      �� 5S   "   $#��/Resources/Images/Clean32.png��6(   $
��Fill=�6O   5U      �� 5W      $��40��6!   $��35��5X   !   $��2q�5Y   !   $ Exportar a Excel��5[   !   ��5Z   !   �� *ExportarCmd+��5\      �� 5]   "   $"��/Resources/Images/Excel3.png��6(   $
��Fill=�6N   5_      5a      5b      5c      5d      �� 5e   
   $��2��6   $��0��5f      $��7��5g      $��1 3 1 1q�5h      $��Stretch=�5i      
�������5j      �� 5l   
   $��3��6   $��0��5m      $��2,2,2,2q�5n      $ Vertical=�5o      .+�5p      �� $��3��6   $��Buscar por:��6!   �� 5r      $ 
Horizontal=�6   .+�5s      �� $��Nombre:��6   �� 5t      $��3��6   $��1��5u      $	��300��5v      $��5,2,5,2q�5w      $ 50��5x      ��5y      �� *FiltroNombre+$ PropertyChanged=��� 5|      $��Dirección:��6   �� 5}      $��1��6   $	��300��5~      $��5,2,5,2q�5      $ 20��5�      ��5�      �� *FiltroDireccion+$ PropertyChanged=�5�      �� 5�      $��7 5 0 5q�6   $ 
Horizontal=�6*   .+�5�      �� -   5        $��
btnRefresh��5�      $	��100��5�      $��35��5�      $��	Refrescar��5�      ��5�      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5        	  Name$	 dgColor��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid
   AutoGenerateColumns
 .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *Paqueterias+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Color��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *Nombre+5�   %     5�      $
 0.5*	 6%    . $ Clave color��5�   %    .  5�   %   �� *	Direccion+5�   %   5�      5�      5�      