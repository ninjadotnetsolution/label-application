   M S B A M L   `   `   `  ���� I  EInvoiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:InvoiceManager.ViewsInvoiceManager.Views  &     InvoiceManager.Views.ConnectPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:InvoiceManager.Views       N� Title$  ConnectPage�� � 	Resources  �� 
TargetType   
SaveButton  	newButton  DeleteButton  PrinterButton  btnTest �� CornerRadius  
btnConnect  btnResetpass  btnChangepass��%J  &	        &	 I     &	 �     &	 �     &	 (    &	 �    &	     &	 �    �� " ��.R��� $��Center=�$��Center=�$��/Resources/save as.png���� " ��.R��� $��Center=�$��Center=�$��/Resources/user_add.png���� " ��.R��� $��Center=�$��Center=�$��/Resources/deleteUser.png���� " ��.R��� $��Center=�$��Center=�$��/Resources/printer.png���� " ��.R��� $ 2��$��2q�
���  ��._��� $��Test Connection��$��Center=�$��Center=�$��20(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $��Connect��$��Center=�$��Center=�$��20(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $��Reset��$��Center=�$��Center=�$��20(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $��Change Password��$��Center=�$��Center=�$��20(�
���   �.���� .+��  � ColumnDefinitions �� $	��350 ��� $��* �.+��� -    ��Name$ allUsersBorder��$��0��$	��300�����	#3f4f4f4f$��0 30 0 0q� �� Padding$ 10q�._�� $
��Left=� � RowDefinitions �� $��35 ��� $��* �.+��� $��0 0 0 3q�
���   �._���  �� Orientation$ 
Horizontal=�.+��� $��My Connections��$	��150��$��20(��� -   	 ��Name$	 invoiceListView��$��1��$	��Top=�
������ $��0q�
������ $	��450��
 �� SelectedItem
 �� *SelectedConnect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . ���� *
Connects+$ TwoWay=� . $ PropertyChanged=����� .R��� 
���   �$��0 0 0 1q�._��� $	��250��$��18(����� *Label+� $��1��$��Center=�$	��800�� �� $	��150 ��� $��* �.+�� .+��  �� $	��130 ��� $��10 �.+��  �� $	��110 ��� $	��200 ��� $	��110 ��� $	��200 ��� $	��200 ��� $	��200 �.+��� $��0��$��
User Name:��$��20(�$��Bottom=��� $��1��  GeneralInput#��[ $��20(�$��Bottom=����� *
UserName+$ TwoWay=�$ PropertyChanged=��� $��2��$��	Password:��$��20(�$��Bottom=�$��20 0 0 0q�G� -   $��txtPassword��$��3�� 	 PasswordBox#��[	 $��20(� G� PasswordChar$ *��$��Bottom=�� $��1��$y�Hidden=� �� $	��150 ��� $	��100 ��� $	��200 ��� $	��150 ��� $��50 ��� $	��200 �.+��� $��0��$��New Password:��$��20(�$	��Top=�$��0,43,0,0q�G� -   $��newPassword��$��1��#��[	 $��20(�$ *��$��Bottom=��� $��2��$��Confirm Password:��$��20(�$��Bottom=�$��20 0 0 0q�G� -   $��cfmPassword��$��3��#��[	 $��20(�$ *��$��Bottom=��� $��5��$	��160��$��40��#��[ $��Center=�$	��Top=�$��0,30,0,0q����� *ResetPasswordCommand+�� $��1��
���   �$��2q�$��0 10 0 0q�$ 	15 0 15 0q�._��  �� $��70 ��� $��80 ��� $��80 ��� $��80 ��� $��80 ��� $��80 ��� $��80 �.+��  �� $	��150 ��� $	��300 �.+��� $��0��$��Label:��$��20(�$��Bottom=��� $��1��#��[ $��20(�$��Bottom=����� *Label+$ TwoWay=�$ PropertyChanged=� . � $��1�� �� $	��150 ��� $	��300 �.+��� $��0��$��Server:��$��20(�$��Bottom=��� $��1��#��[ $��20(�$��Bottom=����� *Server+$ TwoWay=�$ PropertyChanged=� . � $��2�� �� $	��150 ��� $	��300 �.+��� $��0��$��	Database:��$��20(�$��Bottom=��� $��1��#��[ $��20(�$��Bottom=����� *
Database+$ TwoWay=�$ PropertyChanged=� . � $��3�� �� $	��150 ��� $	��300 �.+��� $��0��$��
User Name:��$��20(�$��Bottom=��� $��1��#��[ $��20(�$��Bottom=����� *
DBUserName+$ TwoWay=�$ PropertyChanged=� . � $��4�� �� $	��150 ��� $	��300 �.+��� $��0��$��	Password:��$��20(�$��Bottom=�G� -   $��
dbPassword��$��1��#��[	 $ *��$��20(�$��Bottom=�� $��5�� �� $	��200 ��� $	��450 ��� $	��150 ��� $	��200 �.+��� $��0��$	��160��$��40��#��[ $��Center=�$��Bottom=����� *TestCommand+�� $��1��$	��120��$��40��#��[ $��Center=�$��Bottom=����� *ConnectCommand+]� $	��700��$	��200��$��
0 -900 0 0q�
������ $��Center=�$��Center=�y��� *IsProcessing+$ TwoWay=�$ PropertyChanged=� . .+��� $!��Connecting. Please Wait....��$��50(�
���   �$��Center=�