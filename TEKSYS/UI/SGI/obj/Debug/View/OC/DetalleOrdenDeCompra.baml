   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   #    SGI.View.DetalleOrdenDeCompra   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Detalle Orden DeCompra��5   	   $	��950��5   	   $	��300��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      ]� .+�5   
   �� $��2q�6   $	��Top=�5      $��14(�5      $��Detalle orden de compra��5      .��5      �  � ColumnDefinitions 5      �� 5      $	��100 �6'   �� 5      $	��325 �6'   �� 5      $	��100 �6'   �� 5      $	��325 �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5!      �� $��0��6   $��0��5"      $
��Auto��5#      $��Linea: ��5$      �� 5%      $��0��6   $��1��5&      $
��Auto��5'      $��5,2,5,2q�5(      ��5)      �� *Line+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5-      $��0��6   $��2��5.      $
��Auto��5/      $��Precio unitario: ��50      �� 51      $��0��6   $��3��52      $
��Auto��53      $��5,2,5,2q�54      ��55      �� *	UnitPrice+$ TwoWay=�$ PropertyChanged=��� 59      $��1��6   $��0��5:      $
��Auto��5;      $��
Cantidad: ��5<      �� 5=      $��1��6   $��1��5>      $
��Auto��5?      $��5,2,5,2q�5@      ��5A      �� *
Quantity+$ TwoWay=�$ PropertyChanged=��� 5Q      $��1��6   $��2��5R      $
��Auto��5S      $��Monto: ��5T      �� 5U      $��1��6   $��3��5V      $
��Auto��5W      $��5,2,5,2q�5X       �� 
IsReadOnly . ��5Z      �� *Amount+$ TwoWay=�$ PropertyChanged=��� 5^      $��3��6   $��0��5_      $
��Auto��5`      $��Nombre: ��5a      �� 5b      $��3��6   $��1��5c      $��3��5d      $
��Auto��5e      $��5,2,5,2q�5f      ��5g      �� *Nombre+$ TwoWay=�$ PropertyChanged=��� 5k      $��4��6   $��0��5l      $
��Auto��5m      $��Descripción: ��5n      �� 5o      $��4��6   $��1��5p      $��3��5q      $
��Auto��5r      $��5,2,5,2q�5s      ��5t      �� *Description+$ TwoWay=�$ PropertyChanged=��� 5x      $��5��6   $��0��5y      $
��Auto��5z      $��
Producto: ��5{      �� 5|      $��5��6   $��1��5}      $
��Auto��5~      $��5,2,5,2q�5       . ��5�      �� *	IdProduct+$ TwoWay=�$ PropertyChanged=��� 5�      -   5        $��btnSearchProduct��5�      $��5��5�      $��2��5�      $��80��5�      $
��Auto��5�      $��0,2,0,2q�5�      $��Buscar��5�      ��5�      �� *SearchProducts+5�      �� 5�      $��6��6   $��3��5�      $��5,10,5,2q�5�      $��Right=�5�       �� Orientation$ 
Horizontal=�5�      .+�5�      �� -   5        $��	btnCancel��5�      $	��100��5�      $
��Auto��5�      $��0,0,5,2q�5�      $��Cancelar��5�      ��5�      �� *Clean+5�      �� 5�      -   5        $��btnAdd��5�      $	��100��5�      $
��Auto��5�      $��0,0,0,2q�5�      $��Agregar��5�      ��5�      �� *Accept+5�      5�      5�      5�      5�      5�      