using RentNScoot.Presentation.ViewModels;
using System.Windows;

namespace RentNScoot.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CviSearchScooter.xaml
    /// </summary>
    public partial class CviSearchScooter : Window
    {
        //
        private CvmSearchScooter _vmSearchScooter;

        private CviCustomerData _viCustomerData;

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
            _viCustomerData.Show();
            this.Hide();
        }
    }
}