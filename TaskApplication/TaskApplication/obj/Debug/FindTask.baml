   M S B A M L   `   `   `  ����J  FTaskApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TaskApplicationTaskApplication  5   	       TaskApplication.FindTask   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TaskApplication     5   	     � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ FindTask��5
   	   $	��450��6   $	��800��6'   .��5      �  � RowDefinitions 5   
   �� 5      $	��140 �6   �� 5      $��90 �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��searchIconImage��5      $��0��6   $
��Fill=�64   $��67,38,660,40q�6D   $��/Images/searchIcon.png��6Z   �� 5   
   $��0��6   $��	Find Task��6   $
��Left=�61   $��
166,27,0,0q�6L   $	��Top=�6`   $	��300��6x   $��Black"�6�   $��25(�6�   �� 5   
   $��0��6   $#��Find tasks in all to-do lists��6   $
��Left=�6E   $��
166,70,0,0q�6`   $	��Top=�6t   $	��300��6�   $��15(�6�   �� 5   
   -   5        $��findByNameTextBox��5      $��1��6+   $
��Left=�68   $��
136,10,0,0q�6S   $	��Top=�6g   $	��135��6   $��22��6�    �� TextWrapping$
 Wrap=�6�   ��6�   �� *Name+ �� Mode$ TwoWay=��� 5   
   $��Find by name: ��6   $
��Left=�6)   $��32,6,0,0q�6D   $��1��6V   $	��Top=�6c   $	��108��6{   $��Black"�6�   �� 5   
   $��Find by deadline: ��6   $
��Left=�6-   $��	290,6,0,0q�6H   $��1��6[   $	��Top=�6h   $	��108��6�   $��Black"�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��deadlineDatePicker��5      $
��Left=�6/   $��
415,10,0,0q�6J   $��1��6^   $	��Top=�6k   $��22��6�   $	��108��6�      SelectedDate 6�   �� *SelectedDate+�� 5   
   -   5        $��numberOfFoundTasksLabel��5      $��0��6   $��25��6;   $��30��6G   $��204,55,566,10q�6R   $��1��6i   $
��Bold"�6v   �� 5   
   -   5        $��textFoundTasksLabel��5   1   $��Number of items found:��6   $��25��6L   $��32,55,606,10q�6X   $��Black"�6n   $��1��6�   $��12(�6�   �� 5   
   $
��Find��6   
�������$
��Left=�6[   $��
654,55,0,0q�6v   $��1��6�   $	��Top=�6�   $��20��6�   $	��109��6�   |�. 
���������6    �� *FindTaskCommand+6�   �� 5   
   $��Close ��6   
�������$
��Left=�6i   $��
654,12,0,0q�6�   $	��Top=�6�   $��20��6�   $	��109��6�   
���������6#   �� *CloseFindTaskWindowCommand+6�   �� 5    
   -   5        $��FindTaskListListView��5    =   $��2��6   $��Center=�6    $��
0,19,0,-49q�6   ��6Y   �� *FilteredTasks+ �� View 5!      �� 5"      ! �� ColumnHeaderContainerStyle 5#      �� 5$      	 �� 
TargetType"	 ��6    .�5%      �� 
 �� Property
 �@J�IsHitTestVisible �� Value .  6A   5&      .P�5(      �� $��
Title Name��6%    �� Width$	 130��69    �� DisplayMemberBinding 6E   �� *Name+�� 5)      $��Deadline��6%   $	 220��67    6C   �� *
Deadline+5*      5,      5.      5/      