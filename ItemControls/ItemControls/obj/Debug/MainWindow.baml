   M S B A M L   `   `   `  ����G  CItemControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ItemControlsItemControls  5   	       ItemControls.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ItemControls     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � -   5         �Name$ mainGrid��5	       � ColumnDefinitions 5
   
   �� 5      �� 5      $
��.75* �6   .+�5   
   �� -   5         ��Name$ characterPanel��5      
����� �$��0��5      .+�5      �� -   5         ��Name$ characterList��5      $��	5,5,4.6,5q�5      ! �� IsDeferredScrollingEnabled .  � DataContext 5      �� *
characters+��5      �� 5      .R�5      �� $
��Left=�6%   .+�5      � $ comboboxGrid��6#    5   "   �� 5   &   $
��.75* �67   �� 5   &   .+�5   "   �� $	��100��5   $   $��70��5   $   $��0��5    $   ��5   (   �� *Avatar+5    $   �� 5!   "   $��Name: ��6(   $��1��5"   $   $��	5,5,50,60q�5#   $   �� 5$   "   $��Level: ��6(   $��1��5%   $   $��	5,20,50,0q�5&   $   �� 5'   "   $��1��5(   $   $��
45,5,50,60q�5)   $   ��5'   (   �� *Name+5)   $   �� 5*   "   $��1��5+   $   $��
45,20,50,0q�5,   $   ��5*   (   �� *Level+5,   $   5-      5.      5/      51      � 52      $	��200��6   $��10q�53       54      �� 55      �� 56       � RowDefinitions 58      �� 59      �� 5:      .+�5<      �� $
��Str:��6   $��0��5=      $��0��5>      $��18(�5?      
�������$��40,30,60,30q�5A      �� 5B      $
��Int:��6   $��1��5C      $��0��5D      $��18(�5E      
�������$��40,30,60,30q�5G      �� 5H      $
��Dex:��6   $��0��5I      $��1��5J      $��18(�5K      
�������$��40,30,55,30q�5M      �� 5N      $��Gold:��6   $��1��5O      $��1��5P      $��18(�5Q      
�������$��30,30,55,30q�5S      �� 5U      $��0��5V      $��0��5W      $��18(�5X      
�������$��80,30,25,30q�5Z      ��5U      ��  �� ElementName$ characterList��	 �� Path$	 SelectedItem.Strength�5Z      �� 5[      $��1��5\      $��0��5]      $��18(�5^      
�������$��80,30,25,30q�5`      ��5[      �� $ characterList��$	 SelectedItem.Intelligence�5`      �� 5a      $��0��5b      $��1��5c      $��18(�5d      
�������$��80,30,25,30q�5f      ��5a      �� $ characterList��$	 SelectedItem.Dexterity�5f      �� 5g      $��1��5h      $��1��5i      $��18(�5j      
�������$��80,30,15,30q�5l      ��5g      �� $ characterList��$	 SelectedItem.Gold�5l      5m      5n      �� 5o   
   -   5        $ invPanel��5o      
���P��$��1��5q      .+�5r      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 inventoryGrid��5r      $��8(�5s         AutoGenerateColumns .   .    Columns 5v      4  .System.Windows.Controls.DataGridCheckBoxColumn  5w      -   5        	Equip��,  &System.Windows.Controls.DataGridColumn   Header$ Equipped��5w   <   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *
Equipped+0  *System.Windows.Controls.DataGridTextColumn  5x      -   5        	Names��$
 Name��5x   8    6F   �� *Name+  5y      -   5        Effects��$ Effect��5y   :    6J   �� *Effect+  5z      -	   5        	Costs��$
 Cost��5z   8    6F   �� *Cost+5|      5}      5~      5      