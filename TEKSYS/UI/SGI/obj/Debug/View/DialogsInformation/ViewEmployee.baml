   M S B A M L   `   `   `  ����  SGI.    (SGI.View.DialogsInformation.ViewEmployee   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      ���#C0C0C0  � 	Resources  5      ��%    .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+   CommandParameter 6?   ��  �� ElementName$ viewEmployees��5      .��5      ]� .+�5   
   �� $��Consultar Empleados��6   $	��Top=�5         
LabelTitle#��[  5      �� 5   
   
���   �$��1q�5      $	��Top=�5      $��	Consultar��5      .��5      �� $��0,2,0,2q�6   ._�5      �  � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5       $
��auto �6+   �� 5!      $
��auto �6+   �� 5"      $
��auto �6+   �� 5#      $
��auto �6+    � RowDefinitions 5%      �� 5&      $��35 �6(   �� 5'      $��35 �6(   �� 5(      $
��auto �6(   .+�5*      �� $��0��6   $��0��5+      $��65��5,      $��Nombre:��5-      �� 5.      $��0��6   $��1��5/      $	��180��50      $��0,0,5,0q�51      	 �� 	MaxLength$		 100��52      ��53      �� *Name+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5B      $��0��6   $��6��5C      $	��120��5D      $��35��5E      $��Center=�5F      $��Center=�5G      $��	Refrescar��5I      ��5H      �� *	Refresh+5I      5J      5K      5L      &   System.Windows.Controls.DataGrid  5M   
   $��0,5,0,0q�6      AutoGenerateColumns .     CanUserAddRows .  ��5P      �� *
ItemList+ �� Mode$ TwoWay=� �� IsAsync .  �� SelectedItem 5S      �� *SelectedItem+   Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Empleado��5W   %   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5V   %   �� *Name+5W   %     5X      $	 125 6%   $ Fecha de ingreso��5[   %    5Y   %   �� *
HireDate+ �� StringFormat$ {0:dd/MM/yyyy}�� 	  ElementStyle 5\      �� 5]       �� 
TargetType" ��6    .�5^      ��  �� Property � �� �� Value$ Center=�6D   �� 5_       � ��$ Center=�6B   5`      5b        5d      $	 150 6%   $ Email��5f   %    5e   %   �� *Email+5f   %   4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5h      $	 110 6)   $ Notificaciones��5j   )    5i   )   �� *SendNotifications+ 5k      �� 5l      " ��6    .�5m      ��  � ��$ Center=�6D   �� 5n       � ��$ Center=�6B   5o      5q      4  .System.Windows.Controls.DataGridTemplateColumn  5s      $	 100 6)   $
 Foto��65      CellTemplate 5t      �� 5u      .R�5v      �� $'��!/Resources/Images/imagePerson.png��6$    � ToolTip 5w   "   _� 5x   &   ��5y   *   �� 5z   .    �� 
TargetType" _�6>   .R�5{   2   �� 
�������
����  �$��1q�5}   9    �� CornerRadius$ 0��5~   9   ._�5   6   ��  �� Orientation$ 
Horizontal=�6A   .+�5�   :   �� $	��140��6@   $	��140��5�   @   $
��Fill=�5�   @   ��5�   @   �� *	PhotoPath+5�   @   5�   7   5�   3   5�   /   5�   '   5�      5�      5�      5�      5�      5�      