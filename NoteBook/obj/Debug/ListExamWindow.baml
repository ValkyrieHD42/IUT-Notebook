   M S B A M L   `   `   `  ����C  ?NoteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NoteBookNoteBook  5   	       NoteBook.ListExamWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NoteBook     5   	   -   5          �Name$  ListExamWindow1��5   	    � Title$ Liste des examens��5   	   $��611.6��6#   $	��800��62   .��5	      � .+�5
   
   �� -   5         ��Name$ exams��5
      $	��347��6!   $��	30,36,0,0q�6.   $	��Top=�6A   $��Stretch=�6Y   $
��Left=�6~   $	��723��6�   $��12q�6�   ���	#FF5E81EA��5      �� 5      .R�5      ]� ��. .+�5      � $	��Top=�6   $��30��64   
������ � ColumnDefinitions 5      �� 5   "   $��* �63   �� 5   "   $��* �63   �� 5   "   $��* �63   �� 5   "   $��* �63   .+�5      �� 
�������$��0��67   .��6G   Date6M   �� 5      
�������$��1��67   .��6G   Module6O   �� 5      
�������$��2��67   .��6G   	Teacher6P   �� 5      
�������$��3��67   .��6G   Score6N   5      �� 5      6+   5      5      ��5!      �� 5"      .R�5#      �  5$      �� 5%      $��* �6/   �� 5&      $��* �6/   �� 5'      $��* �6/   �� 5(      $��* �6/   .+�5*      �� $��0��6    ��60   �� *
DateExam+�� 5+      $��1��6    ��60   �� *Module.Name+�� 5,      $��2��6    ��60   �� *	Teacher+�� 5-      $��3��6    ��60   �� *Score+5.      5/      51      �� 52   
   -   5        $ scores��52      $
��Left=�6"   $	��137��6=   $��
30,414,0,0q�6J   $	��Top=�6^   $	��723��6v   �� 53   
   -   5         ��Name$ 	removeBtn��53      $��	Supprimer��6$   $
��Left=�68   $��
678,10,0,0q�6S   $	��Top=�6g   $��75��6   6�   55      56      