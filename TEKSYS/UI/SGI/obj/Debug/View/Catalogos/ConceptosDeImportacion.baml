   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   /    )SGI.View.Catalogos.ConceptosDeImportacion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	     � Title$  Conceptos de Importación��5   	   $	��600��6,   $	��500��5   	    � 	Resources 5	       �� Source�� 5
   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��115 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5   
   $��1��6   $��0��5      $��5,10,5,2q�5       $
��Auto=�5!      .��5"      �� $��	Conceptos��6   .��5#      ��  �� Orientation$ Vertical=�6   y�64   �� *IsModeSearch+.+�5$      �� $ 
Horizontal=�6!   .+�5&      �� $��	Concepto:��6    �� 5'      $��1��6"   $	��300��5(       �� 	MaxLength$	 100��5)      ��5*      �� *
Concepto+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�51      �� 53      $��5 15 0 0q�6   ._�54      �� $ 
Horizontal=�6%   .+�55      �� $��40��6%   $��35��56   !   $��2q�57   !   	 � Cursor$
	 Hand��59   !   
 � ToolTip$
 Guardar Cambios��5:   !   ��58   !   �� *InsertarConceptoCmd+��5;   "   �� 5<   &   $%��/Resources/Images/imgSave32.png��6,   $
��Fill=�6U   5>      �� 5?      $��40��6%   $��35��5@   !   $��2q�5A   !   $
 Eliminar Elemento��5C   !   ��5B   !   �� *EliminarConceptoCmd+��5D   "   �� 5E   &   $'��!/Resources/Images/imgDelete32.png��6,   $
��Fill=�6W   5G      �� 5H      $��40��6%   $��35��5I   !   $��2q�5J   !   $
 Nuevo��5L   !   ��5K   !   �� *Clean+��5M   "   �� 5N   &   $#��/Resources/Images/Clean32.png��6,   $
��Fill=�6S   5P      �� 5R      $��40��6%   $��35��5S   !   $��2q�5T   !   $
 Exportar a Excel��5V   !   ��5U   !   �� *ExportarCmd+��5W   "   �� 5X   &   $"��/Resources/Images/Excel3.png��6,   $
��Fill=�6R   5Z      5[      5\      5]      5^      5_      �� 5`   
   $��2��6   $��0��5a      $��7��5b      $��1 3 1 1q�5c      $��Stretch=�5d      
�������5e      �� 5g   
   $��Buscar por:��6   $��3��6(   $��0��5h      .��5i      �� $��2,2,2,2q�5j      $ Vertical=�5k      .+�5n      �� $ 
Horizontal=�6   .+�5o      �� $��Nombre:��6   �� 5p      $��3��6   $��1��5q      $	��300��5r      $��5,2,5,2q�5s      $ 50��5t      ��5u      �� *FiltroConcepto+$ PropertyChanged=�5y      �� 5z      $��7 5 0 5q�6   $ 
Horizontal=�6.   .+�5{      �� -   5        $��
btnRefresh��5{      $	��100��5|      $��35��5}      $��	Refrescar��5      ��5~      �� *RefreshSearch+5      5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ 	dgAgentes��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *	Conceptos+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6%      CanUserResize .    Header$ Nombre��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *
Concepto+5�   %   5�      5�      5�      