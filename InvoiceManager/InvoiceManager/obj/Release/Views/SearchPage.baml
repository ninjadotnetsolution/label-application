   M S B A M L   `   `   `  ���� I  EInvoiceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InvoiceManager.ConvertersInvoiceManager.Converters  %    InvoiceManager.Views.SearchPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >
converters'clr-namespace:InvoiceManager.Converters       N� Title$  
SearchPage�� � 	Resources -   'InvoiceManager.Converters.DateConverter   DateConverter-   'InvoiceManager.Converters.TimeConverter  TimeConverter4   .InvoiceManager.Converters.PaymentTypeConverter  PaymentConverter �� 
TargetType �� Property �� Value �� 
TargetType  
SaveButton  	newButton  DeleteButton  PrinterButton  btnAllPrinter �� CornerRadius  
btnProcess 	 btnExit 
 	btnSearch  btnReset��%  &	        &	      &	 
     '��      &	 4     &	 }     &	 �     &	     &	 \    &	 �    &		 N    &	
 �    &	 ,          �� " ��.���  � ��
 ���� �� " ��.R��� $��Center=�$��Center=�$��/Resources/save as.png���� " ��.R��� $��Center=�$��Center=�$��/Resources/user_add.png���� " ��.R��� $��Center=�$��Center=�$��/Resources/deleteUser.png���� " ��.R��� $��Center=�$��Center=�$��/Resources/printer.png���� " ��.R��� $ 2��$��2q�
���  ��._��� $��All User Print��$��Center=�$��Center=�$��15(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $��Process Invoices��$��Center=�$��Center=�$��15(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $
��Exit��$��Center=�$��Center=�$��15(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $��Search��$��Center=�$��Center=�$��15(�
���   ��� " ��.R��� $ 2��$��2q�
���  ��._��� $��Reset��$��Center=�$��Center=�$��15(�
���   �.���� .+��  � RowDefinitions �� $��80 ��� $��* ��� $	��180 ��� $��60 �.+���  �� Orientation$ Vertical=�$��Center=�$
��1000��.+��� $��Invoice Search Options��$��20(��� 
���   �$��0 1 0 0q�._�� $��Center=�$
��1000��	 � ColumnDefinitions	 �� $��50 ��� $	��120 ��� $��50 ��� $	��120 ��� $	��130 ��� $	��200 ��� $	��100 ��� $	��100 �.+��� $��0��$��From:��$��15(�$��Bottom=�(  "System.Windows.Controls.DatePicker  $��1��$��15(�$��Bottom=�
   SelectedDate
 �� *From+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$	��To:��$��15(�$��Bottom=�$��20 0 0 0q�  $��3��$��15(�$��Bottom=�
 �� *To+$ TwoWay=�$ PropertyChanged=��� $��4��$��Payment Type:��$��15(�$��Bottom=�$��20 0 0 0q��� $��5��$��30��$��15(�$��Bottom=�
������ ���� *InvoiceTypes+ �� SelectedItem �� *SelectedType+$ TwoWay=�$ PropertyChanged=� �� NotifyOnSourceUpdated . ���� .R��� $��1q�
������ ���� �� $��6��$��0 3 0 0q�$��80��$��30��#��[ $��Center=�$��Bottom=����� *ResetCommand+�� $��7��$��0 3 0 0q�$��80��$��30��#��[
 $��Center=�$��Bottom=����� *SearchCommand+�� $��1��$ Vertical=�$��Center=�$
��1000��.+��� $��Invoice Details��$��20(��� -    ��Name$ allUsersBorder�����	#1f4f4f4f$ 2��._�� $��Center=� �� $��20 ��� $��* �.+��� $��0 0 0 2q����#4f4f4f._��� $ 
Horizontal=�.+��� $��Select��$��50��$��15(��� $��Number��$	��100��$��15(��� $
��Date��$	��200��$��15(��� $
��Time��$	��200��$��15(��� $
��Type��$	��100��$��15(��� $��Count��$	��100��$��15(��� $��
Mode Total��$	��100��$��15(��� $��Grand Total��$	��100��$��15(��� -    ��Name$ invoiceListView��$��1�� �� SelectionMode$ Multiple=�
������ $��0q�
������ $	��400������ *FilteredInvoices+$ TwoWay=� . $ PropertyChanged=����� .R��� ���#4f4f4f$��0 0 0 1q�._��� $ 
Horizontal=�.+��� $��50�� d� 	IsChecked �� *	Checked+$ TwoWay=�$ PropertyChanged=� . �� $	��100��$��15(����� *Number+�� $	��200��$��15(����� *
DateTime+ �� 	Converter# [  �� $	��200��$��15(����� *
DateTime+# [ �� $	��100��$��15(����� *Type+# [ �� $	��100��$��15(����� *	LineCount+�� $	��100��$��15(����� *	ModeTotal+�� $	��100��$��15(����� *
GrandTotal+�� $��2��$ Vertical=�$��Center=�$
��1000��.+�� 	 �� $	��500 ��� $	��500 �.+��  �� $��20 ��� $��* �.+��� $��Invoices Summary��$��20(�$
��Left=�$��Center=��� $��1��
���   �$��2q� �� Padding$ 10 0 0 0q�$��0 0 10 0q�._��  �� $��35 ��� $��35 ��� $��35 ��� $��35 �.+�� $��0��	 �� $	��180 ��� $	��180 �.+��� $��0��._��� $��Total Invoices��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *TotalSummary.TotalInvoicecs+� $��1��	 �� $	��180 ��� $	��180 �.+��� $��0��._��� $��Grand Total��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *TotalSummary.TotalGrand+� $��2��	 �� $	��100 ��� $	��150 ��� $	��100 ��� $	��150 �.+��� $��0��._��� $��	Credit %:��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *TotalSummary.Credit+�� $��2��._��� $��Cash %:��$��15(�$
��Left=�$��Center=��� $��3��._��� $��15(�$
��Left=�$��Center=����� *TotalSummary.Cash+� $��3��	 �� $	��100 ��� $	��150 ��� $	��100 ��� $	��150 �.+��� $��0��._��� $��Gift %:��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *TotalSummary.Gift+�� $��2��._��� $��Other %:��$��15(�$
��Left=�$��Center=��� $��3��._��� $��15(�$
��Left=�$��Center=����� *TotalSummary.Other+� $��1�� �� $��20 ��� $��* �.+��� $��Selected Invoices Summary��$��20(�$
��Left=�$��Center=��� $��1��
���   �$��2q�$ 10 0 0 0q�$��0 0 10 0q�._��  �� $��35 ��� $��35 ��� $��35 ��� $��35 �.+�� $��0��	 �� $	��180 ��� $	��180 �.+��� $��0��._��� $��Total Invoices:��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� * SelectedSummary.TotalInvoicecs+� $��1��	 �� $	��180 ��� $	��180 �.+��� $��0��._��� $��Grand Total:��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *SelectedSummary.TotalGrand+� $��2��	 �� $	��100 ��� $	��150 ��� $	��100 ��� $	��150 �.+��� $��0��._��� $��	Credit %:��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *SelectedSummary.Credit+�� $��2��._��� $��Cash %:��$��15(�$
��Left=�$��Center=��� $��3��._��� $��15(�$
��Left=�$��Center=����� *SelectedSummary.Cash+� $��3��	 �� $	��100 ��� $	��150 ��� $	��100 ��� $	��150 �.+��� $��0��._��� $��Gift %:��$��15(�$
��Left=�$��Center=��� $��1��._��� $��15(�$
��Left=�$��Center=����� *SelectedSummary.Gift+�� $��2��._��� $��Other %:��$��15(�$
��Left=�$��Center=��� $��3��._��� $��15(�$
��Left=�$��Center=����� *SelectedSummary.Other+�� $��3��$ 
Horizontal=�$��Center=�.+��� $	��140��$��40��#��[ $��10q�$��Center=����� *ProcessCommand+�� $��60��$��40��#��[	 $��10q�$��Center=����� *CloseCommand+]� $	��800��$	��200��$��
0 -900 0 0q�
������ $��Center=�y��� *IsProcessing+$ TwoWay=�$ PropertyChanged=� . .+��� $*��$Invoices Processing. Please Wait....��$��50(�
���   �$��Center=�