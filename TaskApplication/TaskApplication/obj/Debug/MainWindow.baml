   M S B A M L   `   `   `  ����J  FTaskApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TaskApplicationTaskApplication  5   	        TaskApplication.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,vmclr-namespace:TaskApplication     5   	     � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
MainWindow��5
   	   $	��550��6   $	��800��6)    � DataContext 5      '  !TaskApplication.ToDoListViewModel  5   
   .��5      � -   5        $��TaskViewGrid��5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��350 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   o� $��0��6   $��2��6   .@�5      m� $
��File��6   .@�5      m� $��Open Database��6   m� 5      $��New Database��6   m� 5      $��Archive Database��6   �� 5      m� 5       $
��Exit��6    m� Command 6)   �� *ExitApplicationCommand+5!      m� 5"      $	��TDL��6   .@�5#      m� $��Add Root TDL��6    61   �� *OpenAddToDoListWindowCommand+m� 5$      $��Add Sub-TDL��6   m� 5%      $
��Edit��6    6)   �� *ShowMessageCommand+m� 5&      $��Delete��6    6+   �� *ShowMessageCommand+�� 5'      m� 5(      $��Move Up��6   m� 5)      $��	Move Down��6   m� 5*      $��Change Path��6   5+      m� 5,      $
��Task��6   .@�5-      m� $	��Add��6    6(   �� *OpenAddTaskWindowCommand+m� 5.      $
��Edit��6    6)   �� *OpenEditTaskCommand+m� 5/      $��Delete��6    6+   �� *RemoveTaskCommand+m� 50      $��Set Done��6    6-   �� *DeleteCompletedTaskCommand+�� 51      m� 52      -   5        $��MoveUpMenuItem��52      $��Move Up��61    6B   �� *MoveUpTaskCommand+m� 53      -   5        $��MoveDownMenuItem��53      $��	Move Down��63    6F   �� *MoveDownTaskCommand+�� 54      m� 55      $��	Find Task��6    6.   �� *OpenFindTaskWindowCommand+56      m� 57      $
��View��6   .@�58      m� $
��Sort��6   .@�59      m� $��By Priority��6    64   �� *SortByPriorityCommand+m� 5:      $��By Deadline��6    64   �� *SortByDeadlineCommand+5;      m� 5<      $��Filter��6   .@�5=      m� $��By Category��6   .@�5>      m� $
��Work��6#    61   �� *FilterByWorkCategoryCommand+m� 5?      $��Personal��6#    65   �� *!FilterByPersonalCategoryCommand+m� 5@      $��School��6#    64   �� *FilterBySchoolCategoryCommand+m� 5A      $��Other��6#    62   �� *FilterByOtherCategoryCommand+5B      m� 5C      $��
Done tasks��6   m� 5D      $��Overdue tasks��6    67   �� * FilterByOverdueCategoryCommand+m� 5E      $��To-Do tasks��6    64   �� *FilterByToDoCategoryCommand+m� 5F      $��	All tasks��6    63   �� *ShwoAllTasksCommand+5G      5H      m� 5I      $
��Help��6   .@�5J      m� $��About��6    6*   �� *ShowAboutStudentCommand+5K      5L      R� 5O   
   -   5        $��
FolderList��5O      $��1��6%   $��0��62   ��6B   �� *ItemsCollection+��5P      �� 5Q       �� ItemsSource 6+   �� *SubCollection+.R�5R      ��  �� Orientation$ 
Horizontal=�6!   .+�5S      �� $��50��69   $��50��6D   ��6    �� *Image+6D   �� 5T      $��DemiBold"�67   $��25(�6M   ��6!   �� *Name+5U      5V      5W      5Y      �� 5[   
   -   5        $��TaskListListView��5[   0   $��1��6   $��1��6    ��6H   �� *FilteredTaskCollection+	 �� SelectedItem	 6w   �� *SelectedTask+��5\      �� 5]      
 �� 
TargetType"
 ��6   .�5^      ��  �� Property � �� �� Value
 ���� 67   �� 5_       � ��
 ���� 68    �� Triggers 5`      �� 5a       �� Binding 6*   �� *Done+ �� Value True6C   .a�5b   "   ��  � ��
 ���f�6?   �� 5c   "    � ��
 ���f�6@   �� 5d   "    � ��$ 1q�6D   5e      5g       �� View 5i      �� 5j      ! �� ColumnHeaderContainerStyle 5k      �� 5l      "
 ��6    .�5m      ��  �@J�IsHitTestVisible .  6A   5n      .P�5p      �� $��Check��6%    �� Width$ 40��64    �� CellTemplate 5q      �� 5r      .R�5s   "   �� $��DoneCheckBox��6+    d� 	IsChecked 6?   �� *Done+5t      5v      �� 5w      $��
Title Name��6%   $	 130��69    �� DisplayMemberBinding 6E   �� *Name+�� 5x      $��Priority��6%   $	 100��67    6C   �� *
Priority+�� 5y      $
��Type��6%   $ 50��63    6>   �� *Type+�� 5z      $��Deadline��6%   $	 160��67    6C   �� *
Deadline+�� 5{      $��Category��6%   $	 100��67    6C   �� *
Category+5|      5~      �� 5�   
   -   5        $��StatisticsTextBlock��5�      $��2��60   $��0��6=   $��10q�6M    6Y   �� *StatisticsCollection+� 5�       5�      �� 5�   
   $
��Auto �6   �� 5�   
    5�      �� 5�   
   $��25 �6   �� 5�   
   $��25 �6   �� 5�   
   $��25 �6   �� 5�   
   $��25 �6   �� 5�   
   $��25 �6   .+�5�      �� $��0��6   $��Done tasks: ��6   $��25��63   �� 5�      -   5        $��DoneTasksLabel��5�   V   $��1��6   $��38��6?   $��25��6J   ��6   �� *CompletedCount+6V   �� 5�      $��0��6   $��Tasks to be done: ��6   $��25��69   $��1��6E   �� 5�      -   5        $��ToDoTasksLabel��5�   P   $��1��6   $��38��69   $��25��6D   $��1��6f   ��6   �� *
AllCount+6f   �� 5�      $��0��6   $��Tasks due today: ��6   $��25��68   $��2��6D   �� 5�      -	   5        $��DueTodayTasksLabel��5�   U   $��1��6   $��38��6>   $��25��6I   $��2��6o   ��6   �� *DueTodayCount+6o   �� 5�      $��0��6   $��Tasks due tomorrow: ��6   $��25��6;   $��3��6G   �� 5�      -
   5        $��DueTomorrowTasksLabel��5�   X   $��1��6   $��38��6A   $��25��6L   $��3��6u   ��6   �� *DueTomorrowCount+6u   �� 5�      $��0��6   $��Tasks overdue: ��6   $��25��66   $��4��6B   �� 5�      -   5        $��OverdueTasksLabel��5�   T   $��1��6   $��38��6=   $��25��6H   $��4��6m   ��6   �� *OverdueCount+6m   5�      5�      �� 5�   
   -   5        $��TaskDescription��5�   1   $��2��6   $��1��6!   $��10,38,10,10q�5�   v   ��6   �� *SelectedItem.Description+ �� ElementName$ TaskListListView�� �� FallbackValue$ No task selected��5�      �� 5�   
   -   5        $��TitleDescriptionLabel��5�      $��2��6-   $+��%Selected task's notes and attachments��6:   $
��Left=�6j   $��10,5,0,0q�6�   $	��Top=�6�   $	��246��6�   $��28��6�   $��1��6�   5�      5�      