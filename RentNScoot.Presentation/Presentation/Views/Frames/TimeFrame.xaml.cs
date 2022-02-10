using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class TimeFrame : Page
    {
        //Fields

        private readonly CvmMain _vmMain;
        public static bool dateAccepted = false;

        #region Instance

        private static volatile TimeFrame? instance = null;

        private static readonly object padlock = new object();

        internal static TimeFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new TimeFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal TimeFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();
        }

        #endregion ctor

        #region Methods

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Setup the DatePickers

            DateFrom.DisplayDateStart = DateTime.Now;
            DateTo.DisplayDateStart = DateTime.Now;

            //Populate the Combobox Lists

            combTimeFrom.ItemsSource = new List<string> { "9:00", "10:00", "11:00", "12:00" };
            combTimeTo.ItemsSource = new List<string> { "13:00", "14:00", "15:00", "16:00" };

            //Set Standard Combobox Items

            combTimeFrom.SelectedValue = "9:00";
            combTimeTo.SelectedValue = "13:00";
        }

        private void bttnCheckAvailability_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Set Dates
            if (DateFrom.SelectedDate != null && DateTo.SelectedDate != null)
            {
                var fromDate = DateFrom.SelectedDate;
                var toDate = DateTo.SelectedDate;

                //Set Times
                if (combTimeFrom.SelectedValue != null && combTimeTo.SelectedValue != null)
                {
                    string plusFromTime = $"{fromDate.Value.Day}.{fromDate.Value.Month}.{fromDate.Value.Year} {combTimeFrom.SelectedValue}";
                    string plusToTime = $"{toDate.Value.Day}.{toDate.Value.Month}.{toDate.Value.Year} {combTimeTo.SelectedValue}";

                    //Build rentingTime Object

                    DateTime rentingFrom = DateTime.Parse(plusFromTime);
                    DateTime rentingTo = DateTime.Parse(plusToTime);

                    if (rentingTo > rentingFrom)
                    {
                        imgFromCheckSuccesful.Visibility = Visibility.Visible;
                        imgToCheckSuccesful.Visibility = Visibility.Visible;

                        CvmMain.rentingTime = new RentingTime(rentingFrom, rentingTo);
                        dateAccepted = true;
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.TimeFrame_DatesMixedAlert);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.TimeFrame_TimeMissingAlert);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.TimeFrame_DateMissingAlert);
            }
        }

        #endregion Methods
    }
}