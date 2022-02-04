using System.Collections.Generic;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    /// <summary>
    /// Interaktionslogik für LocationFrame.xaml
    /// </summary>
    public partial class LocationFrame : Page
    {
        //Variables

        public static Location rentingLocation = new Location("1", "1", 1, "1", "1", "1");

        public LocationFrame()
        {
            InitializeComponent();

            //Get the List of Locations
            List<Location> displayList = new List<Location>();
            displayList = CvmMain.locationList;

            LocationsItemsControl.ItemsSource = displayList;
        }

        //Reset
        public void ResetLocationFrame()
        {
            rentingLocation = new Location("1", "1", 1, "1", "1", "1");
        }
    }
}