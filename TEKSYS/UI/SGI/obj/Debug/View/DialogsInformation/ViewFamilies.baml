   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   .    (SGI.View.DialogsInformation.ViewFamilies   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   #mvvmclr-namespace:SGI.Stuffs  5   	   -   5          �Name$  
viewFamily��5   /    � Title$ Consultar Familias��5   	   $	��400��6$   $	��650��61    � WindowStartupLocation$ CenterScreen=�5   	      WindowDialog#��[  5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5	      /  )System.Windows.Interactivity.EventTrigger  5
   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+   CommandParameter 6?   ��  �� ElementName$ 
viewFamily��5      5      .��5      ]� .+�5   
   �� $	��Top=�6   $��Consultar Familias��6&     
LabelTitle#��[ 6C   �� 5   
   $��Bottom=�6     BorderBottom#��[ 6)   ._�5      �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�62   .+�5      �� 
 �� 	IsDefault
 . $��Aceptar��6*     	ButtonApp#��[ 6W   ��6<   �� *Accept+6W   �� 5       �� IsCancel . $��Cancelar��6)   #��[ 6V   ��6<   �� *Close+6V   5      5      � 5   
   $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      .+�5$      �� $��Nombre:��6   �� 5%      $��1��6    �� 	MaxLength$ 60��6(   $��5,2,5,2q�5&   ]   ��6   �� *FamilyNameFilter+ �� UpdateSourceTrigger$ PropertyChanged=�6]   5'      �� 5)   
   $��0,2,0,0q�6   ._�5*      �  5+      �� 5,      ��6'   �� *IsOpenWidth+  WidthColumnConverter �� 	Converter# [ �� 5-      $��10 �6'   �� 5.      .+�51      ]� $��0��6   $��0,0,0,5q�6,   .+�52      �� $��Bottom=�6   $��40��65   #��[ 6A   ._�53      �� $	 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�54      �� $��35��6%   $��40��61   $��2q�6<    � Cursor$
 Hand��6G    � ToolTip$ Guardar Cambios��6U   ��55   !   �� *Save+��56   "   �� 57   &   $%��/Resources/Images/imgSave32.png��6,   $
��Fill=�6U   6f   59      �� 5;      $��35��6%   $��40��61   $��2q�6<   $ Eliminar Elemento��6G   ��5<   !   �� *
DeleteItem+��5=   "   �� 5>   &   $'��!/Resources/Images/imgDelete32.png��6,   $
��Fill=�6W   6h   5@      �� 5B      $��35��6%   $��40��61   $��2q�6<   $ Nuevo��6G   ��6X   �� *Clean+��5C   "   �� 5D   &   $#��/Resources/Images/Clean32.png��6,   $
��Fill=�6S   6d   5F      5H      5I      �� 5J      $��0��6!   .@�5K      �� $��Familias��6"   .��5L      �� .@�5M   "   �� $$��                              ��6*   .��5N   &   �  5O   *   �� 5P   .   $
��auto �6?   �� 5Q   .    5S   *   �� 5T   .   $��35 �6<   �� 5U   .   $��35 �6<   �� 5V   .   $��35 �6<   .+�5Y   *   �� $��Familia:��62   $��0��6E   $��0��6R   �� 5Z   *   -   5         ��Name$ txtFamiliName��5\      $��1��5Z   2   $ 60��6D   $��0,0,5,0q�5[   W   ��6   �� *
FamilyName+$ PropertyChanged=�5\      5^   '   5_   #   5a      5b      5c      5d      �� 5f      $��1��6   $	��100��6)   $��10��5g      $��Center=�6    $��Center=�6=   ��5h      �� *OpenWidthCommand+��5i      �� 5j      $��10��6    $	��100��6+   $ ��/Resources/Images/Open.png��68   6^   5l      &   System.Windows.Controls.DataGrid  5n      $��2��6      AutoGenerateColumns .  $��0,2,0,0q�6G      CanUserAddRows .  ��5o      �� *
FamilyList+ �� SelectedItem 5p      �� *SelectedItem+ 5r        5s      $ PreviewMouseDown��6)   . 5t         SGI.Stuffs.EventToCommand     Command 62   �� *SelectedITemGridClick+   CommandParameter 6\   �� *	EventArgs+ �� RelativeSource �� *Self+5u         Columns 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Familias.��6/      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 0.5*	 6B   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5z   )   �� *
FamilyName+ 
  ElementStyle 5{      �� 5|   "    �� 
TargetType" ��6(   .�5}   &   ��   �� Property  � ��! �� Value$
! Left=�6L   �� 5~   &     � ��$! Center=�6J   5   #   5�      5�      5�      5�      5�      5�      