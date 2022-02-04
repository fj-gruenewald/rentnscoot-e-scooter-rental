using System.Collections.Generic;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    /// <summary>
    /// Interaktionslogik für ScooterFrame.xaml
    /// </summary>
    public partial class ScooterFrame : Page
    {
        public static Scooter rentingScooter = new Scooter(1, 1, 1, "1", "1");

        public ScooterFrame()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            List<Scooter> displayList = new List<Scooter>();
            displayList = CvmMain.scooterList;

            ScooterItemsControl.ItemsSource = displayList;
        }
    }
}