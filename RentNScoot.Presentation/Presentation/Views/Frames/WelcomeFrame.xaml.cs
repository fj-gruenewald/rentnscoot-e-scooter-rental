using System.Windows.Controls;
using System.Windows.Media;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Views.Frames
{
    public partial class WelcomeFrame : UserControl
    {
        //Fields

        private readonly CvmMain _vmMain;

        //Brushes

        private Color blueColor = (Color)ColorConverter.ConvertFromString("#176ebd");
        private Color grayColor = (Color)ColorConverter.ConvertFromString("#eeeeee");

        #region Instance

        private static volatile WelcomeFrame? instance = null;

        private static readonly object padlock = new object();

        internal static WelcomeFrame CreateSingleton(CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null) instance = new WelcomeFrame(vmMain);
                return instance;
            }
        }

        #endregion Instance

        #region ctor

        internal WelcomeFrame(CvmMain vmMain)
        {
            _vmMain = vmMain;
            InitializeComponent();
        }

        #endregion ctor

        #region Hover Effects

        private void ChooseLocationCardGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ChooseLocationCardGrid.Background = blueHoverBrush;
            RectChooseLocationCard.Fill = grayHoverBrush;

            txtBlueChooseLocationCard.Foreground = grayHoverBrush;
            txtGrayChooseLocationCard.Foreground = blueHoverBrush;
        }

        private void ChooseLocationCardGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ChooseLocationCardGrid.Background = grayHoverBrush;
            RectChooseLocationCard.Fill = blueHoverBrush;

            txtBlueChooseLocationCard.Foreground = blueHoverBrush;
            txtGrayChooseLocationCard.Foreground = grayHoverBrush;
        }

        private void ChooseTimeGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ChooseTimeGrid.Background = blueHoverBrush;
            RectChooseTime.Fill = grayHoverBrush;

            txtBlueChooseTime.Foreground = grayHoverBrush;
            txtGrayChooseTime.Foreground = blueHoverBrush;
        }

        private void ChooseTimeGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ChooseTimeGrid.Background = grayHoverBrush;
            RectChooseTime.Fill = blueHoverBrush;

            txtBlueChooseTime.Foreground = blueHoverBrush;
            txtGrayChooseTime.Foreground = grayHoverBrush;
        }

        private void ChooseScooterGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ChooseScooterGrid.Background = blueHoverBrush;
            RectChooseScooter.Fill = grayHoverBrush;

            txtBlueChooseScooter.Foreground = grayHoverBrush;
            txtGrayChooseScooter.Foreground = blueHoverBrush;
        }

        private void ChooseScooterGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ChooseScooterGrid.Background = grayHoverBrush;
            RectChooseScooter.Fill = blueHoverBrush;

            txtBlueChooseScooter.Foreground = blueHoverBrush;
            txtGrayChooseScooter.Foreground = grayHoverBrush;
        }

        private void PersonalDataGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            PersonalDataGrid.Background = blueHoverBrush;
            RectPersonalData.Fill = grayHoverBrush;

            txtBluePersonalData.Foreground = grayHoverBrush;
            txtGrayPersonalData.Foreground = blueHoverBrush;
        }

        private void PersonalDataGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            PersonalDataGrid.Background = grayHoverBrush;
            RectPersonalData.Fill = blueHoverBrush;

            txtBluePersonalData.Foreground = blueHoverBrush;
            txtGrayPersonalData.Foreground = grayHoverBrush;
        }

        private void ReadyCardGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ReadyCardGrid.Background = blueHoverBrush;
            RectReadyCard.Fill = grayHoverBrush;

            txtBlueReadyCard.Foreground = grayHoverBrush;
            txtGrayReadyCard.Foreground = blueHoverBrush;
        }

        private void ReadyCardGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush grayHoverBrush = new SolidColorBrush(grayColor);
            SolidColorBrush blueHoverBrush = new SolidColorBrush(blueColor);

            ReadyCardGrid.Background = grayHoverBrush;
            RectReadyCard.Fill = blueHoverBrush;

            txtBlueReadyCard.Foreground = blueHoverBrush;
            txtGrayReadyCard.Foreground = grayHoverBrush;
        }

        #endregion Hover Effects
    }
}