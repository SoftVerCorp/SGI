   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   &     SGI.View.CatalogoProveedoresView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  5   
   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	     � Title$  Catalogo de Proveedores��5   	   $	��800��5   	   $	��688��5	   	    � WindowState$ 	Maximized=�5
   	    � 	Resources 5       �� Source�� 5   
   $- '/Resources/Styles/ItemsFilterStyle.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��5      $��7��5      
�������y�5      �� *IsModeSearch+�� 5    
   $��2��6   $��0��5!      $��7��5"      $��1 3 1 1q�5#      $��Stretch=�5$      
�������5%      �� 5'   
   $��3��6   $��0��5(      $��2q�5)      $��Filtros��5*      .��5-      � $��2,5,2,2q�6    5.      �� 5/      $
��auto �6'   �� 50      $
��auto �6'   �� 51      $
��auto �6'   �� 52      $
��auto �6'   �� 53       55      �� 56      .+�59      �� $��0��6   $��0��5:      $��Center=�5;      $��Nombre:��5<      �� 5=      $��0��6   $��1��5>      $	��200��5?      $��30��5@      $��5,2,5,2q�5A       �� 	MaxLength$ 50��5B      ��5C      �� *NombreProveedorFiltro+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5G      $��0��6   $��2��5H      $��Center=�5I      $��Razon Social:��5J      �� 5K      $��0��6   $��3��5L      $	��200��5M      $��30��5N      $��5,2,5,2q�5O      $ 50��5P      ��5Q      �� *RazonSocialFiltro+$ TwoWay=�$ PropertyChanged=�5U      5V      /  )BolapanControl.ItemsFilter.FilterDataGrid  5b   
   -   5        	  Name$	 dgSuppliers��5b   "   $��4��5c      $��5,0,5,5q�5d      &   System.Windows.Controls.DataGrid
   AutoGenerateColumns
 .  
�������   CanUserAddRows .     CanUserResizeRows . ��5i      �� *ProviderList+ �� IsAsync . .  (System.Windows.Interactivity.Interaction   Triggers 5l      /  )System.Windows.Interactivity.EventTrigger  5m         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5n         SGI.Stuffs.EventToCommand     Command 6*   �� *SelectedITemGridClick+   CommandParameter 6T   �� *	EventArgs+ �� RelativeSource �� *Self+5o         Columns 5r      0  *System.Windows.Controls.DataGridTextColumn  5t      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6%      CanUserResize .    Header$ Número��5w   %      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5u   %   �� *Id+5x   %     5y      $
 0.5*	 6%    . $ Razón Social��5|   %    .  5z   %   �� *CompanyName+5}   %     5~      $
 0.5*	 6%    . $ Nombre��5�   %    .  5   %   �� *Name+5�   %     5�      $
 0.5*	 6%    . $ 
Dirección��5�   %    .  5�   %   �� *	Address+5�   %     5�      $
 0.5*	 6%    . $ Correo��5�   %    .  5�   %   �� *Correo+5�   %   5�      5�      5�      