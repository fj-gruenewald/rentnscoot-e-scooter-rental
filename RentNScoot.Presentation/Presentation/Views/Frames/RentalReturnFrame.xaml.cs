﻿using System;
using System.Windows;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class RentalReturnFrame : Page
    {
        //Fields

        private readonly CvmMain _vmMain;

        #region Instance

        private static volatile RentalReturnFrame? instance = null;

        private static readonly object padlock = new object();

        internal static RentalReturnFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new RentalReturnFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal RentalReturnFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();
        }

        #endregion ctor

        #region Interface Methods

        //OnPageLoad
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        public void RefreshFrame()
        {
            //Set Rental Summary Grid
            txtRentalSummaryHeadline.Text = $" {CvmMain.rentalData.Customer.CustomerName} ";

            txtScooterOverview.Text = $" {CvmMain.rentalData.Scooter.Manufacturer} {CvmMain.rentalData.Scooter.Model} ";
            txtDayOverview.Text = $" {CalculateHours(CvmMain.rentalData.Rental.RentalStart, CvmMain.rentalData.Rental.RentalEnd)} ";

            txtLocationOverview.Text = $" {CvmMain.rentalData.Location.Postal} {CvmMain.rentalData.Location.City}, {CvmMain.rentalData.Location.Street} {CvmMain.rentalData.Location.StreetNr} ";

            //Show Rental Summary Grid
            SummaryGrid.Visibility = Visibility.Visible;
        }

        public void ResetFrame()
        {
            txtbRentalCode.Text = "";
            SummaryGrid.Visibility = Visibility.Hidden;
        }

        #endregion Interface Methods

        #region Methods

        public string GetRentalCodeFromRentalReturnFrame()
        {
            if (txtbRentalCode.Text.Length >= 20)
            {
                Guid validate;

                if (Guid.TryParse(txtbRentalCode.Text, out validate))
                {
                    return txtbRentalCode.Text;
                }
                else
                {
                    MessageBox.Show(Properties.Resources.RentalReturnFrame_Err_RentalCodeInvalid);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.RentalReturnFrame_Err_RentalCodeEmpty);
            }

            return string.Empty;
        }

        private int CalculateHours(string startTime, string endTime)
        {
            int hours = 0;

            DateTime from = Convert.ToDateTime(startTime);
            DateTime to = Convert.ToDateTime(endTime);

            TimeSpan diff = to - from;
            hours = (int)diff.TotalHours;

            return hours;
        }

        #endregion Methods
    }
}