using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Controls.Cards
{
    public partial class LocationCard : UserControl
    {
        //Fields

        private Location location;
        private bool isClicked = false;

        //Brushes

        private Color bgColor = (Color)ColorConverter.ConvertFromString("#176ebd");
        private Color hoverColor = (Color)ColorConverter.ConvertFromString("#1a7dd7");
        private Color clickedColor = (Color)ColorConverter.ConvertFromString("#104a80");

        #region ctor

        public LocationCard()
        {
            InitializeComponent();
        }

        #endregion ctor

        #region Methods

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Get the binding from the usercontrol tag
            UserControl userControl = sender as UserControl;
            location = (Location)userControl.Tag;

            //Set The Card Text
            txtLocationPostal.Text = location.Postal.ToString();
            txtLocation.Text = location.City;
            txtLocationDetails.Text = location.Street + " " + location.StreetNr;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isClicked)
            {
                SolidColorBrush hoverBrush = new SolidColorBrush(hoverColor);
                recBackground.Fill = hoverBrush;
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!isClicked)
            {
                SolidColorBrush bgBrush = new SolidColorBrush(bgColor);
                recBackground.Fill = bgBrush;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SolidColorBrush clickedBrush = new SolidColorBrush(clickedColor);

            if ((CvmMain.rentingLocation.City.Length > 2) == false || CvmMain.rentingLocation.LocationID == location.LocationID)
            {
                recBackground.Fill = clickedBrush;

                if (isClicked)
                {
                    isClicked = false;
                    CvmMain.rentingLocation = new Location("1", 1, "1", "1", "1");
                }
                else
                {
                    isClicked = true;
                    CvmMain.rentingLocation = location;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.LocationFrame_TooManLocationsAlert);
            }
        }

        #endregion Methods
    }
}