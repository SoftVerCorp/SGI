   M S B A M L   `   `   `  ����  SGI    SGI.View.NewUserView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  newUser��5   	    � Title$ Nuevo Usuario��5   	   $	��400��5   	   $	��260��5   	      WindowDialog#��[  5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *Loaded+   CommandParameter 6?   ��  �� ElementName$ newUser��5        5   
   $ ContentRendered��6   . 5         6$   �� *ContentRendered+ 6H   �� $ newUser��5      .��5      ]� .+�5   
   �� $��Nuevo Usuario��6   $	��Top=�5        
LabelTitle#��[ 5      �� 5   
   $��Bottom=�6     BorderBottom#��[ 6)   ._�5      �� $��Center=�6   	 �� Orientation$	 
Horizontal=�66   .+�5      �� $��Aceptar��5      
 �� 	IsDefault
 .   	ButtonApp#��[ 5      ��5      �� *Accept+5      �� 5      $��Cancelar��5       �� IsCancel . #��[ 5       ��5      �� *Close+5       5!      5"      � 5#   
    � ColumnDefinitions 5$      �� 5%      $
��auto �6#   �� 5&      �� 5'      $
��auto �6#    � RowDefinitions 5)      �� 5*      �� 5+      �� 5,      .+�50      �� $��0��6   $��0��51      $��Usuario:��52      �� 53      -   5         ��Name$ txtUser��53      $��0��54      $��1��55      $��2��56      $��35��57      $��0,2,5,5q�58       �� 	MaxLength$ 20��59      ��5:      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5?      $��1��6   $��0��5@      $��Contraseña:��5A      G� 5B      -   5         G�Name$ pass1��5B      $��1��5C      $��1��5D      $��2��5E      $��35��5F      $��0,2,5,5q�5G      $
��Left=�5H      $��Center=�5I      
���   �$��14(�5K       G� 	MaxLength$	 300��5L      �� 5N      $��2��6   $��0��5O      $��Verificar Contraseña��5P      G� 5Q      -   5        $ pass2��5Q      $��2��5R      $��1��5S      $��2��5T      $��35��5U      $��0,2,5,5q�5V      $
��Left=�5W      $��Center=�5X      
���   �$��14(�5Z      $	 300��5[      5\      5]      5^      