   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   )    #SGI.View.Catalogos.CatalogModelView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Catálogo Modelo��5   	   $	��600��5   	   $	��700��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ Normal=�5   	    � 	Resources 5       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��85 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5!   
   $��1��6   $��0��5"      $��5,10,5,2q�5#      $
��Auto=�5$      .��5%      ��  �� Orientation$ Vertical=�6   y�60   �� *IsModeSearch+.+�5&      �� $ 
Horizontal=�6   .+�5(      �� $��Nombre:��6   �� 5)      $��1��6   $	��300��5*       �� 	MaxLength$	 100��5+      ��5,      �� *Model+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�50      �� 52      $��1��6   $��0��53      $��4��54      $��5 15 0 0q�55      ._�56      �� $ 
Horizontal=�6!   .+�57      �� $��40��6!   $��35��58   !   $��2q�59   !    � Cursor$
 Hand��5;   !    � ToolTip$ Guardar Cambios��5<   !   ��5:   !   �� *Accept+��5=      �� 5>   "   $%��/Resources/Images/imgSave32.png��6(   $
��Fill=�6Q   5@      �� 5A      $��40��6!   $��35��5B   !   $��2q�5C   !   $ Eliminar Elemento��5G   !   ��5D   !   �� *
DeleteItem+��5E   !   �� *Id+{�5F   !   �� *ModoEdicion+��5H      �� 5I   "   $'��!/Resources/Images/imgDelete32.png��6(   $
��Fill=�6S   5K      �� 5L      $��40��6!   $��35��5M   !   $��2q�5N   !   $ Nuevo��5P   !   ��5O   !   �� *Clean+��5Q      �� 5R   "   $#��/Resources/Images/Clean32.png��6(   $
��Fill=�6O   5T      �� 5V      $��40��6!   $��35��5W   !   $��2q�5X   !   $ Exportar a Excel��5Z   !   ��5Y   !   �� *ExportarCmd+��5[      �� 5\   "   $"��/Resources/Images/Excel3.png��6(   $
��Fill=�6N   5^      5`      5a      5c      5d      �� 5f   
   $��2��6   $��0��5g      $��7��5h      $��1 3 1 1q�5i      $��Stretch=�5j      
�������5k      �� 5m   
   $��3��6   $��0��5n      $��2,5,2,2q�5o      $ Vertical=�5p      .+�5q      �� $ 
Horizontal=�6   .+�5r      �� $��Buscar:��6   �� 5s      $��3��6   $��1��5t      $	��300��5u      $��5,2,5,2q�5v      $	 100��5w      ��5x      �� *ModelSearch+$
 PropertyChanged=�5z      �� 5{      $��7 5 0 0q�6   $ 
Horizontal=�6*   .+�5|      �� -   5        $��
btnRefresh��5|      $	��100��5}      $��35��5~      $��	Refrescar��5�      ��5      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ 
dgFamilies��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��5,20,5,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *	ModelList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Nombre��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *Model+5�   %   5�      5�      5�      