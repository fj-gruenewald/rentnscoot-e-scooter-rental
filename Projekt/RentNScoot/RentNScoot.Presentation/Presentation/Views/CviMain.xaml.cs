using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//
using RentNScoot.Presentation.Views;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views
{
    /// <summary>
    /// Interaktionslogik für CviMain.xaml
    /// </summary>
    public partial class CviMain : Window, IDialog
    {
        //
        private CvmMain _vmMain;
        private readonly CviSearchLocation _viSearchLocation;
        
        //
        private static volatile CviMain? instance = null;

        //
        private static readonly object padlock = new object();

        //
        internal static CviMain CreateSingleton(CvmMain vmMain, CviSearchLocation viSearchLocation, CviSearchScooter viSearchScooter)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CviMain(vmMain, viSearchLocation, viSearchScooter);
                return instance;
            }
        }

        //
        private CviMain(CvmMain vmMain, CviSearchLocation viSearchLocation, CviSearchScooter viSearchScooter)
        {
            _vmMain = vmMain;
            _viSearchLocation = viSearchLocation;

            InitializeComponent();
            DataContext = vmMain;
        }

        private void StartProcess(object sender, RoutedEventArgs e)
        {
            _viSearchLocation.Show();
            this.Hide();
        }
    }
}
