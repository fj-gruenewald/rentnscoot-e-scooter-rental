using RentNScoot.Presentation.ViewModels;
using System.Windows;
using System.Windows.Media;
using RentNScoot.Presentation.Views.Frames;

namespace RentNScoot.Presentation.Views
{
    public partial class CviMain : Window, IDialog
    {
        //Views

        private CvmMain _vmMain;
        private WelcomeFrame _welcomeFrame;
        private LocationFrame _locationFrame;
        private TimeFrame _timeFrame;
        private ScooterFrame _scooterFrame;
        private PersonalDataFrame _personalDataFrame;
        private OverviewFrame _overviewFrame;
        private RentalDetailFrame _rentalDetailFrame;
        private RentalReturnFrame _rentalReturnFrame;

        //Variables for Navigation

        private int pageIndex = 0;
        private int returnIndex = 0;
        private SolidColorBrush activeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#145DA0"));
        private SolidColorBrush inactiveColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#adafaa"));

        //colors

        private Color returnColor = (Color)ColorConverter.ConvertFromString("#145DA0");
        private Color solidgray = (Color)ColorConverter.ConvertFromString("#eeeeee");

        #region Instance

        private static volatile CviMain? instance = null;
        private static readonly object padlock = new object();

        internal static CviMain CreateSingleton(CvmMain vmMain, WelcomeFrame welcomeFrame, RentalReturnFrame rentalReturnFrame, LocationFrame locationFrame, TimeFrame timeFrame, ScooterFrame scooterFrame, PersonalDataFrame personalDataFrame, OverviewFrame overviewFrame, RentalDetailFrame rentalDetailFrame)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CviMain(vmMain, welcomeFrame, rentalReturnFrame, locationFrame, timeFrame, scooterFrame, personalDataFrame, overviewFrame, rentalDetailFrame);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        //Initialize CviMain
        private CviMain(CvmMain vmMain, WelcomeFrame welcomeFrame, RentalReturnFrame rentalReturnFrame, LocationFrame locationFrame, TimeFrame timeFrame, ScooterFrame scooterFrame, PersonalDataFrame personalDataFrame, OverviewFrame overviewFrame, RentalDetailFrame rentalDetailFrame)
        {
            _vmMain = vmMain;
            _welcomeFrame = welcomeFrame;
            _rentalReturnFrame = rentalReturnFrame;
            _locationFrame = locationFrame;
            _timeFrame = timeFrame;
            _scooterFrame = scooterFrame;
            _personalDataFrame = personalDataFrame;
            _overviewFrame = overviewFrame;
            _rentalDetailFrame = rentalDetailFrame;

            InitializeComponent();
            DataContext = vmMain;

            //Show start Frame
            contentFrame.Navigate(_welcomeFrame);
        }

        #endregion ctor

        #region Navigation

        //Logic for switching between the Frames
        private void bttnRent_Click(object sender, RoutedEventArgs e)
        {
            switch (pageIndex)
            {
                //we are on the welcome Page
                case 0:
                    contentFrame.Navigate(_locationFrame);
                    pageIndex++;

                    txtWelcomeMarker.Foreground = inactiveColor;
                    txtLocationMarker.Foreground = activeColor;

                    bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the location Page
                case 1:
                    if (CvmMain.rentingLocation.City.Length > 2)
                    {
                        contentFrame.Navigate(_timeFrame);
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
                        contentFrame.Navigate(_scooterFrame);
                        pageIndex++;

                        txtScooterMarker.Foreground = inactiveColor;
                        txtTimeMarker.Foreground = activeColor;

                        bttnReturn.Content = Properties.Resources.CviMain_Back_2;
                        bttnRent.Content = Properties.Resources.CviMain_Continue_2;

                        //TODO scooters that are rented are completely invisible, Check for Date in the Future and only Block scooters for their specific renting date
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_TimeFrame_NoAcceptedDateAlert);
                    }
                    break;

                //we are on the scooter Page
                case 3:
                    if (CvmMain.rentingScooter.Manufacturer.Length > 2)
                    {
                        contentFrame.Navigate(_personalDataFrame);
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
                        contentFrame.Navigate(_overviewFrame);
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
                    contentFrame.Navigate(_rentalDetailFrame);
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
                    _vmMain.PushCustomerToDb(CvmMain.rentingCustomer);
                    _vmMain.PushRentalToDb(CvmMain.rental, CvmMain.rentingScooter);

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
                    contentFrame.Navigate(_personalDataFrame);
                    pageIndex--;

                    txtPersonalDataMarker.Foreground = activeColor;
                    txtOverviewMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the PersonalDataFrame
                case 4:
                    contentFrame.Navigate(_scooterFrame);
                    pageIndex--;

                    txtTimeMarker.Foreground = activeColor;
                    txtPersonalDataMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the Scooter Frame
                case 3:
                    contentFrame.Navigate(_timeFrame);
                    pageIndex--;

                    txtScooterMarker.Foreground = activeColor;
                    txtTimeMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the Time Frame
                case 2:
                    contentFrame.Navigate(_locationFrame);
                    pageIndex--;

                    txtLocationMarker.Foreground = activeColor;
                    txtScooterMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_2;
                    break;

                //we are on the Location Frame
                case 1:
                    contentFrame.Navigate(_welcomeFrame);
                    pageIndex--;

                    txtWelcomeMarker.Foreground = activeColor;
                    txtLocationMarker.Foreground = inactiveColor;

                    bttnRent.Content = Properties.Resources.CviMain_Continue_1;
                    bttnReturn.Content = Properties.Resources.CviMain_Back_1;
                    break;

                //we are on the Welcome Frame
                case 0:
                    contentFrame.Navigate(_rentalReturnFrame);

                    SolidColorBrush returnBrush = new SolidColorBrush(returnColor);
                    gridSteps.Background = returnBrush;
                    txtLocationMarker.Foreground = activeColor;
                    txtTimeMarker.Foreground = activeColor;
                    txtScooterMarker.Foreground = activeColor;
                    txtPersonalDataMarker.Foreground = activeColor;
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
                    if (_vmMain.ReadRentalDataFromDb(_rentalReturnFrame.GetRentalCodeFromRentalReturnFrame()))
                    {
                        _rentalReturnFrame.RefreshFrame();
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

                        SolidColorBrush solidGrayBrush = new SolidColorBrush(solidgray);

                        bttnReturnRental.Visibility = Visibility.Hidden;
                        contentFrame.Navigate(_welcomeFrame);

                        gridSteps.Background = solidGrayBrush;
                        txtWelcomeMarker.Foreground = activeColor;
                        txtLocationMarker.Foreground = inactiveColor;
                        txtTimeMarker.Foreground = inactiveColor;
                        txtScooterMarker.Foreground = inactiveColor;
                        txtPersonalDataMarker.Foreground = inactiveColor;
                        txtOverviewMarker.Foreground = inactiveColor;

                        returnIndex = 0;
                        pageIndex = 0;

                        bttnRent.Visibility = Visibility.Visible;
                        bttnReturn.Visibility = Visibility.Visible;
                        _rentalReturnFrame.ResetFrame();
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.CviMain_Err_Payment);
                    }
                    break;
            }
        }

        #endregion Navigation
    }
}