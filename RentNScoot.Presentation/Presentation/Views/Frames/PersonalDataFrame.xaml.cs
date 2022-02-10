using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class PersonalDataFrame : Page
    {
        //Fields

        private readonly CvmMain _vmMain;
        public static bool allFieldsSet = false;

        #region Instance

        private static volatile PersonalDataFrame? instance = null;

        private static readonly object padlock = new object();

        internal static PersonalDataFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new PersonalDataFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal PersonalDataFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();

            //Populate Combobox List
            combPayment.ItemsSource = new List<string> { Properties.Resources.PersonalData_PaymentMethod_Cash, Properties.Resources.PersonalData_PaymentMethod_UpFront, Properties.Resources.PersonalData_PaymentMethod_CreditCard, Properties.Resources.PersonalData_PaymentMethod_Klarna, Properties.Resources.PersonalData_PaymentMethod_Paypal };

            //Set Selected Combobox Item
            combPayment.SelectedValue = Properties.Resources.PersonalData_PaymentMethod_Cash;
        }

        #endregion ctor

        #region Methods

        //Handle new Selection Event for Combobox (Hints)
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (combPayment.SelectedValue.ToString())
            {
                case "Barzahlung":
                    txtHint.Text = Properties.Resources.PersonalData_PaymentMethod_Cash + ":";
                    txtHintText.Text = Properties.Resources.PersonalData_PaymentMethod_Cash_Hint;
                    break;

                case "Vorrauszahlung":
                    txtHint.Text = Properties.Resources.PersonalData_PaymentMethod_UpFront + ":";
                    txtHintText.Text = Properties.Resources.PersonalData_PaymentMethod_UpFront_Hint;
                    break;

                case "Kreditkarte":
                    txtHint.Text = Properties.Resources.PersonalData_PaymentMethod_CreditCard + ":";
                    txtHintText.Text = Properties.Resources.PersonalData_PaymentMethod_CreditCard_Hint;
                    break;

                case "Klarna":
                    txtHint.Text = Properties.Resources.PersonalData_PaymentMethod_Klarna + ":";
                    txtHintText.Text = Properties.Resources.PersonalData_PaymentMethod_Klarna_Hint;
                    break;

                case "Paypal":
                    txtHint.Text = Properties.Resources.PersonalData_PaymentMethod_Paypal + ":";
                    txtHintText.Text = Properties.Resources.PersonalData_PaymentMethod_Paypal_Hint;
                    break;
            }
        }

        //Handle the data in the fields
        private void CheckFieldsAndPopulate()
        {
            if (txtFirstName.Text.Length > 1 && txtLastName.Text.Length > 1 && txtPLZ.Text.Length > 1 && txtCity.Text.Length > 1 && txtStreet.Text.Length > 1 && txtHouseNumber.Text.Length > 0)
            {
                allFieldsSet = true;
                CvmMain.rentingCustomer = new Customer(txtFirstName.Text + " " + txtLastName.Text,
                    txtPLZ.Text + " " + txtCity.Text + ", " + txtStreet.Text + " " + txtHouseNumber.Text,
                    combPayment.SelectedValue.ToString());
            }
        }

        //Update and Check if Fields are Set
        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        private void txtPLZ_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        private void txtCity_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        private void txtStreet_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        private void txtHouseNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        private void combPayment_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckFieldsAndPopulate();
        }

        #endregion Methods
    }
}