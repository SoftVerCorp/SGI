   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   #    SGI.View.CargarExcelProductos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  CargarExcelProductos��5   	   $	��800��5   	   $	��500��5   	   .��5	      ]� .+�5   
   �� $��50��6   $��Bottom=�6    .@�5      �� $��Center=�6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��120��6   $��30��5      $
��10,5q�5      $��Cargar��5      ��5      �� *CargarExcel+5      �� 5      $	��120��6   $��30��5      $
��10,5q�5      $��Aceptar��5      ��5      �� *AceptarExcel+5      5      5      5      &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .     
IsReadOnly .  ��5      �� *Data+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6%      CanUserResize .    Header$ Cve Proveedor��5$   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5"   %   �� *CVEProveedor+5%   %     5'      $
 auto 6%    . $ Producto��5*   %    . 	 5(   %   �� *NombreProducto+5+   %     5-      $
 auto 6%    . $ Precio��50   %    . 	 5.   %   �� *Precio+51   %   4  .System.Windows.Controls.DataGridTemplateColumn  53      $
 0.5* 6)    . $ 	Cantidad ��55   )    .  
   CellTemplate
 58      �� 59      .R�5:      �� $��1,1,4,1q�6(   $
��Left=�5;   (   ��5<   (   �� *
Cantidad+5=         CellEditingTemplate 5?      �� 5@      .R�5A      �� $��1,1,1,1q�6&   ��67   �� *
Cantidad+ �� UpdateSourceTrigger$ PropertyChanged=�.��6v   .  (System.Windows.Interactivity.Interaction   Triggers 5B   "   /  )System.Windows.Interactivity.EventTrigger  5C   &      	EventName$ Loaded��65   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5D   *   8
   2SGI.Stuffs.TakeFocusAndSelectTextOnVisibleBehavior
  5E   '   .��5F   :   5G      5H         	CellStyle 5J      �� 5K       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5L      ��  �� Property �@ 	IsEditing �� Value . 6:    �� Triggers 5M      P� 5N   "    P� Property �@ 
IsSelected P� Value . . �5O   &   ��  � �� �#ff99006C   �� 5P   &    � ��
 �   �6C   �� 5Q   &    � ��
 ���� 6D   �� 5R   &    � ��$ 0q�6H   5S   #   5Y      5[      5]      5^      5_      