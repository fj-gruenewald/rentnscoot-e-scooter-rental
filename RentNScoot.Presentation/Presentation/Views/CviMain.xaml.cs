using System.Collections.Generic;
using RentNScoot.Presentation.ViewModels;
using System.Windows;
using System.Windows.Media;
using Renci.SshNet.Messages;
using RentNScoot.Presentation.Views.Frames;

namespace RentNScoot.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CviMain.xaml
    /// </summary>
    public partial class CviMain : Window, IDialog
    {
        //ViewModel
        private CvmMain _vmMain;

        //Variables for the page navigation

        private int pageIndex = 0;
        private int returnIndex = 0;
        private SolidColorBrush activeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#145DA0"));
        private SolidColorBrush inactiveColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#adafaa"));

        //Initialize Frames

        private WelcomeFrame welcomeFrame = new WelcomeFrame();
        private LocationFrame locationFrame = new LocationFrame();
        private ScooterFrame scooterFrame = new ScooterFrame();
        private TimeFrame timeFrame = new TimeFrame();
        private PersonalDataFrame personalDataFrame = new PersonalDataFrame();
        private OverviewFrame overviewFrame = new OverviewFrame();
        private RentalDetailFrame rentalDetailFrame = new RentalDetailFrame();
        private RentalReturnFrame rentalReturnFrame = new RentalReturnFrame();

        //colors
        private Color returnColor = (Color)ColorConverter.ConvertFromString("#145DA0");

        private static volatile CviMain? instance = null;
        private static readonly object padlock = new object();

        internal static CviMain CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CviMain(vmMain);
                return instance;
            }
        }

        //Initialize CviMain
        private CviMain(CvmMain vmMain)
        {
            _vmMain = vmMain;

            InitializeComponent();
            DataContext = vmMain;

            //Show start Frame
            contentFrame.Navigate(welcomeFrame);
        }

        private void StartProcess(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        //Logic for switching between the Frames
        private void bttnRent_Click(object sender, RoutedEventArgs e)
        {
            switch (pageIndex)
            {
                //we are on the welcome Page
                case 0:
                    contentFrame.Navigate(locationFrame);
                    pageIndex++;

                    txtWelcomeMarker.Foreground = inactiveColor;
                    txtLocationMarker.Foreground = activeColor;

                    bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the location Page
                case 1:
                    if (LocationFrame.rentingLocation.City.Length > 2)
                    {
                        contentFrame.Navigate(timeFrame);
                        pageIndex++;

                        txtLocationMarker.Foreground = inactiveColor;
                        txtScooterMarker.Foreground = activeColor;

                        bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                        bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_LocationFrame_ChooseAnOptionAlert);
                    }
                    break;

                //we are on the time Page
                case 2:
                    if (TimeFrame.dateAccepted)
                    {
                        contentFrame.Navigate(scooterFrame);
                        pageIndex++;

                        txtScooterMarker.Foreground = inactiveColor;
                        txtTimeMarker.Foreground = activeColor;

                        bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                        bttnRent.Content = Properties.Resources.CviMain_Continue_2;

                        //Populate Scooter List for next Frame
                        //TODO scooters that are rented are completely invisible, Check for Date in the Future and only Block scooters for their specific renting date
                        _vmMain.GetScooterListToLocation(LocationFrame.rentingLocation);
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_TimeFrame_NoAcceptedDateAlert);
                    }
                    break;

                //we are on the scooter Page
                case 3:
                    if (ScooterFrame.rentingScooter.Manufacturer.Length > 2)
                    {
                        contentFrame.Navigate(personalDataFrame);
                        pageIndex++;

                        txtTimeMarker.Foreground = inactiveColor;
                        txtPersonalDataMarker.Foreground = activeColor;

                        bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                        bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_ScooterFrame_ChooseAnOptionAlert);
                    }
                    break;

                //we are on the personal Data Page
                case 4:
                    if (PersonalDataFrame.allFieldsSet)
                    {
                        contentFrame.Navigate(overviewFrame);
                        pageIndex++;

                        txtPersonalDataMarker.Foreground = inactiveColor;
                        txtOverviewMarker.Foreground = activeColor;

                        bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                        bttnRent.Content = Properties.Resources.CviMain_Continue_3;
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_PersonalDataFrame_NotAllFieldsSetAlert);
                    }
                    break;

                //we are on the rental Code Page
                case 5:
                    contentFrame.Navigate(rentalDetailFrame);
                    pageIndex++;

                    txtWelcomeMarker.Foreground = activeColor;
                    txtLocationMarker.Foreground = activeColor;
                    txtScooterMarker.Foreground = activeColor;
                    txtTimeMarker.Foreground = activeColor;
                    txtPersonalDataMarker.Foreground = activeColor;
                    txtOverviewMarker.Foreground = activeColor;

                    bttnReturn.Visibility = Visibility.Hidden;
                    bttnRent.Content = Properties.Resources.CviMain_Continue_4;

                    //push the Customer and Rental Objects to the DB
                    _vmMain.PushCustomerToDb(PersonalDataFrame.rentingCustomer);
                    _vmMain.PushRentalToDb(OverviewFrame.rental, ScooterFrame.rentingScooter);

                    break;

                case 6:
                    this.Close();
                    break;
            }
        }

        private void bttnReturn_Click(object sender, RoutedEventArgs e)
        {
            switch (pageIndex)
            {
                //we are on the RentalDetail frame
                case 5:
                    contentFrame.Navigate(personalDataFrame);
                    pageIndex--;

                    txtPersonalDataMarker.Foreground = activeColor;
                    txtOverviewMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the PersonalDataFrame
                case 4:
                    contentFrame.Navigate(scooterFrame);
                    pageIndex--;

                    txtTimeMarker.Foreground = activeColor;
                    txtPersonalDataMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the Scooter Frame
                case 3:
                    contentFrame.Navigate(timeFrame);
                    pageIndex--;

                    txtScooterMarker.Foreground = activeColor;
                    txtTimeMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the Time Frame
                case 2:
                    contentFrame.Navigate(locationFrame);
                    pageIndex--;

                    txtLocationMarker.Foreground = activeColor;
                    txtScooterMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the Location Frame
                case 1:
                    contentFrame.Navigate(welcomeFrame);
                    pageIndex--;

                    txtWelcomeMarker.Foreground = activeColor;
                    txtLocationMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_1;
                    bttnReturn.Content = Properties.Resources.CviMain_Back_1;
                    break;

                //we are on the Welcome Frame
                case 0:
                    contentFrame.Navigate(rentalReturnFrame);

                    SolidColorBrush returnBrush = new SolidColorBrush(returnColor);
                    gridSteps.Background = returnBrush;
                    txtTimeMarker.Foreground = activeColor;
                    txtScooterMarker.Foreground = activeColor;
                    txtPersonalDataMarker.Foreground = activeColor;
                    txtLocationMarker.Foreground = activeColor;
                    txtOverviewMarker.Foreground = activeColor;

                    bttnRent.Visibility = Visibility.Hidden;
                    bttnReturn.Visibility = Visibility.Hidden;

                    bttnReturnRental.Visibility = Visibility.Visible;
                    bttnReturnRental.Content = Properties.Resources.CviMain_RentalResult_RentalCode;
                    break;
            }
        }

        //Handle Rental Return
        private void bttnReturnRental_Click(object sender, RoutedEventArgs e)
        {
            switch (returnIndex)
            {
                //Load Rental Return Data
                case 0:
                    if (_vmMain.ReadRentalDataFromDb(rentalReturnFrame.GetRentalCodeFromRentalReturnFrame()))
                    {
                        rentalReturnFrame.RefreshFrame();
                        bttnReturnRental.Content = Properties.Resources.CviMain_RentalResult_Back;
                        returnIndex++;
                    }
                    break;

                //If everything happened delete the Rental Entry
                case 1:

                    //TODO Implement Var that Checks for Payment
                    //Using your Payment provider Check for a Valid Payment
                    bool payment = true;

                    if (payment)
                    {
                        //TODO delete Rental or Put on notActive in this Case it gets deleted to save Server Space
                        _vmMain.DeleterentalAfterReturn(CvmMain.rentalData.Rental);

                        bttnReturnRental.Visibility = Visibility.Hidden;
                        contentFrame.Navigate(welcomeFrame);
                        returnIndex = 0;
                        pageIndex = 0;
                        bttnRent.Visibility = Visibility.Visible;
                        bttnReturn.Visibility = Visibility.Visible;
                        rentalReturnFrame.ResetFrame();
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_Err_Payment);
                    }
                    break;
            }
        }
    }
}