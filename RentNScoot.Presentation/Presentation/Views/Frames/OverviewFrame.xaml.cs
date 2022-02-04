using System.Windows;
using System.Windows.Controls;

namespace RentNScoot.Presentation.Views.Frames
{
    /// <summary>
    /// Interaktionslogik für OverviewFrame.xaml
    /// </summary>
    public partial class OverviewFrame : Page
    {
        public static Rental rental;

        public OverviewFrame()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Setting all the TextBoxes
            txtSelectedLocation.Text = LocationFrame.rentingLocation.Postal + " " + LocationFrame.rentingLocation.City + ", " + LocationFrame.rentingLocation.Street + " " + LocationFrame.rentingLocation.StreetNr;
            txtSelectedScooter.Text = ScooterFrame.rentingScooter.Manufacturer + " " + ScooterFrame.rentingScooter.Model;
            txtSelectedTimespanFrom.Text = TimeFrame.rentingTime.CollectTime.ToString();
            txtSelectedTimespanTo.Text = TimeFrame.rentingTime.GiveOffTime.ToString();

            txtNameData.Text = PersonalDataFrame.rentingCustomer.CustomerName;
            txtAddressData.Text = PersonalDataFrame.rentingCustomer.CustomerAddress;
            txtPaymentData.Text = PersonalDataFrame.rentingCustomer.CustomerPayment;

            //Create the Rental Object
            rental = new Rental(PersonalDataFrame.rentingCustomer.CustomerID,
                LocationFrame.rentingLocation.LocationID, ScooterFrame.rentingScooter.ScooterID,
                TimeFrame.rentingTime.CollectTime.ToString(), TimeFrame.rentingTime.GiveOffTime.ToString());

            //Set the Rentable Status of the Scooter
            ScooterFrame.rentingScooter.Rentable = 0;
        }
    }
}