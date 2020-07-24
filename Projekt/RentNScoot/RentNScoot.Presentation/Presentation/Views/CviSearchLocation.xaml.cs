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

        //
        private static volatile CviSearchLocation? instance = null;

        private static readonly object padlock = new object();

        internal static CviSearchLocation CreateSingleton(CvmMain vmMain,
            CvmSearchLocation vmSearchLocation)
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new CviSearchLocation(vmMain, vmSearchLocation);
                return instance;
            }
        }

        //
        private CviSearchLocation(CvmMain vmMain, CvmSearchLocation vmSearchLocation)
        {
            _vmSearchLocation = vmSearchLocation;
            DataContext = vmSearchLocation;
            InitializeComponent();
        }

        //
        private void ContinueProcess(object sender, RoutedEventArgs e)
        {
        }
    }
}
