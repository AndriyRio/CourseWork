   M S B A M L   `   `   `  ����E  ACoursework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Coursework.WindowsCoursework.Windows  5   	   )    #Coursework.Windows.NewPaymentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Coursework.Windows     5   	     � Title$  Новий платіж��5   	   $	��240��6   $	��400��6+    � 
ResizeMode$ NoResize=�5	   	   .��5
      � .+�5   
   �� -   5        $��14(�5      $��Додати��6   $
��Left=�60   $��125,140,0,0q�6K   $	��Top=�6`   $	��150��6x   $��35��6�   6�   �� 5   
   $��Дата платежу:��6   $��14(�6(   $
��Left=�67   $	��Top=�6R   $	��145��6j   $��30��6v   $��0,5,0,0q�6�   �� 5   
   $��Сума платежу:��6   $��14(�6(   $
��Left=�67   $	��Top=�6R   $	��145��6j   $��30��6v   $��0,35,0,0q�6�   �� 5   
   $ ��Спосіб оплати:��6   $��14(�6)   $
��Left=�68   $	��Top=�6S   $	��145��6k   $��30��6w   $��0,65,0,0q�6�   �� 5   
   $��Замовлення:��6   $��14(�6&   $
��Left=�65   $	��Top=�6P   $	��145��6h   $��30��6t   $��0,95,0,0q�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��PaymentDatePicker��5   0   $
��Left=�6   $��14(�6I   $��	152,0,0,0q�6X   $	��Top=�6k   $	��220��6�   $��30��6�   �� 5   
   -   5        $��OrderComboBox��5      $
��Left=�6(   $��
152,90,0,0q�6C   $	��Top=�6W   $	��220��6o   $��30��6{   �� 5   
   -   5        $��PaymentModeComboBox��5      $
��Left=�6.   $��
152,60,0,0q�6I   $	��Top=�6]   $	��220��6u   $��30��6�   �� 5   
   -   5        $��AmountPaidComboBox��5      $
��Left=�6,   $��
152,30,0,0q�6G   $	��Top=�6[   $	��220��6s   $��30��6   5      5      