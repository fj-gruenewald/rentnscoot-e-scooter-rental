using System.Windows;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class RentalDetailFrame : Page
    {
        //Fields
        private readonly CvmMain _vmMain;

        #region Instance

        private static volatile RentalDetailFrame? instance = null;

        private static readonly object padlock = new object();

        internal static RentalDetailFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new RentalDetailFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal RentalDetailFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();
        }

        #endregion ctor

        #region Methods

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //set the rental ID
            txtRentalCode.Text = CvmMain.rental.RentalID;

            //Set the Payment Methods
            switch (CvmMain.rentingCustomer.CustomerPayment)
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
            Clipboard.SetText(CvmMain.rental.RentalID);
        }

        #endregion Methods
    }
}