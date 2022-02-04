using System.Windows;
using System.Windows.Controls;

namespace RentNScoot.Presentation.Views.Frames
{
    /// <summary>
    /// Interaktionslogik für RentalDetailFrame.xaml
    /// </summary>
    public partial class RentalDetailFrame : Page
    {
        public RentalDetailFrame()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //set the rental ID
            txtRentalCode.Text = OverviewFrame.rental.RentalID;

            //Set the Payment Methods
            switch (PersonalDataFrame.rentingCustomer.CustomerPayment)
            {
                case "Barzahlung":
                    txtHint.Text = Properties.Resources.PaymentMethod_Cash;
                    txtHintText.Text = Properties.Resources.RentalDetailFrame_PaymentMethodInfo_Cash;
                    break;

                case "Vorrauszahlung":
                    txtHint.Text = Properties.Resources.PaymentMethod_UpFront;
                    txtHintText.Text = Properties.Resources.RentalDetailFrame_PaymentMethodInfo_UpFront;
                    break;

                case "Kreditkarte":
                    txtHint.Text = Properties.Resources.PaymentMethod_Credit;
                    txtHintText.Text = Properties.Resources.RentalDetailFrame_PaymentMethodInfo_CreditCard;
                    break;

                case "Klarna":
                    txtHint.Text = Properties.Resources.PaymentMethod_Klarna;
                    txtHintText.Text = Properties.Resources.RentalDetailFrame_PaymentMethodInfo_Klarna;
                    break;

                case "Paypal":
                    txtHint.Text = Properties.Resources.PaymentMethod_Paypal;
                    txtHintText.Text = Properties.Resources.RentalDetailFrame_PaymentMethodInfo_Paypal;
                    break;
            }
        }

        //click the rental code --> copy to clipboard
        private void txtRentalCode_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(OverviewFrame.rental.RentalID);
        }
    }
}