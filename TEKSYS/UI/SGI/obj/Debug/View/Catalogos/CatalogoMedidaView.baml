   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   +    %SGI.View.Catalogos.CatalogoMedidaView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Catálogo Medida��5   	   $	��750��5   	   $	��700��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ Normal=�5   	    � 	Resources 5       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��115 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5!   
   $��1��6   $��0��5"      $��5,10,5,2q�5#      $
��Auto=�5$      .��5%      ��  �� Orientation$ Vertical=�6   y�60   �� *IsModeSearch+.+�5&      �� $ 
Horizontal=�6   .+�5(      �� $��Nombre:��6   �� 5)      $��1��6   $	��300��5*       �� 	MaxLength$ 40��5+      ��5,      �� *
MedidaText+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 50      $��Clave:��6   �� 51      $��1��6   $	��300��52      $ 10��53      ��54      �� *ClaveMedida+$	 TwoWay=�$
 PropertyChanged=�58      �� 5:      $��1��6   $��0��5;      $��4��5<      $��5 15 0 0q�5=      ._�5>      �� $ 
Horizontal=�6!   .+�5?      �� $��40��6!   $��35��5@   !   $��2q�5A   !    � Cursor$
 Hand��5C   !    � ToolTip$ Guardar Cambios��5D   !   ��5B   !   �� *Accept+��5E      �� 5F   "   $%��/Resources/Images/imgSave32.png��6(   $
��Fill=�6Q   5H      �� 5I      $��40��6!   $��35��5J   !   $��2q�5K   !   $ Eliminar Elemento��5O   !   ��5L   !   �� *
DeleteItem+��5M   !   �� *Id+{�5N   !   �� *ModoEdicion+��5P      �� 5Q   "   $'��!/Resources/Images/imgDelete32.png��6(   $
��Fill=�6S   5S      �� 5T      $��40��6!   $��35��5U   !   $��2q�5V   !   $ Nuevo��5X   !   ��5W   !   �� *Clean+��5Y      �� 5Z   "   $#��/Resources/Images/Clean32.png��6(   $
��Fill=�6O   5\      �� 5^      $��40��6!   $��35��5_   !   $��2q�5`   !   $ Exportar a Excel��5b   !   ��5a   !   �� *ExportarCmd+��5c      �� 5d   "   $"��/Resources/Images/Excel3.png��6(   $
��Fill=�6N   5f      5h      5i      5j      5k      �� 5m   
   $��2��6   $��0��5n      $��7��5o      $��1 3 1 1q�5p      $��Stretch=�5q      
�������5r      �� 5v   
   $��3��6   $��0��5w      $��2,2,2,2q�5x      $ Vertical=�5y      .+�5z      �� $��Buscar por:��6   �� 5{      $ 
Horizontal=�6   .+�5|      �� $��Nombre:��6   �� 5}      $��1��6   $	��300��5~      $��5,2,5,2q�5      $ 40��5�      ��5�      �� *MedidaSearch+$
 PropertyChanged=��� 5�      $��Clave:��6   �� 5�      $��1��6   $	��300��5�      $��5,2,5,2q�5�      $ 10��5�      ��5�      �� *ClaveMedidaSearch+$
 PropertyChanged=�5�      �� 5�      $��7 5 0 0q�6   $ 
Horizontal=�6*   .+�5�      �� -   5        $��
btnRefresh��5�      $	��100��5�      $��35��5�      $��	Refrescar��5�      ��5�      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ 	dgMedidas��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��5,20,5,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *
MedidaList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Nombre��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *MedidaString+5�   %     5�      $
 0.5*	 6%    . $ Clave��5�   %    .  5�   %   �� *ClaveMedida+5�   %   5�      5�      5�      