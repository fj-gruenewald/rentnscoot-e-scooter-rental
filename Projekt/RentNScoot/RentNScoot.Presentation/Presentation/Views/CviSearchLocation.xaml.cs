using System.Windows;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CviSearchLocation.xaml
    /// </summary>
    public partial class CviSearchLocation : Window
    {
        //
        private CvmSearchLocation _vmSearchLocation;
        private readonly CviSearchScooter _viSearchScooter;
        private IAppQueries query;

        //
        private static volatile CviSearchLocation? instance = null;

        private static readonly object padlock = new object();

        internal static CviSearchLocation CreateSingleton(CvmMain vmMain, CvmSearchLocation vmSearchLocation, CviSearchScooter viSeachScooter)
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new CviSearchLocation(vmMain, vmSearchLocation, viSeachScooter);
                return instance;
            }
        }

        //
        private CviSearchLocation(CvmMain vmMain, CvmSearchLocation vmSearchLocation, CviSearchScooter viSeachScooter)
        {
            _vmSearchLocation = vmSearchLocation;
            _viSearchScooter = viSeachScooter;
            DataContext = vmSearchLocation;
            InitializeComponent();
        }

        //
        private void ContinueProcess(object sender, RoutedEventArgs e)
        {
            _viSearchScooter.Show();
            this.Hide();
        }
    }
}
