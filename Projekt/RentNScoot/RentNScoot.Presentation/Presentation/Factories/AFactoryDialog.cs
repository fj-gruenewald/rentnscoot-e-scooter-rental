using System;
using System.Collections.Generic;
using System.Text;

//
using RentNScoot.Presentation.Views;
using RentNScoot.Presentation.ViewModels;

namespace RentNScoot.Presentation.Factories
{
    public abstract class AFactoryDialog
    {
        //

        //
        public static IDialog CreateSingleton(IAppCommands appCommands, IAppQueries appQueries)
        {
            // ViewModels
            CvmMain vmMain = CvmMain.CreateSingleton(appCommands, appQueries);

            CvmSearchScooter vmSearchScooter = CvmSearchScooter.CreateSingleton(vmMain);

            CvmSearchLocation vmSearchLocation = CvmSearchLocation.CreateSingleton(vmMain);

            //CvmAddCar vmAddCar = CvmAddCar.CreateSingleton(appCarQueries, appCarCommands, vmMain);

            //CvmUpdateCar vmUpdateCar = CvmUpdateCar.CreateSingleton(appCarQueries, appCarCommands, vmMain);


            // Views
            CviSearchScooter viSearchScooter = CviSearchScooter.CreateSingleton(vmMain, vmSearchScooter);

            CviSearchLocation viSearchLocation = CviSearchLocation.CreateSingleton(vmMain, vmSearchLocation, viSearchScooter);

            //CviAddCar viAddCar = CviAddCar.CreateSingleton(vmAddCar);

            CviMain viMain = CviMain.CreateSingleton(vmMain, viSearchLocation, viSearchScooter);
            return viMain;
        }
    }
}
