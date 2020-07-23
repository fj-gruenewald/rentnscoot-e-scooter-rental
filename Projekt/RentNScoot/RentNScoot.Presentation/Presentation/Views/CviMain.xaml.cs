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

        //
        private static volatile CviMain? instance = null;

        //
        private static readonly object padlock = new object();

        //
        internal static CviMain CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CviMain(vmMain);
                return instance;
            }
        }

        //
        private CviMain(CvmMain vmMain)
        {
            _vmMain = vmMain;

            InitializeComponent();
            DataContext = vmMain;
        }
    }
}
