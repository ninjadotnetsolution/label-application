   M S B A M L   `   `   `  ����I  EInvoiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InvoiceManager.ViewModelsInvoiceManager.ViewModels  5   	       InvoiceManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =	viewModel'clr-namespace:InvoiceManager.ViewModels     5   	     � AllowsTransparency  . 
������  � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��900��6   $
��1300��6)    � 	Resources 5       �� 
TargetType   btnPreNavigation  closeButton��%   &	        &	 �     �� 5   
   " ��6   .R�5      �� $��Center=�6   $��80��6/   $��Center=�6;   $��/Resources/leftArrow.png��6X   5      �� 5   
   " ��6   .R�5      �� $��Center=�6   $��50��6/   $��Center=�6;   $��/Resources/close.png��6X   5      5      .��5      ��  �� CornerRadius$ 30��6   
�������._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    �� 5       $��* �6    �� 5!      $��20 �6    .+�5$      � $��0��6    � ColumnDefinitions 5%      �� 5&      $	��150 �6'   �� 5'      $��* �6'   �� 5(      $	��150 �6'   .+�5*      �� $��0��6   $	��100��6)   #��[  65   ��6c   �� *PreNavigationCommand+6�   �� 5+      $��1��6   $��Labels Application��6,   $��50(�6F   $��Century Gothic)�6T   
���  ��$��Center=�6�   $��Center=�6�   �� 5,      $��2��6   $	��100��6)   #��[ 65   ��6^   �� *CloseCommand+6�   5-      �� 5/      $��1��6   
���   �$��0 2 0 0q�66   ._�51       � $y�Visible=�6�   	  � NavigationUIVisibility$	 Hidden=�6�   ��6   �� *	MainFrame+
 �� Mode$
 TwoWay=� �� NotifyOnSourceUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�6�   53      55      56      57      