using RentNScoot.Presentation.ViewModels;
using RentNScoot.Presentation.Views;

namespace RentNScoot.Presentation.Factories
{
    public abstract class AFactoryDialog
    {
        public static IDialog CreateSingleton(IAppQueries appQueries, IAppCommands appCommands)
        {
            // ViewModels

            CvmMain vmMain = CvmMain.CreateSingleton(appQueries, appCommands);

            // Views

            CviMain viMain = CviMain.CreateSingleton(vmMain);
            return viMain;
        }
    }
}