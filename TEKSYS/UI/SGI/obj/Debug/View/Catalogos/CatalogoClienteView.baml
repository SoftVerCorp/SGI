   M S B A M L   `   `   `  ����>  :SGI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SGI.View.CatalogosSGI.View.Catalogos  5   	   -clr-namespace:SGI.AutoComboSGI.AutoCombo  5	   	   'clr-namespace:SGI.Stuffs
SGI.Stuffs  5   	   ,    &SGI.View.Catalogos.CatalogoClienteView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SGI.View.Catalogos     5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f46wpfext)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   F BWpfControls, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null$combo2http://wpfcontrols.com/  5   	   'comboclr-namespace:SGI.AutoCombo  5	   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   !bhclr-namespace:SGI.Stuffs  5   	     � Title$  Catalogo de Clientes��5   	   $
��1200��5   	   $	��850��6    � WindowState$ 	Maximized=�5   	    � 	Resources 5      -   'SGI.Stuffs.BooleanToVisibilityConverter   	boolToVis#   SGI.AutoCombo.ClientsProvider  ClientesProvider  clienteTemplate �� Padding � ColumnDefinitions � RowDefinitions �� Path��%M  &	        &	      &	 &       5   
   6*     5   
   6    �� 5   
   .R�5      �� $ 5q�6   ._�5      �  5      �� 5      $��40 �6+   �� 5       5      �� 5      �� 5      .+�5       �� $��2��6   $��32��5!      $��32��5"      $��Center=�5#      $��Center=�5$      $#��/Resources/Images/cliente.png��5%      �� 5&      $
��Bold"�5'       $��1��5(       $��0��5)       $��Segoe UI)�5*       
�������$��Bottom=�5+       
���   ���5&       �� $ NombreFiscal�5+   ;   50      51      52      53       J� InputBindings 54      �� 55   
   
 �� Key$	 Esc��6   	 �� 	Modifiers$	 Shiftf�6   
 �� Command
 61   �� *
SalirCmd+�� 56   
   $ F3��6   
 6   �� *	BuscarCmd+�� 57   
   $ F4��6   
 6   �� *
NuevoCmd+�� 58   
   $ F2��6   
 6   �� *	EditarCmd+�� 59   
   $ F5��6   
 6   �� *
GuardarCmd+�� 5:   
   $ F8��6   
 6   �� *CancelarCmd+.��5<      �  5=   
   �� 5>      $
��Auto �6   6,   �� 5?      $
��Auto �6   6,   �� 5@      $��* �6   6)   .+�5C   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5D      �� $	��120��62   $��40��6>   ��6   �� *
SalirCmd+.��5E      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5G      �� $��Salir [Shift-Esc]��6    $��Center=�69   6X   5H      5I      �� 5J      $	��120��6   $��40��6"   ��6.   �� *	BuscarCmd+.��5K      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5M      �� $��Buscar [F3]��6    $��Center=�63   6R   5N      5O      �� 5P      $	��120��63   $��40��6?   ��6   �� *
NuevoCmd+.��5Q      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5S      �� $��
Nuevo [F4]��6    $��Center=�62   5T      5U      �� 5V      $	��120��6   $��40��6"   ��6.   �� *	EditarCmd+{�6L   �� *HabilitatBtnModificar+.��5W      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5Y      �� $��Editar [F2]��6    $��Center=�63   6R   5Z      5[      �� 5\      $	��120��6   $��40��6"   ��6.   �� *EliminarCmd+{�6N   �� *HabilitatBtnEliminar+.��5]      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5_      �� $��Eliminar��6    $��Center=�60   6O   5`      5a      �� 5b      $	��120��6_   $��40��6k   {�6   �� *HabilitatBtnGuardar+��6?   �� *
GuardarCmd+.��5c      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5e      �� $��Guardar [F5]��6    $��Center=�64   6S   5f      5g      �� 5h      $	��120��6   $��40��6"   ��6.   �� *CancelarCmd+.��5i      �� $ 
Horizontal=�6   $
��Left=�67   $	��Top=�6R   .+�5j      �� $��Cancelar [F8]��6    $��Center=�65   6T   5k      5l      5m      �� 5o   
   $ 
Horizontal=�6   $��1��6.   y�6<   �� *IsEnabledFind+ �� 	Converter# [  .+�5p      �� $��0��6   $��0��5q      $��Center=�5r      $��Cliente:��5s      -  'WpfControls.Editors.AutoCompleteTextBox  5t      -   5          Name$
 Actb��5      $	��500��5t   )   $��5q�66   $��Center=�5u      $��0��5v      $��1��5w      $��7��6!   $��30��5x         DisplayMember$ Nombre��5y         ItemTemplate# [ 5z         	Watermark$ Buscar por nombre��5{         IconPlacement$
 Left=�5|         IconVisibility$ Visible=�5}         Provider# [ 5~      |�.    SelectedItem 5�      �� 5�      $ SelectedCliente�6    �� Mode$ TwoWay=�65    �� ValidationRules 5�      *   $SGI.AutoCombo.RequiredValidationRule  5�      5�         LoadingContent 5�      �� 5�      $��Cargando...��6    $��5q�5�      
�������$��14(�5�      
���   �6+      Icon 5�      �� 5�      $��20��6   $��20��6(   ._�5�      �� $'��!/Resources/Images/search_icon.png��6    $��16��5�   $   $��16��5�   $   $��Center=�5�   $   $��Center=�5�   $   5�      5�      5�      �� 5�   
   $��2��6   .��5�      � ��.  5�      �� 5�      $
��Auto �6$   64   �� 5�      $
��Auto �6$   64   �� 5�      $
��Auto �6$   64   �� 5�      $
��Auto �6$   64   �� 5�      $
��Auto �6$   64   .+�5�      �� $��0��6   $��Datos del cliente��6(   $��2q�6C   .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<    5�      �� 5�      $
��Auto �6/   6>   �� 5�      $��* �6/   6;   �� 5�      $
��Auto �6/   6>   �� 5�      $��* �6/   6;   �� 5�      $
��Auto �6/   6>   �� 5�      $��* �6/   6;   .+�5�      �� $��0��6    $��0��6-   $��Clave��6=   6O   �� 5�      $��0��6"   $��1��6/    �� 
IsReadOnly . ��6?   �� *SelectedCliente.IdCliente+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5�      $��0��6    $��2��6-   $��Tipo de Cliente��6=   6Y   �� 5�      $��0��6$   $��3��61   $��5,0,0,0q�6h    �� DisplayMemberPath$ TipoClientes��5�      $��30��6d   ��5�   A   �� *TipoDeClientes+ �� SelectedItem 5�   =   �� *TipodeCliente+{�6p   �� *
IsEditable+�� 5�      $��0��6    $��5��6-   $��
Incobrable��6=   6T   �� 5�      $��0��6#   $��5,12,0,0q�60   $��4��6B   $	��Top=�6    d� 	IsChecked 6R   �� *
Incobrable+$ TwoWay=�6�   5�      5�      �� 5�      $��1��6   $ ��Datos fiscales del cliente��6(   $��2q�6L   .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<    5�      �� 5�      $
��Auto �6/   6>   �� 5�      $
��231* �6/   6>   �� 5�      $
��Auto �6/   6>   �� 5�      $
��231* �6/   6>   �� 5�      $	��55* �6/   6=   �� 5�      $
��230* �6/   6>   �� 5�      $
��Auto �6/   6>   �� 5�      $
��231* �6/   6>   .+�5�      �� $��0��6    $��0��6-   $��Nombre Fiscal��6=   6W   �� 5�      $��0��6"   $��1��6/   $��3��6?       SGI.Stuffs.TextBoxBehavior   SelectAllTextOnFocus . ��6S   �� *Nombrefiscal+$ TwoWay=�{�6}   �� *	IsEnabled+.��6�   5�      �� 5�      $��0��6    $��4��6-   $	��RFC��6=   6M   �� 5�      $��0��6"   $��5��6/    . ��6?   �� *Rfc+$ TwoWay=�{�6`   �� *	IsEnabled+.��6�   5�      �� 5�      $��0��6    $��6��6-   $��Tipo Persona��6=   6V   �� 5�      $��0��6$   $��7��61   $��2��6A   $��5,0,0,0q�6|   $
 Tipo��5�      $��30��6Z   ��5�   U   �� *TipoDePersonas+ 5�   5   �� *TipoPersona+{�6f   �� *	IsEnabled+�� 5�      $��1��6    $��0��6-   $��Calle y numero��6=   6X   �� 5�      $��1��6"   $��1��6/   $��3��6?    . ��6S   �� *	Direccion+$ TwoWay=�{�6z   �� *	IsEnabled+.��6�   5�      �� 5�      $��1��6    $��4��6-   $��Colonia��6=   6Q   �� 5�      $��1��6"   $��5��6/    . ��6?   �� *	Colonia+$ TwoWay=�{�6d   �� *	IsEnabled+6�   �� 5�      $��1��6    $��6��6-   $
��C.P.��6=   6N   �� 5�      -   5        $��1��5�   "   $��7��6/    . ��6?   �� *Cp+$ TwoWay=�{�6_   �� *	IsEnabled+.��6�   5�      �� 5�      $��2��6    $��0��6-   $��Estado��6=   6P   �� 5�      $��2��6"   $��1��6/    . ��6?   �� *Estado+$ TwoWay=�{�6c   �� *	IsEnabled+6�   �� 5�      $��2��6    $��2��6-   $��Ciudad��6=   6P   �� 5�      $��2��6"   $��3��6/    . ��6?   �� *Ciudad+$ TwoWay=�{�6c   �� *	IsEnabled+6�   �� 5�      $��2��6    $��4��6-   $
��Zona��6=   6N   �� 5�      $��2��6"   $��5��6/    . ��6?   �� *Zona+$ TwoWay=�{�6a   �� *	IsEnabled+6�   5�      5�      �� 5�      $��2��6   $#��Datos comerciales del cliente��6(   $��2q�6O   .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5      $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<    5     �� 5     $
��Auto �6/   6>   �� 5     $��* �6/   6;   �� 5     $
��Auto �6/   6>   �� 5     $��* �6/   6;   �� 5	     $
��Auto �6/   6>   �� 5
     $��* �6/   6;   .+�5     �� $��0��6    $��0��6-   $��Nombre comercial��6=   6Z   �� 5     $��0��6"   $��1��6/   $��3��6?    . ��6S   �� *NombreComercial+$ TwoWay=�{�6�   �� *	IsEnabled+6�   �� 5     $��0��6    $��4��6-   $��
Pagina Web��6=   6T   �� 5     $��0��6"   $��5��6/    . ��6?   �� *	PaginaWeb+$ TwoWay=�{�6f   �� *	IsEnabled+6�   �� 5     $��1��6    $��0��6-   $��Contacto��6=   6R   �� 5     $��1��6"   $��1��6/   $��3��6?    . ��6S   �� *
Contacto+$ TwoWay=�{�6y   �� *	IsEnabled+6�   �� 5     $��1��6    $��4��6-   $��Telefono contacto��6=   6[   �� 5     $��1��6"   $��5��6/    . ��6?   �� *TelefonoContacto+$ TwoWay=�{�6m   �� *	IsEnabled+6�   �� 5     $��2��6    $��0��6-   $��Direccion de envio��6=   6\   �� 5     $��2��6"   $��1��6/   $��5��6?    �� AcceptsReturn .   �� TextWrapping$
  Wrap=�6�    . ��6S   �� *DireccionEnvio+$ TwoWay=�{�6�   �� *	IsEnabled+6�   �� 5     $��3��6    $��0��6-   $��
Telefono 1��6=   6T   �� 5     -   5        $��3��5  "   $��1��6/    . ��6?   �� *	Telefono1+$ TwoWay=�{�6f   �� *	IsEnabled+6�   �� 5     $��3��6    $��2��6-   $��
Telefono 2��6=   6T   �� 5      -   5        $��3��5   "   $��3��6/    . ��6?   �� *	Telefono2+$ TwoWay=�{�6f   �� *	IsEnabled+6�   �� 5"     $��3��6    $��4��6-   $��
Telefono 3��6=   6T   �� 5#     -   5        $��3��5#  "   $��5��6/    . ��6?   �� *	Telefono3+$ TwoWay=�{�6f   �� *	IsEnabled+6�   �� 5%     $��4��6    $��0��6-   $��Celular��6=   6Q   �� 5&     -   5        $��4��5&  "   $��1��6/    . ��6?   �� *	Celular+$ TwoWay=�{�6d   �� *	IsEnabled+6�   �� 5(     $��4��6    $��2��6-   $	��Fax��6=   6M   �� 5)     -   5        $��4��5)  "   $��3��6/    . ��6?   �� *Fax+$ TwoWay=�{�6`   �� *	IsEnabled+6�   �� 5+     $��4��6    $��4��6-   $��E mail��6=   6P   �� 5,     $��4��6"   $��5��6/    . ��6?   �� *Email+$ TwoWay=�{�6b   �� *	IsEnabled+6�   5.     5/     �� 51     $��3��6   $��Condiciones de credito��6(   $��2q�6H   .��52     �  53     �� 54     $
��Auto �6,   6<   �� 55     $
��Auto �6,   6<   �� 56     $
��Auto �6,   6<   �� 57     $
��Auto �6,   6<   �� 58     $
��Auto �6,   6<   �� 59     $
��Auto �6,   6<   �� 5:     $
��Auto �6,   6<    5<     �� 5=     $
��Auto �6/   6>   �� 5>     $��* �6/   6;   �� 5?     $
��Auto �6/   6>   �� 5@     $��* �6/   6;   �� 5A     $
��Auto �6/   6>   �� 5B     $��* �6/   6;   .+�5E     �� $��0��6    $��0��6-   $��Dias de credito��6=   6Y   %  Xceed.Wpf.Toolkit.IntegerUpDown  5F     $��0��6/   $��1��6<   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]!   AutoSelectBehavior$! OnFocus=�6M   $��30��6j   $��90��5G     $��14(�6)   $
��Bold"�67   "   	Increment$" 1X�6J   $��Center=�6X   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]#   Minimum$# 0X�5H     ,	  &Xceed.Wpf.Toolkit.Primitives.InputBase$ 	  	Watermark$
$ Dias��6+   %   DefaultValue$% 1X�6<   &   Value& 5I     �� *DiasDeCredito+$ TwoWay=�$ PropertyChanged=��� 5N     $��0��6    $��2��6-   $��Saldo inicial��6=   6W   �� 5O     -   5        $��0��5O  "   $��3��6/    . ��6?   �� *SaldoInicial+$ TwoWay=�{�6i   �� *	IsEnabled+6�   �� 5Q     $��0��6    $��4��6-   $��Limite credito��6=   6X   �� 5R     -	   5        $��0��5R  "   $��5��6/    . ��6?   �� *LimiteDeCredito+$ TwoWay=�{�6l   �� *	IsEnabled+6�   �� 5T     $��1��6    $��4��6-   $��Saldo del cliente��6=   6[   �� 5U     $��1��6"   $��5��6/   {�.   . ��6?   �� *SaldoCliente+6�   �� 5W     $��2��6    $��4��6-   $��Saldo a favor��6=   6W   �� 5X     $��2��6"   $��5��6/   {�.   . ��6?   �� *SaldoAFavor+6�   �� 5Z     $��3��6    $��4��6-   $��Credito utilizado��6=   6[   �� 5[     $��3��6"   $��5��6/   {�.   . ��6?   �� *CreditoUtilizado+6�   �� 5]     $��4��6    $��4��6-   $��Total credito utilizado��6=   6a   �� 5^     $��4��6"   $��5��6/   {�.   . ��6?   �� *TotalCreditoUtilizado+6�   �� 5`     $��5��6    $��4��6-   $��Traspasos hasta por:��6=   6^   5b     5c     �� 5e     $��4��6   $!��Datos para uso de sitio Web��6(   $��2q�6M   .��5f     �  5g     �� 5h     $
��Auto �6,   6<    5j     �� 5k     $
��Auto �6/   6>   �� 5l     $��* �6/   6;   �� 5m     $
��Auto �6/   6>   �� 5n     $��* �6/   6;   �� 5o     $
��Auto �6/   6>   �� 5p     $��* �6/   6;   .+�5s     �� $��0��6    $��0��6-   $��Usuario��6=   6Q   �� 5t     $��0��6"   $��1��6/    . ��6?   �� *	Usuario+$ TwoWay=�{�6d   �� *	IsEnabled+6�   �� 5v     $��0��6    $��2��6-   $��Contraseña��6=   6T   �� 5w     $��0��6"   $��3��6/    . ��6?   �� *
Password+$ TwoWay=�{�6e   �� *	IsEnabled+6�   �� 5y     $��0��6    $��5��6-   $#��Permitir comprar por internet��6=   6g   �� 5z     $��0��6#   $��4��60   $��Center=�6z    6@   �� *PermitirComprasInternet+$ TwoWay=�{�6�   �� *	IsEnabled+6�   5|     5}     5     5�     5�     5�     