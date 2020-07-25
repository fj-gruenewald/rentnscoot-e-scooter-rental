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
using RentNScoot.Presentation.ViewModels;

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
