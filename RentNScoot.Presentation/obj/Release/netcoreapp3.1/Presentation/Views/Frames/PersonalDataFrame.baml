   M S B A M L   `   `   `  ���� R  NRentNScoot.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:RentNScoot.Presentation.Views.Frames$RentNScoot.Presentation.Views.Frames  =#clr-namespace:RentNScoot.PropertiesRentNScoot.Properties  <    6RentNScoot.Presentation.Views.Frames.PersonalDataFrame   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlocal2clr-namespace:RentNScoot.Presentation.Views.Frames     7strings#clr-namespace:RentNScoot.Properties     X TXceed.Wpf.Toolkit, Version=4.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    N� Title$  PersonalDataFrame��.���  � RowDefinitions �� $��1* ��� $��6* �.+��� $��0��%   RentNScoot.Properties.Resources   PersonalData_Headline#��Z $��28(� �� TextAlignment$ Center=�$��Center=�� $��2�� �� $��1* ��� $��1* ��� $��1* � � ColumnDefinitions �� $��2* ��� $��2* �.+��� $��0��$��0��$��2�����#eeeeee$��10,10,10,10q� �� Orientation$ 
Horizontal=�.+��� .+���    PersonalData_FirstName#��Z $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ txtFirstName��$   PersonalData_FirstNameExample	   	Watermark#	 Z $	��250��$��18(�$	��Top=�$
��Left=�$��10,0,5,5q��� .+��� 
   PersonalData_SeconName#��Z
 $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q�  -   $ txtLastName��%   PersonalData_SecondNameExample#	 Z $	��280��$��18(�$	��Top=�$
��Left=�$��10,0,5,5q��� $��1��$��0��$��2�����#eeeeee$��10,10,10,10q�$ 
Horizontal=�.+��� .+���    PersonalData_PostalCode#��Z $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q�  -   $ txtPLZ��&   PersonalData_PostalCode_Example#	 Z $��80��$��18(�$	��Top=�$
��Left=�$��10,0,5,5q��� .+���    PersonalData_City#��Z $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q�  -   $ txtCity��   PersonalData_CityExample#	 Z $	��200��$��18(�$	��Top=�$
��Left=�$��10,0,5,5q��� .+���    PersonalData_Street#��Z $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q�  -   $ 	txtStreet��!   PersonalData_StreetExample#	 Z $	��280��$��18(�$	��Top=�$
��Left=�$��10,0,5,5q��� .+���    PersonalData_Number#��Z $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q�  -   $ txtHouseNumber��!   PersonalData_NumberExample#	 Z $	��100��$��18(�$	��Top=�$
��Left=�$��10,0,5,5q��� $��2��$��0�����#eeeeee$��10,10,10,10q�.+��� !   PersonalData_PaymentMethod#��Z $��18(�$	��Top=�$
��Left=�$��
10,10,10,5q��� -    ��Name$ combPayment��$	��200��$��16(�$	��Top=�$
��Left=�$��10,0,5,5q��� $��2��$��1�����#176ebd$��10,10,10,10q�.+��� -    ��Name$ txtHint��$��Barzahlung:��$��16(�
�������$	��Top=�$
��Left=�$��
10,10,10,5q��� -	   $ txtHintText��$w��qBezahlen sie bei der Abholung ihres Scooters im Laden.                            Mit EC-Karte sowie mit Bargeld.��
�������$
��Wrap=�$��14(�$	��Top=�$
��Left=�$��10,0,5,5q�