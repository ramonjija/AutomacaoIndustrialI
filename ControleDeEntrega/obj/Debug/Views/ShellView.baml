   M S B A M L   `   `   `  ����L  HControleDeEntrega, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ControleDeEntrega.ViewsControleDeEntrega.Views  5   	   '    !ControleDeEntrega.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ControleDeEntrega.Views     5   	     � WindowStyle$
  None=�5       � 
ResizeMode$ NoResize=�6-    � Title$ 	ShellView��5   	   $	��600��6   $	��800��6(    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $! ../Content/ShellStyles.xaml?�6%   6J   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� 
�������$��0��6,   �� 5       $��0��6   $+��%Projeto Falir Spoleto - Versão 0.0.1��6$   $��Center=�6S   $��Center=�6n   
�������6�   �� 5!      $��1��6    �� Orientation$ 
Horizontal=�6)   $��RightToLeft=�6B   $��Right=�6^   .+�5"      �� -   5        	 ��Name$	 Close��5"   ?      CloseButton#���   6   .��6N   X6Q   5#      5$      � 5%   
   $��1��6   $	��300��6   $	��Top=�6)    5&      �� 5'      $��80 �6#   �� 5(      $��* �6#   �� 5)      $��80 �6#   .+�5+      �� -   5        
 ��Name$
 
ActiveItem��5+   -   $��1��6   .��5,      � .+�5-      �� -   5         ��Name$ Message��5-       $��Center=�61   $��Center=�6L   5.      5/      53      � 54   
   $��1��6   $	��235��6   $��Center=�6)   $��80,295,80,10q�6D   .+�55      �� -   5        $��lblRetireOPedido��55      $��Retire o Pedido��6,   $��Center=�6F   �� 56      -   5         ��Name$4 .___ControleDeEntrega_component_SetaEntrega_png��56      $��250,70,250,13q�6L   $2��,/ControleDeEntrega;component/SetaEntrega.png��6c   $
��Fill=�6�   $��Center=�6�   $��Center=�6�   57      59      �� 5:   
   
���   �$��2��6$   5;      5<      