   M S B A M L   `   `   `  ���� E  ACoursework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Coursework.WindowsCoursework.Windows  '    !Coursework.Windows.NewOrderWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:Coursework.Windows       � Title$-  'Додавання замовлення��$	��230��$	��400�� � 
ResizeMode$ NoResize=�.��� .+��� -   $��Додати��$
��Left=�$��125,140,0,0q�$	��Top=�$	��150��$��35���� $$��Дата замовлення:��$��14(�$
��Left=�$	��Top=�$	��145��$��30��$��0,5,0,0q��� $��Дата оплати:��$��14(�$
��Left=�$	��Top=�$	��145��$��30��$��0,35,0,0q��� $��Скидка:��$��14(�$
��Left=�$	��Top=�$	��145��$��30��$��0,65,0,0q��� $��Клієнт:��$��14(�$
��Left=�$	��Top=�$	��145��$��30��$��0,95,0,0q�(  "System.Windows.Controls.DatePicker  -   $��OrderDatePicker��$
��Left=�$��14(�$��	152,0,0,0q�$	��Top=�$	��220��$��30���� -   $��DiscountTextBox��$��14(�$
��Left=�$��
152,60,0,0q� �� TextWrapping$
 Wrap=�$	��220��$��30��$	��Top=�  -   $��PayDatePicker��$��14(�$
��Left=�$��
152,30,0,0q�$	��220��$��30��$	��Top=��� -   $��ClientComboBox��$��14(�$
��Left=�$��
152,90,0,0q�$	��Top=�$	��220��$��30��