   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   *    $SGI.View.OrdenesDeCompraAutorizacion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � WindowStartupLocation$  CenterScreen=�6/    � Title$ OrdenesDeCompra��5   	   $
��1050��5   	   $	��800��5   	   .��5
      ]� .+�56   
   �� $	��190��6   $��2q�57      $	��Top=�58      $��14(�59      $"��Información Orden de Compra��5:      .��5;      �  � ColumnDefinitions 5<      �� 5=      $
��auto �6'   �� 5>      $��* �6'   �� 5?      $
��auto �6'   �� 5@      �� 5A      $
��auto �6'   �� 5B       � RowDefinitions 5D      �� 5E      �� 5F      �� 5G      �� 5H      .+�5K      �� $��0��6   $��0��5L      $��	Número: ��5M      �� 5N      $��0��6   $��1��5O       �� 
IsReadOnly . ��5Q      �� *Number+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5U      $��0��6   $��2��5V      $��Fecha de emisión: ��5W      �� 5Y      $��0��6   $��3��5Z       . ��5\      �� *
DateOutPut+$ TwoWay=�$ PropertyChanged=��� 5h      $��0��6   $��4��5i      $��Fecha de entrega: ��5j      �� 5r      $��0��6   $��5��5s       . ��5u      �� *DateDeliver+$ TwoWay=�$ PropertyChanged=��� 5y      $��1��6   $��0��5z      $��Condición de pago: ��5{      �� 5}      $��1��6   $��1��5~       . ��5�      �� *SelectedTypePay+$ TwoWay=�$ PropertyChanged=��� 5�      $��1��6   $��2��5�      $��Dias: ��5�      �� 5�      $��1��6   $��3��5�       . ��5�      �� *Days+$ TwoWay=�$ PropertyChanged=��� 5�      $��1��6   $��4��5�      $��	Estatus: ��5�      �� 5�      $��1��6   $��5��5�       . ��5�      �� *	EstatusOC+$ TwoWay=�$ PropertyChanged=��� 5�      $��2��6   $��0��5�      $��Proveedor: ��5�      �� 5�      $��2��6   $��1��5�       . ��5�      �� *SupplierName+$ TwoWay=�$ PropertyChanged=��� 5�      $��2��6   $��2��5�      $��Usuario Recibe: ��5�      �� 5�      $��2��6   $��3��5�      $��1��5�      $��30��5�      $��0q�5�       �� DisplayMemberPath$
 Name��5�      ��5�      �� *	Empleados+ �� SelectedItem 5�      �� *EmpleadoSeleccionado+�� 5�      $��3��6   $��0��5�      $��2��5�      $
��Auto��5�      $��5,10,5,2q�5�      $
��Left=�5�      	 �� Orientation$	 
Horizontal=�5�      .+�5�      �� -   5        $��
btnRecibir��5�      $	��120��5�      $��0,1,2,0q�5�      $��Right=�5�      $��Recibir��5�      ��5�      �� *Accept+5�      5�      5�      5�      �� 5�   
   $��Center=�6   $��Bottom=�68   .@�5�      �� .��5�      �� $	��350��6   $��13(�5�      $��SemiBold"�5�      $w��q*Clic para editar la cantidad recibida y precio unitario. *Doble clic para agregar numeros de serie y comentario.��5�      $
��Wrap=�5�      5�      �� 5�      $��Right=�6   .��5�      �� $��2,5,5,2q�6   $��Right=�5�      $	 
Horizontal=�5�      .+�5�      �� $��Total General: ��6   �� 5�      $	��175��6   $
��Left=�5�       . ��5�      �� *TotalGeneral+$ TwoWay=�$ PropertyChanged=�5�      5�      5�      &   System.Windows.Controls.DataGrid  5�   
   -   5        
  Name$
 dgOrderBuyDetail��5�      $	��350��5�      $��2,5,2,5q�5�         AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *DetailOrderList+ �� IsAsync .    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6%      CanUserResize .    Header$ Linea��5�   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   %   �� *Line+5�   %     5�      $
 0.5* 6%    . $ Clave TeknoBike��5�   %    .  5�   %   �� *ClaveTeknoBike+5�   %     5�      $
 0.6* 6%    . $ Clave Proveedor ��5  %    .  5�   %   �� *ClaveProveedor+5  %     5     $
 0.5* 6%    . $ Descripción��5  %    .  5  %   �� *ProductDescription+5	  %     5     $
 0.5* 6%    . $ Cantidad��5  %    .  5  %   �� *
Quantity+5  %   4  .System.Windows.Controls.DataGridTemplateColumn  5     $
 0.5* 6)    . $ 	Entregado��5  )    .    CellTemplate 5     �� 5     .R�5     �� $��1,1,4,1q�6(   $
��Left=�5  (   ��5  (   �� *
Recibido+5        CellEditingTemplate 5      �� 5!     .R�5"     �� $��1,1,1,1q�6&   ��67   �� *RecibidoEditable+$ PropertyChanged=�.��6~   .  (System.Windows.Interactivity.Interaction   Triggers 5#  "   /  )System.Windows.Interactivity.EventTrigger  5$  &      	EventName$ Loaded��65   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5%  *   8
   2SGI.Stuffs.TakeFocusAndSelectTextOnVisibleBehavior
  5&  '   .��5'  :   5(     5)        	CellStyle 5+     �� 5,      �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5-     ��  �� Property �@ 	IsEditing �� Value . 6:    �� Triggers 5.     P� 5/  "    P� Property �@ 
IsSelected  P� Value  . . �50  &   ��  � �� �#ff99006C   �� 51  &    � ��
 �   �6C   �� 52  &    � ��
 ���� 6D   �� 53  &    � ��$ 0q�6H   54  #   5:     5<       5@     $
 0.5* 6%    . $ Precio unitario��5C  %    .  5A  %   �� *	UnitPrice+5D  %     5S     $
 0.5* 6%    . $ Total��5W  %    .  5T  %   �� *
TotalCal+$ PropertyChanged=�5X  %   5\     5_     5`     