   M S B A M L   `   `   `  ����I  EBookCollection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookCollectionBookCollection  5   	       BookCollection.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BookCollection     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedTabItem+.@�5      �� -   5        $��BookTab��5       � ContextMenu 5      �� 5      .@�5      m� $
��Edit��6#    m� Command 61   �� *
EditItem+6P   m� 5      $��Delete��6#    63   �� *
DeleteItem+6T   5      ��5      �� 5      Books6'   .��5      �� -   5        $��AllBooks_ListView��5      ��64   �� *
AllBooks+ 6U   �� *SelectedBook+ �� View 5      �� 5      .P�5      �� $
��Name��6]    �� Width$
 Auto��6k    �� DisplayMemberBinding 6-   ��  �� Path$ 	Book_Name�6z   �� 5      $
��Year��6X   $
 Auto��6f    6-   �� $
 Year�6u   �� 5      $��Genre��6Y   $
 Auto��6h    6-   �� $ Genre�	 �� CellTemplate	 5   "   �� 5    &   .R�5!   *   �� $��Color��64   
���������6X   �� *Genre+
 �� Triggers
 5"   *   �� 5#   .    �� Binding 6:   �� *Genre+.a�5$   2   ��  �� 
TargetName$ Color��69    �� Value red6M   5%   /   5'   '   5)      �� 5*      $��Author��6m   $
 Auto��6}    6-   �� $ BookAuthorSurname.Surname�6�   5+      5-      5.      �� 5/      -   5        $��	AuthorTab��5/       50      �� 51      .@�52      m� $
��Edit��6#    61   �� *
EditItem+6P   m� 53      $��Delete��6#    63   �� *
DeleteItem+6T   54      ��56      �� 57      	Authors6)   .��59      �� -   5        $��AllAuthors_ListView��59      ��66   �� *
AllAuthors+ 6Y   �� *SelectedAuthor+ 5:      �� 5;      .P�5<      �� $
��Name��6-   $
 Auto��6f    6;   �� $
 Name�6u   �� 5=      $��Surname��6-   $
 Auto��6l    6>   �� $ Surname�6{   5>      5@      5A      5B      �� 5C   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5D      �� -   5        $��Add_Book_Button��5D      $��Add Book��6,   ��6?   �� *OpenNewBook+6a   �� 5E      -   5        $��Add_Author_Button��5E      $��
Add Author��6.   ��6C   �� *OpenNewAuthor+6g   5F      �� 5G   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5H      �� -   5        $��LanguageBox��5H      $��0��6*   $��Right=�67   .��5I      �� $��Switch to Russian��6   67   5J      5K      5L      5M      