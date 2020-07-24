using System.Windows;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CviSearchScooter.xaml
    /// </summary>
    public partial class CviSearchScooter : Window
    {
        //
        private CvmSearchScooter _vmSearchScooter;

        //
        private static volatile CviSearchScooter? instance = null;

        private static readonly object padlock = new object();

        internal static CviSearchScooter CreateSingleton(CvmMain vmMain,
            CvmSearchScooter vmSearchRes)
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new CviSearchScooter(vmMain, vmSearchRes);
                return instance;
            }
        }

        //
        private CviSearchScooter(CvmMain vmMain, CvmSearchScooter vmSearchScooter)
        {
            _vmSearchScooter = vmSearchScooter;
            DataContext = vmSearchScooter;
            InitializeComponent();
        }

        //
        private void ContinueProcess(object sender, RoutedEventArgs e)
        {
            CviCustomerData cviCustomerData = new CviCustomerData();
            this.Visibility = Visibility.Hidden;
            cviCustomerData.Show();
        }
    }
}
