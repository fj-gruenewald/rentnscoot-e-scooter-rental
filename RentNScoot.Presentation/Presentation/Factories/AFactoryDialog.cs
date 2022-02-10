using RentNScoot.Presentation.ViewModels;
using RentNScoot.Presentation.Views;
using RentNScoot.Presentation.Views.Frames;

namespace RentNScoot.Presentation.Factories
{
    public abstract class AFactoryDialog
    {
        public static IDialog CreateSingleton(IAppQueries appQueries, IAppCommands appCommands)
        {
            // ViewModels

            CvmMain vmMain = CvmMain.CreateSingleton(appQueries, appCommands);

            // Views

            WelcomeFrame welcomeFrame = WelcomeFrame.CreateSingleton(vmMain);
            RentalReturnFrame rentalReturnFrame = RentalReturnFrame.CreateSingleton(vmMain);
            LocationFrame locationFrame = LocationFrame.CreateSingleton(vmMain);
            TimeFrame timeFrame = TimeFrame.CreateSingleton(vmMain);
            ScooterFrame scooterFrame = ScooterFrame.CreateSingleton(vmMain);
            PersonalDataFrame personalDataFrame = PersonalDataFrame.CreateSingleton(vmMain);
            OverviewFrame overviewFrame = OverviewFrame.CreateSingleton(vmMain);
            RentalDetailFrame rentalDetailFrame = RentalDetailFrame.CreateSingleton(vmMain);
            CviMain viMain = CviMain.CreateSingleton(vmMain, welcomeFrame, rentalReturnFrame, locationFrame, timeFrame, scooterFrame, personalDataFrame, overviewFrame, rentalDetailFrame);

            return viMain;
        }
    }
}