   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   %    SGI.View.OC.GastosDeImportacion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   	   -   5          �Name$  gtsImportacion��5   >    � Title$ GastosDeImportacion��6	   $	��600��6%   $	��800��62   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5   
   $��1��6   $��0��5      $��5,10,5,2q�5      $
��Auto=�5      .��5       �� $��Gastos de Importación��6   .��5!      ��  �� Orientation$ Vertical=�6   .+�5"      � $	��120��6    5#      �� 5$      $
��auto �6/   �� 5%      $
��auto �6/   �� 5&      $
��auto �60   �� 5'       5)      �� 5*      �� 5+      �� 5,      .+�5.      �� $��Agente Aduanal:��6    $��0��6:   $��0��6G   �� 5/      $��5,0,0,0q�6#   $��1��64   $��0��6D   $	��200��6R   $��35��6^    �� DisplayMemberPath$ Nombre��50   #    �� SelectedValuePath$ Id��6>   ��5/   j   �� *	Agentes+ �� SelectedValue 50   U   �� *AgenteSeleccionado+�� 52      $��Numero de cuenta:��6    $��0��6<   $��2��6I   �� 53      $��0��54      $��3��6*   $	��200��6:   $
��Left=�6F   $��5,0,0,0q�6a   ��53   #   �� *
NoCuenta+54   a   �� 56      $��Orden de Compra:��6    $��1��6;   $��0��6H   �� 57      $��1��6"   $��1��6/    �� 
IsReadOnly . $	��200��6Q   $
��Left=�58   "   $��5,0,0,0q�6=   ��6N   �� *OrdenDeCompra+�� 5:      $��Fecha:��6    $��1��61   $��2��6>   (  "System.Windows.Controls.DatePicker  5;      $��1��6D   $��3��6Q      styleDatePicker#��[  6a   	   SelectedDate	 6%   �� *Fecha+6a   �� 5=      $��Gasto de Import.:��6    $��2��6<   $��0��6I   �� 5>      $��1��6#   $��2��63   $��5,0,0,0q�6@   $	��200��6R   $��35��6^   $ Concepto��5?   #   $ Id��6@   ��5>   j   �� *	Conceptos+ 5?   W   �� *ConceptoSeleccionado+�� 5A      $	��100��6!   $��35��5B   !   $��2q�5C   !   
 � Cursor$

 Hand��5E   !   $��Añadir��6/   $��2��6@   $��2��6M   ��5D   !   �� *AgregarGastoImportacionCmd+5H      5U      �� 5W      $��5 15 0 0q�6   ._�5X      �� $ 
Horizontal=�6%   .+�5Y      �� $��40��6%   $��35��5Z   !   $��2q�5[   !   $

 Hand��5]   !    � ToolTip$ Guardar Cambios��5^   !   ��5\   !   �� *!AgregarNuevoGastoImportacionCmd+��5_   "   �� 5`   &   $%��/Resources/Images/imgSave32.png��6,   $
��Fill=�6U   5b      �� 5l      $��40��6%   $��35��5m   !   $��2q�5n   !   $ Nuevo��5p   !   ��5o   !   �� *Clean+��5q   "   �� 5r   &   $#��/Resources/Images/Clean32.png��6,   $
��Fill=�6S   5t      5u      5v      5w      5x      5y      �� 5z   
   $��2��6   $��0��5{      $��7��5|      $��1 3 1 1q�5}      $��Stretch=�5~      
�������5      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ 	dgAgentes��5�   "   $��3��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *GastosDetalle+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 6%    	  CanUserResize .  	  Header$ Concepto��5�   %    	  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   %   �� *
Concepto+5�   %   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $
 0.5*
 6)    . $ Costo Est. ��5�   1    .     CellTemplate 5�      �� 5�      .R�5�      �� $��1,1,4,1q�6&   $��Center=�5�   /   $��Center=�6S   ��5�   0   �� *CostoEstimado+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�          CellEditingTemplate  5�      �� 5�      .R�5�      �� $��1,1,1,1q�6&   $��Center=�69   $��Center=�6]   ��5�   &   �� *CostoEstimado+$ PropertyChanged=�$ TwoWay=�.��6v    5�   "     5�   &   $ Loaded��65   . 5�   *   8   2SGI.Stuffs.TakeFocusAndSelectTextOnVisibleBehavior  5�   '   .��5�   :   5�      5�      ! 	  	CellStyle! 5�      �� 5�      " �� 
TargetType*  $System.Windows.Controls.DataGridCell""  6    .�5�      �� # �� Property# �@ 	IsEditing$ �� Value$ . 6:   % �� Triggers% 5�      P� 5�   "   & P� Property& �@ 
IsSelected' P� Value' . . �5�   &   �� # � ��$ �#ff99006C   �� 5�   &   # � ��
$ �   �6C   �� 5�   &   # � ��
$ ���� 6D   �� 5�   &   # � ��$$ 0q�6H   5�   #   5�      5�        5�      $ *
 6)   $ Fecha Costo Estimado��63    5�      �� 5�      .R�5�        #���   6)   	 6S   �� *FechaCostoEstimado+$ TwoWay=�$ PropertyChanged=�5�      5�        5�      $
 0.5*
 6)    . $ Costo Real ��5�   1    .   5�      �� 5�      .R�5�      �� $��1,1,4,1q�6&   $��Center=�5�   /   $��Center=�6S   ��5�   0   �� *	CostoReal+$ TwoWay=�$ PropertyChanged=�5�        5�      �� 5�      .R�5�      �� $��1,1,1,1q�6&   $��Center=�69   $��Center=�6]   ��5�   &   �� *	CostoReal+$ PropertyChanged=�$ TwoWay=�.��6r    5�   "     5�   &   $ Loaded��65   . 5�   *     5�   '   .��5�   :   5�      5�      ! 5�      �� 5�      ""  6    .�5�      �� # �@ 	IsEditing$ . 6:   % 5�      P� 5�   "   & �@ 
IsSelected' . . �5�   &   �� # � ��$ �#ff99006C   �� 5�   &   # � ��
$ �   �6C   �� 5�   &   # � ��
$ ���� 6D   �� 5�   &   # � ��$$ 0q�6H   5�   #   5�      5�        5�      $ *
 6)   $ Fecha Costo Real��63    5�      �� 5�      .R�5�        #���   6)   	 6S   �� *FechaCostoReal+$ TwoWay=�$ PropertyChanged=�5�      5�        5     $
 0.5*
 6)    5     �� 5     .R�5     �� ��6%   �� ( �� ElementName$( gtsImportacion��) �� Path$-) 'DataContext.EliminarGastoImportacionCmd���5  %   �� .��5  "   �� $��25��6(   $��30��63   $'��!/Resources/Images/imgDelete32.png��6?   $
��Fill=�6j   5     5     5
     5     5     5     