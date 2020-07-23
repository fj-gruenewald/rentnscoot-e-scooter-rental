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
    /// Interaktionslogik für CviSearchLocation.xaml
    /// </summary>
    public partial class CviSearchLocation : Window
    {
        //
        private readonly CvmSearchMisc viewModel;

        public CviSearchLocation()
        {
            InitializeComponent();
        }

        private void OnDataGridLoaded(object sender, RoutedEventArgs e)
        {
            ((DataGrid)sender).ItemsSource = viewModel.Locations;
        }
    }
}
