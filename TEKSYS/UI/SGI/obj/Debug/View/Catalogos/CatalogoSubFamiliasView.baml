   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   0    *SGI.View.Catalogos.CatalogoSubFamiliasView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Catálogo SubFamilias��5   	   $
��1130��5   	   $	��700��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ Normal=�5   	    � 	Resources 5       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $��1* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $	��100 �6    �� 5      $
��Auto �6    �� 5      $	��115 �6    �� 5      $��* �6    .+�5      �� $��0��6   $��0��5      $��7��5      
�������5      �� 5!      $��1��6   $��0��5"      $��5,10,5,2q�5#      $
��Auto=�5$      .��5%      ��  �� Orientation$ Vertical=�6   .+�5&      �� $ 
Horizontal=�6!   .+�5(      �� $��Familia:��6    �� 5)      -   5        $��
cbFamilias��5)   #   $	��300��5*   #   $��30��5+   #   $��5,2,5,2q�5,   #   $
��Left=�5-   #   $��Center=�5.   #    �� DisplayMemberPath$ 
FamilyName��5/   #   	 �� SelectedValuePath$	 Id��54   #   ��50   #   �� *
FamilyList+
 �� Mode$
 TwoWay=� �� SelectedValue 52   #   �� *SelectedFamilia+$
 TwoWay=�54   #   �� 56      $��Nombre:��6    �� 57      $��1��6"   $	��300��58   "   $��5,2,5,2q�59   "    �� 	MaxLength$ 50��5:   "   ��5;   "   �� *SubFamiliaName+$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5?      $
��URL:��6    �� 5@      $	��300��6"   $��5,2,5,2q�5A   "   $ 50��5B   "   ��5C   "   �� *Url+$
 TwoWay=�$ PropertyChanged=�5G      �� 5I      $��5 15 0 0q�6   ._�5J      �� $ 
Horizontal=�6%   .+�5K      �� $��40��6%   $��35��5L   %   $��2q�5M   %    � Cursor$
 Hand��5O   %    � ToolTip$ Guardar Cambios��5P   %   ��5N   %   �� *Accept+��5Q   "   �� 5R   &   $%��/Resources/Images/imgSave32.png��6,   $
��Fill=�6U   5T      �� 5V      $��40��6%   $��35��5W   %   $��2q�5X   %   $ Eliminar Elemento��5\   %   ��5Y   %   �� *
DeleteItem+��5Z   %   �� *Id+{�5[   %   �� *ModoEdicion+��5]   "   �� 5^   &   $'��!/Resources/Images/imgDelete32.png��6,   $
��Fill=�6W   5`      �� 5a      $��40��6%   $��35��5b   %   $��2q�5c   %   $ Nuevo��5e   %   ��5d   %   �� *Clean+��5f   "   �� 5g   &   $#��/Resources/Images/Clean32.png��6,   $
��Fill=�6S   5i      �� 5k      $��40��6%   $��35��5l   !   $��2q�5m   !   $ Exportar a Excel��5o   !   ��5n   !   �� *ExportarCmd+��5p   "   �� 5q   &   $"��/Resources/Images/Excel3.png��6,   $
��Fill=�6R   5s      5u      5v      5w      5y      �� 5{      $��2��6   $��0��5|      $��7��5}      $��1 3 1 1q�5~      $��Stretch=�5      
�������5�      �� 5�      $��3��6   $��0��5�      $��2,2,2,2q�5�      $ Vertical=�5�      .+�5�      �� $��Buscar:��6   �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Familia:��6   �� 5�      $��1��6   $	��300��5�      $��5,2,5,2q�5�      $ 50��5�      ��5�      �� *FamilySearch+$ PropertyChanged=��� 5�      $��Nombre:��6   �� 5�      $��1��6   $	��300��5�      $��5,2,5,2q�5�      $ 50��5�      ��5�      �� *SubFamilySearch+$ PropertyChanged=�5�      �� 5�      $��7 5 0 0q�6   $ 
Horizontal=�6.   .+�5�      �� -   5        $��
btnRefresh��5�      $	��100��5�      $��35��5�      $��	Refrescar��5�      ��5�      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�      -   5          Name$ 
dgFamilies��5�   &   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *SubFamilyList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6.   �� *SelectedITemGridClick+   CommandParameter 6X   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6)      CanUserResize .    Header$ Familia��5�   )      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn  
  Binding  5�   )   �� *
FamilyName+5�   )     5�      $
 0.5*	 6)    . $ Nombre��5�   )    .   5�   )   �� *SubFamilyName+5�   )     5�      $
 0.5*	 6)    . $	 Url��5�   )    .   5�   )   �� *Url+5�   )   5�      5�      5�      5�      