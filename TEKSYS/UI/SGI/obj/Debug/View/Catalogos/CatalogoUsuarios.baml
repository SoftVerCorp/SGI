   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   )    #SGI.View.Catalogos.CatalogoUsuarios   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   #mvvmclr-namespace:SGI.Stuffs  5   	   -   5          �Name$  wndUsers��5
   .    � Title$ Catalogo de Uusuarios��5   	   $	��900��5   	   $	��700��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ Normal=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ ContentRendered��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *ContentRendered+   CommandParameter 6H   �� 	 �� ElementName$	 wndUsers��5      
 � 	Resources
 5       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��80 �6   �� 5      $��* �6   .+�5!   
   �� $��0��6   $��0��5"      $��2q�5#      $��Informacion del Usuario��5$      .��5%      �  5&      �� 5'      �� 5(      $	��200 �6'   .+�5*      � $��0��6    5+      �� 5,      $
��auto �6+   �� 5-      �� 5.      $
��auto �6+   �� 5/      �� 50      $��20 �6+    52      �� 53      �� 54      �� 55      �� 56      �� 57      .+�5:      �� $��0��6   $��0��5;      $
��Left=�5<      $��Codigo:��5=      �� 5>      $��0��6   $��1��5?      $��30��5A      $��5,2,5,2q�5B      ��5C      �� *SelectedUsuario.Codigo+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5G      $��0��6   $��2��5H      $
��Left=�5I      $��Nombre:��5J      �� 5K      $��0��6   $��3��5L      $��30��5N      $��5,2,5,2q�5O      ��5P      �� *SelectedUsuario.Nombre+$ TwoWay=�$ PropertyChanged=��� 5T      $��1��6   $��0��5U      $
��Left=�5V      $��Correo:��5W      �� 5X      $��1��6   $��1��5Y      $��30��5Z      $��5,2,5,2q�5[      ��5\      �� *SelectedUsuario.Correo+$ TwoWay=�$ PropertyChanged=��� 5`      $��1��6   $��2��5a      $
��Left=�5b      $��Foto:��5c      �� 5d      $��1��6   $��3��5e      $��30��5f      $��5,2,5,2q�5g      ��5h      �� *SelectedUsuario.Foto+$ TwoWay=�$ PropertyChanged=��� 5l      $��2��6   $��0��5m      $
��Left=�5n      $��Contraseña:��5o      G� 5q      -   5         G�Name$ pass1��5q   "   $��2��5r      $��1��5s      $��30��5t      $��5,2,5,5q�5u      $
��Left=�5v      $��Center=�5w      
���   �$��14(�5y       G� 	MaxLength$	 300��5z      �� 5|      $��2��6   $��2��5}      $
��Left=�5~      $��Validar Contraseña:��5      G� 5�      -   5        $ pass2��5�   "   $��2��5�      $��3��5�      $��30��5�      $��5,2,5,5q�5�      $
��Left=�5�      $��Center=�5�      
���   �$��14(�5�      $	 300��5�      �� 5�      $��3��6   $��0��5�      $
��Left=�5�      $��Ubicación:��5�      �� 5�      $��3��6   $��1��5�      $��30��5�      $��0q�5�       �� DisplayMemberPath$ Nombre��5�       �� SelectedValuePath$ Id��67   {�.  ��5�      �� *Ubicaciones+ �� SelectedValue 6?   �� *SelectedUsuario.IdUbicacion+�� 5�      $��3��6   $��2��5�      $
��Left=�5�      $��Tipo de Usuario:��5�      �� 5�      $��3��6   $��3��5�      $��30��5�      $��0q�5�      $ TipoUsuarioSistema��5�      $ Id��6C   ��5�      �� *TipoUsuarios+ 6@   �� *SelectedUsuario.IdTipoUsuario+�� 5�      $��4��6   $��0��5�      $��4��5�      $��5 0 0 0q�5�      ._�5�      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      �� $��40��6%   $��35��5�   !   $��2q�5�   !    � Cursor$
 Hand��5�   !    � ToolTip$ Guardar Cambios��5�   !   ��5�   !   �� *	Agregar+��5�   "   �� 5�   &   $%��/Resources/Images/imgSave32.png��6,   $
��Fill=�6U   5�      �� 5�      $��40��6%   $��35��5�   !   $��2q�5�   !   $ Eliminar Elemento��5�   !   ��5�   !   �� *
Eliminar+��5�   !   �� *Id+{�5�   !   �� *ModoEdicion+��5�   "   �� 5�   &   $'��!/Resources/Images/imgDelete32.png��6,   $
��Fill=�6W   5�      �� 5�      $��40��6%   $��35��5�   !   $��2q�5�   !   $ Nuevo��5�   !   ��5�   !   �� *	Limpiar+��5�   "   �� 5�   &   $#��/Resources/Images/Clean32.png��6,   $
��Fill=�6S   5�      �� 5�      $��40��6%   $��35��5�   !   $��2q�5�   !   $ Limpiar��5�   !   ��5�   !   �� *	Limpiar+��5�   "   �� 5�   &   $&�� /Resources/Images/Update-128.png��6,   $
��Fill=�6V   5�      �� 5�      $��40��6%   $��35��5�   !   $��2q�5�   !   $ Exportar a Excel��5�   !   ��5�   !   �� *ExportarCmd+��5�   "   �� 5�   &   $"��/Resources/Images/Excel3.png��6,   $
��Fill=�6R   5�      5�      5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      �� 5�      $
��auto �6(   .+�5�      �� $��0��6   $��2��6*   
���   �$��1q�6O   $��2q�6c   ._�5�      �� $
��Fill=�6I   $��2q�6X   ��6!   �� *SelectedUsuario.Foto+6e   5�      �� 5�      $��2��6   $��35��6*   $	��100��66   $��
Tomar Foto��6B   ��6W   �� *TomarFotoCmd+5�      5�      5�      �� 5�   
   $��3��6   $��0��5�      $��2q�5�      $��Filtros��5�      .��5�      � $��2,5,2,2q�6    5�      �� 5�      $
��auto �6'   �� 5�      $
��auto �6'   �� 5�      $
��auto �6'   �� 5      $
��auto �6'   �� 5      5     �� 5     .+�5     �� $��0��6   $��0��5     $��Center=�5	     $��Nombre:��5
     �� 5     $��0��6   $��1��5     $	��200��5     $��30��5     $��5,2,5,2q�5     ��5     �� *NombreUsuarioFiltro+$ TwoWay=�$ PropertyChanged=��� 5     $��0��6   $��2��5     $��Center=�5     $��correo:��5     �� 5     $��0��6   $��3��5     $	��200��5     $��30��5     $��5,2,5,2q�5      �� 	MaxLength$ 50��5     ��5     �� *CorreoFiltro+$ TwoWay=�$ PropertyChanged=�5"     5#     /  )BolapanControl.ItemsFilter.FilterDataGrid  5/  
   -   5          Name$ dgSuppliers��5/  "   $��4��50     $��5,0,5,5q�51     &   System.Windows.Controls.DataGrid   AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows . ��55     �� *UsuariosList+ �� IsAsync .  59       5:     $ MouseDoubleClick��6!   . 5;        SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+  �� RelativeSource  �� *Self+5<       5=     $ PreviewMouseDown��6!   . 5>        6*   �� *SelectedITemGridClick+ 6T   �� *	EventArgs+  �� *Self+5?     !   Columns! 5D     4  .System.Windows.Controls.DataGridTemplateColumn  5E     ,	  &System.Windows.Controls.DataGridColumn" 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$" *
 6)   # 	  CanUserResize# . $ 	  Header$$ Codigo ��5G  1   %   CellTemplate% 5J     �� 5K     .R�5L     �� $��1,1,4,1q�6$   $
��Left=�5M  /   $��5,0,0,0q�6Q   $��Center=�6c   ��5N  0   �� *Codigo+$ TwoWay=�$ PropertyChanged=�5O     5Q       5T     $" *
 6)   # . $$ Nombre��5V  1   % 5Y     �� 5Z     .R�5[     �� $��1,1,4,1q�6$   $
��Left=�5\  /   $��5,0,0,0q�6Q   $��Center=�6c   ��5]  0   �� *Nombre+$ TwoWay=�$ PropertyChanged=�5^     5`       5b     $" *
 6)   # . $$ Correo��5d  1   % 5g     �� 5h     .R�5i     �� $��1,1,4,1q�6$   $
��Left=�5j  /   $��5,0,0,0q�6Q   $��Center=�6c   ��5k  0   �� *Correo+$ TwoWay=�$ PropertyChanged=�5l     5n       5q     $" *
 6)   # . $$ Tipo. Usuario��5s  1   % 5v     �� 5w     .R�5x     �� $��1,1,4,1q�6$   $
��Left=�5y  /   $��5,0,0,0q�6Q   $��Center=�6c   ��5z  0   �� *TipoUsuario+$ TwoWay=�$ PropertyChanged=�5{     5}       5�     $	" 100
 6)   $
$ Foto��65   % 5�     �� 5�     .R�5�     �� $'��!/Resources/Images/imagePerson.png��6$   $��35��6O   $��35��6Z    5�  "   _� 5�  &   ��5�  *   �� 5�  .   & �� 
TargetType"& _�6>   .R�5�  2   �� 
�������
����  �$��1q�5�  9   ' �� CornerRadius$' 0��5�  9   ._�5�  6   �� $ 
Horizontal=�6A   .+�5�  :   �� $	��140��6@   $	��140��5�  @   $
��Fill=�5�  @   ��5�  @   �� *Foto+5�  @   5�  7   5�  3   5�  /   5�  '   5�     5�     5�     5�     5�     5�     