   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   )    #SGI.View.OrdenesDeCompraVisorRecibe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Ordenes De Compra��5   	   $
��1100��5   	   $	��700��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      ]� .+�56   
   �� $��2q�6   $	��Top=�57      $��14(�58      $"��Información Orden de Compra��59      .��5:      �  � ColumnDefinitions 5;      �� 5<      $
��auto �6'   �� 5=      $
��auto �6'   �� 5>      $
��auto �6'   �� 5?      �� 5@      $
��auto �6'   �� 5A       � RowDefinitions 5C      �� 5D      �� 5E      �� 5F      �� 5G      .+�5J      �� $��0��6   $��0��5K      $��	Número: ��5L      �� 5M      $��0��6   $��1��5N      $	��150��5O       �� 
IsReadOnly . ��5Q      �� *Number+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5U      $��0��6   $��2��5V      $��Fecha de emisión: ��5W      (  "System.Windows.Controls.DatePicker  5X      $��0��6   $��3��5Y      {�.     styleDatePicker#��[  5^         SelectedDate 5[      �� *
DateOutPut+$ TwoWay=�$ PropertyChanged=�5^      �� 5`      $��0��6   $��4��5a      $��Fecha de entrega: ��5b        5c      $��0��6   $��5��5d      {�.  #��[  5i       5f      �� *DateDeliver+$ TwoWay=�$ PropertyChanged=�5i      �� 5k      $��1��6   $��0��5l      $��Condición de pago: ��5m      �� 5o      $��1��6   $��1��5p      $	��150��5q       . ��5s      �� *SelectedTypePay+$ TwoWay=�$ PropertyChanged=��� 5w      $��1��6   $��2��5x      $��Dias: ��5y      �� 5z      $��1��6   $��3��5{      $
��Left=�5|       . ��5      �� *Days+$ TwoWay=�$ PropertyChanged=��� 5�      $��1��6   $��4��5�      $��	Estatus: ��5�      �� 5�      $��1��6   $��5��5�      $
��Left=�5�       . ��5�      �� *	EstatusOC+$ TwoWay=�$ PropertyChanged=��� 5�      $��2��6   $��0��5�      $��Usuario Recibe: ��5�      �� 5�      $��2��6   {�.  $��1��5�      $��1��5�      $��30��5�      $��0q�5�       �� DisplayMemberPath$
 Name��5�      ��5�      �� *	Empleados+	 �� SelectedItem	 5�      �� *EmpleadoSeleccionado+�� 5�      $��2��6   $��2��5�      $��Ubicación : ��5�      �� 5�      $��2��6   {�.  $��3��5�      $��30��5�      $ Nombre��5�      
 �� 
IsReadOnly
 .  �� SelectedValuePath$ Id��5�      ��5�      �� *Ubicaciones+	 5�      �� *UbicacionSel+5�      �� 5�      $��2��6   $��4��5�      $��Pedimento : ��5�      �� 5�      $��2��6   $��5��5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *	Pedimento+$ TwoWay=�$ PropertyChanged=��� 5�      $��3��6   $��0��5�      $��Nombre: ��5�      �� 5�      $��3��6   $��1��5�      $��3��5�       . ��5�      �� *SupplierName+$ TwoWay=�$ PropertyChanged=��� 5�      $��3��6   $��4��5�      $��2��5�      $
��Auto��5�      $��2q�5�      $��Right=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� $	��140��6   $��30��5�      $	��5,0q�5�      $��Right=�5�      $��Center=�5�      $��Adjuntar archivos��5�      $��14(�5�      $
��Bold"�5�        NuclearBlueButton#��[ 5�      ��5�      �� *AdjuntarCommand+5�      �� 5�      -   5        $��btnAutorizar��5�      $	��120��5�      $��30��5�      $��0 0 2 0q�5�      $��Right=�5�      $��Center=�5�      $��Recibir orden��5�      $��14(�5�      $
��Bold"�5�        NuclearGreenButton#��[ 5�      ��5�      �� *Accept+5�      5�      5�      5�      �� 5  
   $��Center=�6   $��Bottom=�68   .@�5     �� .��5     �� $	��350��6   $��13(�5     $��SemiBold"�5     $w��q*Clic para editar la cantidad recibida y precio unitario. *Doble clic para agregar numeros de serie y comentario.��5     $
��Wrap=�5     5     �� 5
     $��Right=�6   .��5     �� $��2,5,5,2q�6   $��Right=�5     $ 
Horizontal=�5     .+�5     �� $��Total General: ��6   �� 5     $	��175��6   $��Center=�5     $��15(�5     $
��Bold"�5      . ��5     �� *TotalGeneral+$ TwoWay=�$ PropertyChanged=�5     5     5     &   System.Windows.Controls.DataGrid  5  
   -   5          Name$ dgOrderBuyDetail��5     $	��350��5     $��2,5,2,5q�5        AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows .    FrozenColumnCount$ 4��5#     ��5$     �� *DetailOrderList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5&     /  )System.Windows.Interactivity.EventTrigger  5'        	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5(        SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5)        Columns 5,     0  *System.Windows.Controls.DataGridTextColumn  5.     ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 100	 6%      CanUserResize .    Header$ Linea��51  %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5/  %   �� *Line+52  %     54     $	 200	 6%    . $ Clave TeknoBike��57  %    .  55  %   �� *CveTecnobike+58  %     5:     $
 Auto	 6%    . $ Clave Proveedor��5=  %    .  5;  %   �� *CveProveedor+5>  %     5A     $	 300	 6%    . $ Nombre��5D  %    .  5B  %   �� *Nombre+5E  %   4  .System.Windows.Controls.DataGridTemplateColumn  5G     $
 Auto	 6)    . $ Cantidad��5I  )    .     CellTemplate 5L     �� 5M     .R�5N     �� $��1,1,4,1q�6(   $
��Left=�5O  (   ��5P  (   �� *
Recibido+5Q         CellEditingTemplate  5S     �� 5T     .R�5U     �� $��1,1,1,1q�6&   ��67   �� *
Recibido+$ PropertyChanged=�.��6v    5V  "     5W  &   $ Loaded��65   . 5X  *   8   2SGI.Stuffs.TakeFocusAndSelectTextOnVisibleBehavior  5Y  '   .��5Z  :   5[     5\     !   	CellStyle! 5^     �� 5_     " �� 
TargetType*  $System.Windows.Controls.DataGridCell""  6    .�5`     �� # �� Property# �@ 	IsEditing$ �� Value$ . 6:   % �� Triggers% 5a     P� 5b  "   & P� Property& �@ 
IsSelected' P� Value' . . �5c  &   �� # � ��$ �#ff99006C   �� 5d  &   # � ��
$ �   �6C   �� 5e  &   # � ��
$ ���� 6D   �� 5f  &   # � ��$$ 0q�6H   5g  #   5j     5l       5q     $
 Auto	 6)    . $ Precio unit.��5s  )    .   5v     �� 5w     .R�5x     �� $��1,1,4,1q�6(   $
��Left=�5y  (   ��5z  (   �� *	UnitPrice+5{       5}     �� 5~     .R�5     �� $��1,1,1,1q�6&   ��67   �� *	UnitPrice+$ PropertyChanged=�.��6w    5�  "     5�  &   $ Loaded��65   . 5�  *     5�  '   .��5�  :   5�     5�     ! 5�     �� 5�     ""  6    .�5�     �� # �@ 	IsEditing$ . 6:   % 5�     P� 5�  "   & �@ 
IsSelected' . . �5�  &   �� # � ��$ �#ff99006C   �� 5�  &   # � ��
$ �   �6C   �� 5�  &   # � ��
$ ���� 6D   �� 5�  &   # � ��$$ 0q�6H   5�  #   5�     5�       5�     $
 auto	 6%    . $ Total��5�  %    .  5�  %   �� *
TotalCal+5�  %   5�     5�     5�     