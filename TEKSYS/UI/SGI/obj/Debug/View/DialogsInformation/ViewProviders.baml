   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5      /    )SGI.View.DialogsInformation.ViewProviders   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )mvvmclr-namespace:SGI.Stuffs     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$  miuser��5       ���#C0C0C0 � 	Resources 5
      ��%    5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+   CommandParameter 6?   ��  �� ElementName$ viewProducts��5      5      .��5      ]� .+�5   
   �� $	��Top=�6   $��40��6&   $��0q�62   ���#0055FF   
LabelTitle#��[  6S   ��5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $��Consultar Proveedores��6   $��Center=�6<   $��Center=�6`   $��14(�6�   
�������6�   �� 5      -   5        $��40��5      $��2q�6)   	 � ToolTip$	 Nuevo��6I   
 � Cursor$

 Hand��6Y   ��6h   �� *Clean+��5      �� 5      $#��/Resources/Images/Clean32.png��6$   $
��Fill=�6K   6\   5      �� 5      -   5        $��40��5      $��2q�6)   $	 Busqueda��64   $

 Hand��6H   ��6V   �� *Clean+��5      �� 5       $ ��/Resources/Images/lupa.png��6$   $
��Fill=�6H   6Y   5"      5#      5%      � 5&   
    � RowDefinitions 5'      �� 5(      $
��auto �6    61   �� 5)      $
��auto �6    60   �� 5*      6"   .+�5.      �� -   5         ��Name$ 	brdSearch��5.      $��80��6(   $��0��64   $��2,1,2,2q�6A   
���   �$��1q�6f   ._�5/      �  50      �� 51      $
��auto �6(   68   �� 52      $
��auto �6(   68   .+�54      �� #��[  6   ���#466EBC$��0q�6U   $��Busqueda��6i   56      �� 57      $��0,2,0,2q�6   $��1��6/   ._�58      �  � ColumnDefinitions 59      �� 5:   "   $
��auto �63   �� 5;   "   $
��auto �63   �� 5<   "   $
��auto �63   �� 5=   "   $
��auto �63   �� 5>   "   $
��auto �63   �� 5?   "   �� 5@   "   �� 5A   "    5C      �� 5D   "   $
��auto �60   .+�5G      �� $��0��6$   $��0��61   $��Nombre:��6C   �� 5H      $��0��6&   $	��150��63   $��1��6?    �� 	MaxLength$ 60��6Q   $��0,0,5,0q�5I   Q   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6Q   �� 5K      $��0��6$   $��2��61   $
��RFC:��6C   �� 5L      $��0��6&   $	��150��63   $��3��6?   $ 60��6Q   $��0,0,5,0q�5M   P   ��6   �� *Rfc+$ PropertyChanged=�6P   �� 5O      $��4��6%   $��	Refrescar��65   $	��120��6I   $��35��6U   $��Center=�5P      $��Center=�66   ��5Q      �� *	Refresh+5R      5S      5T      5U      �� 5W      -   5        $ bdrOperations��5W      $	��150��6,   $��1��69   $��2,0,2,2q�6G   
���   �$��1q�6l   ._�5X      �  5Y      �� 5Z      $
��auto �6+   �� 5[      $
��auto �6+   �� 5\      $
��auto �6+   �� 5]      $
��auto �6+   �� 5^      $
��auto �6+   �� 5_      $
��auto �6+   �� 5`      �� 5a       5c      �� 5d      $��35 �6(   �� 5e      $��35 �6(   �� 5f      $��35 �6(   �� 5g      $��40 �6(   .+�5j      �� #��[  6   ���#466EBC$$��Altas , Bajas y Modificaciones��6U   $��0q�6~   $��8��6�   $��0��6�   �� 5l      $��Nombre:��6   $��1��61   $��0��6>   �� 5m      -   5         ��Name$ txtProviderName��5n   w   $��1��5m      $��1��6+   $��30��6<   $	��150��6H   $	 100��6T   $��1,2,5,0q�5n   f   ��6   �� *ProviderName+$ PropertyChanged=� �� Mode$ TwoWay=�6w   �� 5p      $
��RFC:��6   $��1��6.   $��2��6;   �� 5q      $��1��6   $��3��6,   $��30��6=   $	��150��6I   $	 100��6U   $��1,2,5,0q�5r   e   ��6   �� *ProviderRFC+$ PropertyChanged=�$ TwoWay=�6e   �� 5t      $��Dirección:��6   $��1��64   $��4��6A   �� 5u      $��1��6   $��5��6,   $	��150��6=   $��30��6I   $ 50��6V   $��1,2,5,0q�5v   i   ��6   �� *ProviderAddress+$ PropertyChanged=�$ TwoWay=�6i   �� 5x      $��3��6   $��8��6*   $��40��6?     BorderBottom#��[ 6K   ._�5y      �� $ 
Horizontal=�6%   $
��Left=�6>   $��Center=�6Y   .+�5z      �� $��35��6%   $��40��61   $��2q�6<   $

 Hand��6G   $	 Guardar Cambios��6U   ��5{   !   �� *Save+��5|   "   �� 5}   &   $%��/Resources/Images/imgSave32.png��6,   $
��Fill=�6U   6f   5      �� 5�      $��35��6%   $��40��61   $��2q�6<   $	 Eliminar Elemento��6G   ��5�   !   �� *
DeleteItem+��5�   "   �� 5�   &   $'��!/Resources/Images/imgDelete32.png��6,   $
��Fill=�6W   6h   5�      �� 5�      $��35��6%   $��40��61   $��2q�6<   $	 Nuevo��6G   ��6X   �� *Clean+��5�   "   �� 5�   &   $#��/Resources/Images/Clean32.png��6,   $
��Fill=�6S   6d   5�      5�      5�      5�      5�      �� 5�      $��2��6   $��2,1,2,2q�6#   
���   �$��1q�6H   ._�5�      ]� .+�5�      �� #��[  6   ���#466EBC$��0q�6U   $	��Top=�6i   $��Detalle��6~   $��0��6�   &   System.Windows.Controls.DataGrid  5�      $��1��6      AutoGenerateColumns .     CanUserAddRows .  $��0,1,0,0q�6`   ��5�      �� *
ItemList+$ TwoWay=� �� IsAsync .  �� SelectedItem 5�      �� *SelectedItem+ 5�        5�      $ PreviewMouseDown��6-   . 5�   "      SGI.Stuffs.EventToCommand     Command 66   �� *SelectedITemGridClick+   CommandParameter 6`   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��63      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6C   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6P   �� *Name+6l     5�      $	 Rfc��63   $
 0.5*	 6@    6N   �� *Rfc+6i     5�      $ 
Dirección��63   $ *	 6F    6Q   �� *	Address+6p   5�      5�      5�      5�      5�      5�      