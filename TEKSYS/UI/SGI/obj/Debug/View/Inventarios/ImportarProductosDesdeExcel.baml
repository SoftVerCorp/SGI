   M S B A M L   `   `   `  ����  SGI6    0SGI.View.Inventarios.ImportarProductosDesdeExcel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$$  Importar Productos Desde Excel��5   	   $	��200��60   $	��400��6=   .��5      � .+�5   
   �� $��Seleccionar Archivo��6   .��5      ]� .+�5      �� $��Bottom=�6   $��50��62   ._�5	      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5
      �� $	��120��6!   $��40��6-   $��Aceptar��69   ��6K   �� *Importarcmd+�� 5      -   5        $	��120��5   !   $��40��6-   $��Salir��69   6I   5      5      � 5       � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5      �� 5      $
��auto �6+    � RowDefinitions 5      �� 5      �� 5      .+�5      �� $
��Left=�6   $��Center=�67   $��Archivo��6R   �� 5      $��1��6    �� 
IsReadOnly . ��6@   �� *RutaArchivo+ �� Mode$ OneWay=��� 5      $	��...��6   $��2��6+   $��50��6;   $��30��6F   ��6R   �� *BuscarArchivoCmd+�� 5      $��1��6   $
��Left=�6)   $��Center=�6D   $��	Proveedor��6_   �� 5      $��1��6   $��1��6,    . $
��Left=�6v   
���   �
�������$��30��6�   ��6<   �� *	Proveedor+$ OneWay=�6�   �� 5      $��1��6   $	��...��6+   $��2��69   $��50��6I   $��30��6T   ��6`   �� *BuscarProveedorCmd+5       5!      5"      5#      5$      