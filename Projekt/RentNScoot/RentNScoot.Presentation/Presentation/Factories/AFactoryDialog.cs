//
using RentNScoot.Presentation.ViewModels;
using RentNScoot.Presentation.Views;

namespace RentNScoot.Presentation.Factories
{
    public abstract class AFactoryDialog
    {
        public static IDialog CreateSingleton(IAppCommands appCommands, IAppQueries appQueries)
        {
            // ViewModels
            CvmMain vmMain = CvmMain.CreateSingleton(appCommands, appQueries);

            CvmSearchScooter vmSearchScooter = CvmSearchScooter.CreateSingleton(vmMain);

            CvmSearchLocation vmSearchLocation = CvmSearchLocation.CreateSingleton(vmMain);

            CvmCustomerData vmCustomerData = CvmCustomerData.CreateSingleton(appQueries, appCommands, vmMain);

            // Views
            CviSearchScooter viSearchScooter = CviSearchScooter.CreateSingleton(vmMain, vmSearchScooter);

            CviSearchLocation viSearchLocation = CviSearchLocation.CreateSingleton(vmMain, vmSearchLocation, viSearchScooter);

            CviCustomerData viCustomerData = CviCustomerData.CreateSingleton(vmCustomerData);

            CviMain viMain = CviMain.CreateSingleton(vmMain, viSearchLocation, viSearchScooter);
            return viMain;
        }
    }
}