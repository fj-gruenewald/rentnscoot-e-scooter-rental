using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using RentNScoot.Presentation.Views.Frames;

namespace RentNScoot.Presentation.Controls.Cards
{
    /// <summary>
    /// Interaktionslogik für LocationCard.xaml
    /// </summary>
    public partial class LocationCard : UserControl
    {
        //Fields

        private Location location;
        private Location sampleLocation = new Location("1", "1", 1, "1", "1", "1");
        private bool isClicked = false;

        //Brushes

        private Color bgColor = (Color)ColorConverter.ConvertFromString("#176ebd");
        private Color hoverColor = (Color)ColorConverter.ConvertFromString("#1a7dd7");
        private Color clickedColor = (Color)ColorConverter.ConvertFromString("#104a80");

        public LocationCard()
        {
            InitializeComponent();
        }

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

            if ((LocationFrame.rentingLocation.City.Length > 2) == false || LocationFrame.rentingLocation.LocationID == location.LocationID)
            {
                recBackground.Fill = clickedBrush;

                if (isClicked)
                {
                    isClicked = false;
                    LocationFrame.rentingLocation = sampleLocation;
                }
                else
                {
                    isClicked = true;
                    LocationFrame.rentingLocation = location;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.LocationFrame_TooManLocationsAlert);
            }

            //Put Location in marked Location List / if more then 1 show Hint
            //LocationFrame.rentingLocation = location;
            //MessageBox.Show("location set: " + LocationFrame.rentingLocation.City);
        }
    }
}