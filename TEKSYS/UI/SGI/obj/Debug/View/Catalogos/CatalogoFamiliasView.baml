   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   -    'SGI.View.Catalogos.CatalogoFamiliasView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Catálogo Familias��5   	   $	��800��5   	   $	��700��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ Normal=�5   	    � 	Resources 5       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��85 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5       �� *IsModeSearch+�� 5"   
   $��1��6   $��0��5#      $��5,10,5,2q�5$      $
��Auto=�5%      .��5&      ��  �� Orientation$ Vertical=�6   y�60   �� *IsModeSearch+.+�5(      �� $ 
Horizontal=�6   .+�5*      �� $��Nombre:��6   �� 5+      $��1��6   $	��300��5,      $��5,2,5,2q�5-       �� 	MaxLength$ 50��5.      ��5/      �� *Family+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 53      $
��URL:��6   �� 54      $	��300��6   $��5,2,5,2q�55      $ 50��56      ��57      �� *Url+$	 TwoWay=�$
 PropertyChanged=�5;      �� 5=      $��5 15 0 0q�6   ._�5>      �� $ 
Horizontal=�6!   .+�5?      �� $	��120��6C   $��40��6O   ��6!   �� *CreateFamily+.��5@      �� $ 
Horizontal=�6*   $
��Left=�6C   $	��Top=�6^   .+�5B   "   �� $��Guardar [F5]��6,   $��Center=�6@   5C      5D      �� 5F      $	��120��6A   $��40��6M   ��6!   �� *
DeleteItem+.��5G      �� $ 
Horizontal=�6*   $
��Left=�6C   $	��Top=�6^   .+�5I   "   �� $��Eliminar��6,   $��Center=�6<   5J      5K      �� 5M      $	��120��6<   $��40��6H   ��6!   �� *Clean+.��5N      �� $ 
Horizontal=�6*   $
��Left=�6C   $	��Top=�6^   .+�5P   "   �� $��Cancelar [F8]��6,   $��Center=�6A   5Q      5R      �� 5T      $	��120��6B   $��40��6N   ��6!   �� *ExportarCmd+.��5U      �� $ 
Horizontal=�6*   $
��Left=�6C   $	��Top=�6^   .+�5W   "   �� $��Exportar [F9]��6,   $��Center=�6A   5X      5Y      �� 5[      $	��120��6?   $��40��6K   ��6!   �� *
SalirCmd+.��5\      �� $ 
Horizontal=�6*   $
��Left=�6C   $	��Top=�6^   .+�5^   "   �� $��Salir [Shift+Esc]��6,   $��Center=�6E   5_      5`      5b      5c      5e      5g      �� 5i   
   $��2��6   $��0��5j      $��7��5k      $��1 3 1 1q�5l      $��Stretch=�5m      
�������5n      �� 5p   
   $��3��6   $��0��5q      $��2,5,2,2q�5r      $ Vertical=�5s      .+�5t      �� $ 
Horizontal=�6   .+�5u      �� $��Buscar:��6   �� 5v      $��1��6   $	��300��5w      $��5,2,5,2q�5x      $ 50��5y      ��5z      �� *FamilySearch+$
 PropertyChanged=�5|      �� 5}      $��7 5 0 0q�6   $ 
Horizontal=�6*   .+�5~      �� $	��120��6<   $��40��6H   ��6   �� *RefreshSearch+.��5      �� $ 
Horizontal=�6"   $
��Left=�6;   $	��Top=�6V   .+�5�      �� $��Refrescar [F2]��6$   $��Center=�6:   5�      5�      5�      5�      /  )BolapanControl.ItemsFilter.FilterDataGrid  5�   
   -   5          Name$ 
dgFamilies��5�   "   $��4��5�      $��0��5�      $	��200��5�      $��2,5,2,5q�5�      &   System.Windows.Controls.DataGrid   AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserResizeRows . ��5�      �� *
FamilyList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PreviewMouseDown��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Nombre��5�   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5�   %   �� *
FamilyName+5�   %     5�      $
 0.5*	 6%    . $	 Url��5�   %    .  5�   %   �� *Url+5�   %   5�      5�      5�      