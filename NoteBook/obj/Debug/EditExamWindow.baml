   M S B A M L   `   `   `  ����C  ?NoteBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NoteBookNoteBook  5   	       NoteBook.EditExamWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NoteBook     5   	     � Title$$  Ajout ou modification d'examen��5   	   $	��332��60   $	��564��6=   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� $��Module :��6   $
��Left=�6#   $��	47,38,0,0q�6>   $	��Top=�6Q   $��26��6i   $��57��6u   �� 5   
   -   5         ��Name$ 	moduleBox��5      $
��Left=�6&   $��
109,42,0,0q�6A   $	��Top=�6U   $	��120��6m   $��22��6y   �� 5   
   -   5         ��Name$ isAbsentBox��5      $��Absent��6(   $
��Left=�69   $��	47,95,0,0q�6T   $	��Top=�6g   $��15��6   $��57��6�   6�   �� 5   
   $��Score��6   $
��Left=�6    $��
47,142,0,0q�6;   $	��Top=�6O   $��26��6g   $��39��6s   �� 5   
   $��Date :��6   $
��Left=�6!   $��
291,38,0,0q�6<   $	��Top=�6P   $��26��6h   $��41��6t   �� 5   
   $��Teacher��6   $
��Left=�6"   $��
291,89,0,0q�6=   $	��Top=�6Q   $��26��6i   $��50��6u   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dateBox��5      $
��Left=�6&   $��
354,39,0,0q�6A   $	��Top=�6U   $��24��6m   $	��149��6y   �� 5   
   -   5         ��Name$ scoreBox��5      $
��Left=�6$   $��23��6?   $��122,146,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $��0��6t   $	��Top=�6}   $	��107��6�   �� 5   
   -   5        $ 
teacherBox��5      $
��Left=�6&   $��23��6A   $��
354,92,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��149��6�   �� 5   
   -   5        $��Validate��5      $
��Left=�6$   $��154,236,0,0q�6?   $	��Top=�6T   $��75��6l   6w   �� 5   
   -   5        $��Cancel��5      $
��Left=�6"   $��291,236,0,0q�6=   $	��Top=�6R   $��75��6j   6u   5      5      