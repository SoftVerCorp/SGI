   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   *    $SGI.View.Catalogos.CatalogoColorView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Catálogo Color��5   	   $	��750��5   	   $	��700��5	   	    � WindowStartupLocation$ CenterScreen=�5
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
Horizontal=�6   .+�5(      �� $��Nombre:��6   �� 5)      $��1��6   $	��300��5*       �� 	MaxLength$ 50��5+      ��5,      �� *	ColorText+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 50      $��Clave:��6   �� 51      $��1��6   $	��300��52      $ 20��53      ��54      �� *
ClaveColor+$	 TwoWay=�$
 PropertyChanged=�58      �� 5:      $��5 15 0 0q�6   ._�5;      �� $ 
Horizontal=�6!   .+�5<      �� $��40��6!   $��35��5=   !   $��2q�5>   !    � Cursor$
 Hand��5@   !    � ToolTip$ Guardar Cambios��5A   !   ��5?   !   �� *Accept+��5B      �� 5C   "   $%��/Resources/Images/imgSave32.png��6(   $
��Fill=�6Q   5E      �� 5F      $��40��6!   $��35��5G   !   $��2q�5H   !   $ Eliminar Elemento��5L   !   ��5I   !   �� *
DeleteItem+��5J   !   �� *Id+{�5K   !   �� *ModoEdicion+��5M      �� 5N   "   $'��!/Resources/Images/imgDelete32.png��6(   $
��Fill=�6S   5P      �� 5Q      $��40��6!   $��35��5R   !   $��2q�5S   !   $ Nuevo��5U   !   ��5T   !   �� *Clean+��5V      �� 5W   "   $#��/Resources/Images/Clean32.png��6(   $
��Fill=�6O   5Y      �� 5Z      $��40��6!   $��35��5[   !   $��2q�5\   !   $ Exportar a Excel��5^   !   ��5]   !   �� *ExportarCmd+��5_      �� 5`   "   $"��/Resources/Images/Excel3.png��6(   $
��Fill=�6N   5b      5c      5d      5e      5f      �� 5g   
   $��2��6   $��0��5h      $��7��5i      $��1 3 1 1q�5j      $��Stretch=�5k      
�������5l      �� 5n   
   $��3��6   $��0��5o      $��2,2,2,2q�5p      $ Vertical=�5q      .+�5r      �� $��3��6   $��Buscar por:��6!   �� 5t      $ 
Horizontal=�6   .+�5u      �� $��Nombre:��6   �� 5v      $��3��6   $��1��5w      $	��300��5x      $��5,2,5,2q�5y      $ 50��5z      ��5{      �� *ColorSearch+$
 PropertyChanged=��� 5~      $��Clave:��6   �� 5      $��1��6   $	��300��5�      $��5,2,5,2q�5�      $ 20��5�      ��5�      �� *ClaveColorSearch+$
 PropertyChanged=�5�      �� 5�      $��7 5 0 5q�6   $ 
Horizontal=�6*   .+�5�      �� -   5        $��
btnRefresh��5�      $	��100��5�      $��35��5�      $��	Refrescar��5�      ��5�      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ dgColor��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *	ColorList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Color��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *ColorString+5�   %     5�      $
 0.5*	 6%    . $ Clave color��5�   %    .  5�   %   �� *
ClaveColor+5�   %   5�      5�      5�      