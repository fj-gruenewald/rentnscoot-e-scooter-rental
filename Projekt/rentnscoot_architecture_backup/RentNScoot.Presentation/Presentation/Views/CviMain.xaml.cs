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
        public CviMain(CvmMain vmMain)
        {
            _vmMain = vmMain;
            DataContext = vmMain;
            InitializeComponent();
        }
    }
}
