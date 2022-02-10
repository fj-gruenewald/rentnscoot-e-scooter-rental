using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class ScooterFrame : Page
    {
        //Fields

        private readonly CvmMain _vmMain;

        #region Instance

        private static volatile ScooterFrame? instance = null;

        private static readonly object padlock = new object();

        internal static ScooterFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new ScooterFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal ScooterFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();
        }

        #endregion ctor

        #region Methods

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CvmMain.rentingScooter = new Scooter(1, 1, 1, "1", "1");
            ScooterItemsControl.ItemsSource = _vmMain.ScooterList(CvmMain.rentingLocation);
        }

        #endregion Methods
    }
}