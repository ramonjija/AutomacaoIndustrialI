   M S B A M L   `   `   `  ����K  GControleDePedido, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ControleDePedido.ViewsControleDePedido.Views  5   	   &     ControleDePedido.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ControleDePedido.Views     5   	     � WindowStyle$
  None=�5       � 
ResizeMode$ NoResize=�6-    � Title$ 	ShellView��5   	   $	��600��6   $	��800��6(    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $! ../Content/ShellStyles.xaml?�6%   6J   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        
�������$��0��5   ,   6<   �� 5      $��0��6   $+��%Projeto Falir Spoleto - Versão 0.0.1��6$   $��Center=�6S   $��Center=�6n   
�������6�   �� 5       $��1��6    �� Orientation$ 
Horizontal=�6)   $��RightToLeft=�6B   $��Right=�6^   .+�5!      �� -   5        	 ��Name$	 Close��5!   ?      CloseButton#���   6   .��6N   X6Q   5"      5#      � 5$   
   $��1��6    5%      �� 5&      $��80 �6#   �� 5'      $��* �6#   �� 5(      $��80 �6#   .+�5+      �� $��0��6   $��0q�6O   ��6%   �� *PreviousPanelColor+6O   �� 5,      $��2��6   $��0q�6K   ��6%   �� *NextPanelColor+6K   �� 5.      -   5        $	 Previous��5.   J   $��0��6   
 � Cursor$

 Hand��6\   $��Center=�6�   $��Center=�6�   $��50��5/      $��50��6      PreviousButton#��[ 6,   y�5.   %   �� *IsMassaPicker+��6j   �� *PreviousButtonColor+5/   ,   �� 51      -   5         ��Name$ 
ActiveItem��51   -   $��1��6   6-   �� 53      -   5        $	 Advance��53      $��2��6'   $

 Hand��67   $��Center=�6l   $��Center=�6�   $��50��6�   $��50��6�     AdvanceButton#��[ 6�   ��6E   �� *NextButtonColor+6�   54      �� 56   
   
���   �$��2��6$   57      58      