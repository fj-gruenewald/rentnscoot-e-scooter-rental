using System.Windows;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    /// <summary>
    /// Interaktionslogik für OverviewFrame.xaml
    /// </summary>
    public partial class OverviewFrame : Page
    {
        //Fields

        private readonly CvmMain _vmMain;

        #region Instance

        private static volatile OverviewFrame? instance = null;

        private static readonly object padlock = new object();

        internal static OverviewFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new OverviewFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal OverviewFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();
        }

        #endregion ctor

        #region Methods

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Setting all the TextBoxes
            txtSelectedLocation.Text = CvmMain.rentingLocation.Postal + " " + CvmMain.rentingLocation.City + ", " + CvmMain.rentingLocation.Street + " " + CvmMain.rentingLocation.StreetNr;
            txtSelectedScooter.Text = CvmMain.rentingScooter.Manufacturer + " " + CvmMain.rentingScooter.Model;
            txtSelectedTimespanFrom.Text = CvmMain.rentingTime.CollectTime.ToString();
            txtSelectedTimespanTo.Text = CvmMain.rentingTime.GiveOffTime.ToString();

            txtNameData.Text = CvmMain.rentingCustomer.CustomerName;
            txtAddressData.Text = CvmMain.rentingCustomer.CustomerAddress;
            txtPaymentData.Text = CvmMain.rentingCustomer.CustomerPayment;

            //Create the Rental Object
            CvmMain.rental = new Rental(CvmMain.rentingCustomer.CustomerID,
                CvmMain.rentingLocation.LocationID, CvmMain.rentingScooter.ScooterID,
                CvmMain.rentingTime.CollectTime.ToString(), CvmMain.rentingTime.GiveOffTime.ToString());

            //Set the Rentable Status of the Scooter
            CvmMain.rentingScooter.Rentable = 0;
        }

        #endregion Methods
    }
}