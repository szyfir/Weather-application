   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WeatherApp
WeatherApp  5   	       WeatherApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WeatherApp     5   	     � Title$  Aplikacja pogodowa��5   	   $
��500 ��6$   $
��1200��62    � WindowStartupLocation$ CenterScreen=�6?   $��Times New Roman)�6d    � 
ResizeMode$ NoResize=�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��40px �6   6,   �� 5      $	��3px �6   6+   �� 5      $��100px �6   6-   �� 5      $��5* �6   6*    � ColumnDefinitions 5   
   �� 5      $��6* �6   6,   �� 5      $��4* �6   6,   .+�5   
   �� -   5         ��Name$ backgroundImage��5      $��Images/slonce.jpg��6)   $
��Fill=�6D   $��2��6S   $��4��6g   � 5   
   $��1��6   
�������$��3��6/   6E   �� 5   
   $(��"Sprawdź pogodę w swoim mieście!��6   
�������$��20(�6M   $��0��6[   $��0��6h   $��2��6x   $��0,0,20,0q�6�   $��Right=�6�   6�   ]� 5   
   $��2��6   $��1��6!   $	��Top=�61   $��15q�6I   .+�5      �� -   5         ��Name$ tbSearch��5      $	��300��6(   $��30��65   $��20q�6A   $ ��Wpisz nazwę miejscowości��6M   $
��Left=�6m   $��Center=�6�   6�   �� 5      -   5         ��Name$ bSearch��5      $	��100��6&   $��30��62   $��Szukaj��6>   6g   5      ]� 5    
   $��2��6   $��0��6!   $	��Top=�61   .+�5!      �� -   5         ��Name$ 	lLocation��5!      $��Miejscowość��6'   
�������$��50(�6P   $��	20,20,0,0q�6^   $��Bottom=�6q   6�   5"      �� 5$   
   -   5        	 ��Name$		 gb1��5$      $��Pogoda dzisiaj��6    $��Times New Roman)�68   $��15(�6U   
�������$��3��6v   $��0��6�   $	��280��6�   $
��auto��6�   $��	20,0,30,0q�6�   $	��Top=�6�   .��5%      � .+�5&      �� -   5        $ lWind��5&      $��Wiatr:��6'   
�������$��25(�6K   $��0,47,561,166q�6Y   �� 5'      -   5        $ lActualWind��5'      $�� ��6-   
�������$��25(�6K   $��0,95,546,122q�6Y   �� 5(      -   5        $ 	lPressure��5(      $��Ciśnienie:��6+   
�������$��25(�6S   $��108,44,408,166q�6a   �� 5)      -	   5        $ lActualPressure��5)      $�� ��61   
�������$��25(�6O   $��108,95,408,122q�6]   $��Center=�6v   �� 5*      -
   5        $ 	lHumidity��5*      $��Wilgotność:��6+   
�������$��25(�6T   $��246,44,273,166q�6b   �� 5+      -   5        $ lActualHumidity��5+      $�� ��61   
�������$��25(�6O   $��246,95,283,122q�6]   $��Center=�6u   $��Center=�6�   �� 5,      -   5        $ lActualTemp��5,      $�� ��6-   
�������$��50(�6K   $��391,75,105,114q�6Y   $��Center=�6r   �� 5-      -   5        $ image1��5-      $	��100��6(   $��80��64   $��Right=�6@   $��554,62,0,114q�6W   $��Center=�6n   5.      5/      �� 50   
   $��Prognoza��6   $��Times New Roman)�6&   $��15(�6C   
�������$��3��6d   $��1��6q   $	��280��6�   $
��auto��6�   $��	20,0,30,0q�6�   $	��Top=�6�   .��51      � $	��Top=�6   .+�52      �� 
 �� Orientation$
 
Horizontal=�6   .+�53      �� -   5        $ lData��53      $��Data:��6+   
�������$��30��6N   $	��Top=�6Z   $��10q�6r   6�   �� 54      -   5        $ lData1��54      $�� ��6,   
�������$��30��6J   $	��Top=�6V   $��10q�6n   6|   55      �� 56      $
 
Horizontal=�6   $��30,40,0,183q�66   .+�57      �� -   5        $ lTemperature1��57      $�� ��63   $��20(�6>   
�������$��30��6_   �� 58      -   5        $ 
lPressure1��58      $�� ��60   $��20(�6;   
�������$��30��6]   �� 59      -   5        $ 
lHumidity1��59      $�� ��60   $��20(�6;   
�������$��30��6\   �� 5:      -   5        $ lVwind��5:      $�� ��6,   $��20(�67   
�������$��30��6X   �� 5;      -   5        $ icon1��5;      $��47��6+   $��51��67   5<      �� 5>      $
 
Horizontal=�6   $��0,80,0,0q�66   .+�5?      �� -   5        $ lData_2��5?      $��Data:��6-   
�������$��30��6P   $	��Top=�6\   $��10q�6t   6�   �� 5@      -   5        $ lData2��5@      $�� ��6,   
�������$��30��6J   $	��Top=�6V   $��10q�6n   6|   5A      �� 5B      $
 
Horizontal=�6   $��30,120,0,96q�66   .+�5C      �� -   5        $ lTemperature2��5C      $�� ��63   $��20(�6>   
�������$��30��6_   �� 5D      -   5        $ 
lPressure2��5D      $�� ��60   $��20(�6;   
�������$��30��6]   �� 5E      -   5        $ 
lHumidity2��5E      $�� ��60   $��20(�6;   
�������$��30��6\   �� 5F      -   5        $ lVwind2��5F      $�� ��6-   $��20(�68   
�������$��30��6Y   �� 5G      -   5        $ icon2��5G      $��47��6+   $��51��67   5H      �� 5J      $
 
Horizontal=�6   $��	0,160,0,0q�66   .+�5K      �� -   5        $ lData_3��5K      $��Data:��6-   
�������$��30��6P   $	��Top=�6\   $��10q�6t   6�   �� 5L      -   5        $ lData3��5L      $�� ��6,   
�������$��30��6J   $	��Top=�6V   $��10q�6n   6|   5M      �� 5N      $
 
Horizontal=�6   $��
30,200,0,0q�66   .+�5O      �� -   5        $ lTemperature3��5O      $�� ��63   $��20(�6>   
�������$��30��6_   �� 5P      -   5        $ 
lPressure3��5P      $�� ��60   $��20(�6;   
�������$��30��6]   �� 5Q      -    5        $ 
lHumidity3��5Q      $�� ��60   $��20(�6;   
�������$��30��6\   �� 5R      -!   5        $ lVwind3��5R      $�� ��6-   $��20(�68   
�������$��30��6Y   �� 5S      -"   5        $ icon3��5S      $��47��6+   $��51��67   5T      5U      5V      5]      5^      