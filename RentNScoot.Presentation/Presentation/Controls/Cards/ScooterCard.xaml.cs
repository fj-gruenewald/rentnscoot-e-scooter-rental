using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Controls.Cards
{
    public partial class ScooterCard : UserControl
    {
        //Fields

        private Scooter scooter;
        private bool isClicked = false;

        //Brushes

        private Color bgColor = (Color)ColorConverter.ConvertFromString("#eeeeee");
        private Color hoverColor = (Color)ColorConverter.ConvertFromString("#1a7dd7");
        private Color clickedColor = (Color)ColorConverter.ConvertFromString("#104a80");

        #region ctor

        public ScooterCard()
        {
            InitializeComponent();
        }

        #endregion ctor

        #region Methods

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //get the binding from the usercontrol tag
            UserControl userControl = sender as UserControl;
            scooter = (Scooter)userControl.Tag;
            txtManufacturer.Text = scooter.Manufacturer;
            txtModel.Text = scooter.Model;

            switch (scooter.Model)
            {
                case "Mi Electric Scooter 1S":
                    imgScooter.Source =
                        new BitmapImage(new Uri(
                            @"../../../assets/img/scooter-image-by-dominika-roseclay-from-pexels.jpg",
                            UriKind.Relative));
                    break;

                case "The Model One":
                    imgScooter.Source =
                        new BitmapImage(new Uri(@"../../../assets/img/scooter-image1-by-eric-goverde-from-pexels.jpg",
                            UriKind.Relative));
                    break;

                default:
                    imgScooter.Source =
                        new BitmapImage(new Uri(@"../../../assets/img/error-image-by-miguel-a-padrinan-from-pexels.jpg",
                            UriKind.Relative));
                    break;
            }
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!isClicked)
            {
                SolidColorBrush hoverBrush = new SolidColorBrush(hoverColor);
                RecInfoBox.Background = hoverBrush;
                txtManufacturer.Foreground = Brushes.White;
                txtModel.Foreground = Brushes.White;
            }
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!isClicked)
            {
                SolidColorBrush bgBrush = new SolidColorBrush(bgColor);
                RecInfoBox.Background = bgBrush;
                txtManufacturer.Foreground = Brushes.Black;
                txtModel.Foreground = Brushes.Black;
            }
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SolidColorBrush clickedBrush = new SolidColorBrush(clickedColor);

            if ((CvmMain.rentingScooter.Manufacturer.Length >= 2) == false ||
                CvmMain.rentingScooter.ScooterID == scooter.ScooterID)
            {
                RecInfoBox.Background = clickedBrush;
                txtManufacturer.Foreground = Brushes.White;
                txtModel.Foreground = Brushes.White;

                if (isClicked)
                {
                    isClicked = false;
                    CvmMain.rentingScooter = new Scooter(1, 1, 1, "1", "1");
                }
                else
                {
                    isClicked = true;
                    CvmMain.rentingScooter = scooter;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.ScooterFrame_ToManScootersAlert);
            }
        }

        #endregion Methods
    }
}