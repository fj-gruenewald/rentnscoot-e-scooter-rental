using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class LocationFrame : Page
    {
        //Fields

        private readonly CvmMain _vmMain;

        #region Instance

        private static volatile LocationFrame? instance = null;

        private static readonly object padlock = new object();

        internal static LocationFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new LocationFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal LocationFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();

            CvmMain.rentingLocation = new Location("1", 1, "1", "1", "1");
            LocationsItemsControl.ItemsSource = vmMain.LocationList();
        }

        #endregion ctor
    }
}