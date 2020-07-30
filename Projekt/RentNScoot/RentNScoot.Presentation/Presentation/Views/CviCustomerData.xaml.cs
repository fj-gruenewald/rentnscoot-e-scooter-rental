using RentNScoot.Presentation.ViewModels;
using System.Windows;

namespace RentNScoot.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CviCustomerData.xaml
    /// </summary>
    public partial class CviCustomerData : Window
    {
        //
        private readonly CvmCustomerData _vmcustomerData;

        //ctor
        // Singleton C#
        private static volatile CviCustomerData? instance = null;

        private static readonly object padlock = new object();

        internal static CviCustomerData CreateSingleton(CvmCustomerData vmCustomerData)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CviCustomerData(vmCustomerData);
                return instance;
            }
        }

        internal CviCustomerData(CvmCustomerData vmCustomerDatar)
        {
            _vmcustomerData = vmCustomerDatar;
            InitializeComponent();
            DataContext = vmCustomerDatar;
        }

        private void ContinueProcess(object sender, RoutedEventArgs e)
        {
            CviEnd cviSummary = new CviEnd();
            this.Visibility = Visibility.Hidden;
            cviSummary.Show();
        }
    }
}