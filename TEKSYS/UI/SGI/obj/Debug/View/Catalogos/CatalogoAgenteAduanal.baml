   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   .    (SGI.View.Catalogos.CatalogoAgenteAduanal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	     � Title$  Agentes Aduanales��5   	   $	��800��6%   $	��688��5   	   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��115 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5   
   $��1��6   $��0��5      $��5,10,5,2q�5      $
��Auto=�5      .��5      ��  �� Orientation$ Vertical=�6   y�60   �� *IsModeSearch+.+�5       �� $ 
Horizontal=�6   .+�5"      �� $��Nombre:��6   �� 5#      $��1��6   $	��300��5$       �� 	MaxLength$	 100��5%      ��5&      �� *Nombre+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5*      $��Dirección:��6   �� 5+      $��1��6   $	��300��5,      $	 100��5-      ��5.      �� *	Direccion+$ TwoWay=�$ PropertyChanged=�52      �� 54      $��5 15 0 0q�6   ._�55      �� $ 
Horizontal=�6!   .+�56      �� $��40��6!   $��35��57   !   $��2q�58   !    � Cursor$
 Hand��5:   !    � ToolTip$ Guardar Cambios��5;   !   ��59   !   �� *InsertarAgenteCmd+��5<      �� 5=   "   $%��/Resources/Images/imgSave32.png��6(   $
��Fill=�6Q   5?      �� 5@      $��40��6!   $��35��5A   !   $��2q�5B   !   $ Eliminar Elemento��5D   !   ��5C   !   �� *EliminarAgenteCmd+��5E      �� 5F   "   $'��!/Resources/Images/imgDelete32.png��6(   $
��Fill=�6S   5H      �� 5I      $��40��6!   $��35��5J   !   $��2q�5K   !   $ Nuevo��5M   !   ��5L   !   �� *Clean+��5N      �� 5O   "   $#��/Resources/Images/Clean32.png��6(   $
��Fill=�6O   5Q      �� 5S      $��40��6!   $��35��5T   !   $��2q�5U   !   $ Exportar a Excel��5W   !   ��5V   !   �� *ExportarCmd+��5X      �� 5Y   "   $"��/Resources/Images/Excel3.png��6(   $
��Fill=�6N   5[      5]      5^      5_      5`      �� 5a   
   $��2��6   $��0��5b      $��7��5c      $��1 3 1 1q�5d      $��Stretch=�5e      
�������5f      �� 5h   
   $��3��6   $��0��5i      $��2,2,2,2q�5j      $ Vertical=�5k      .+�5l      �� $��3��6   $��Buscar por:��6!   �� 5n      $ 
Horizontal=�6   .+�5o      �� $��Nombre:��6   �� 5p      $��3��6   $��1��5q      $	��300��5r      $��5,2,5,2q�5s      $ 50��5t      ��5u      �� *FiltroNombre+$ PropertyChanged=��� 5x      $��Dirección:��6   �� 5y      $��1��6   $	��300��5z      $��5,2,5,2q�5{      $ 20��5|      ��5}      �� *FiltroDireccion+$ PropertyChanged=�5      �� 5�      $��7 5 0 5q�6   $ 
Horizontal=�6*   .+�5�      �� -   5        $��
btnRefresh��5�      $	��100��5�      $��35��5�      $��	Refrescar��5�      ��5�      �� *RefreshSearch+5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5        	  Name$	 	dgAgentes��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid
   AutoGenerateColumns
 .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *	Agentes+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Nombre��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *Nombre+5�   %     5�      $
 0.5*	 6%    . $ 	Direccion��5�   %    .  5�   %   �� *	Direccion+5�   %   5�      5�      5�      