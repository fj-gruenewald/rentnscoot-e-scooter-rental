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

            //CvmSearchResults vmSearchRes = CvmSearchResults.CreateSingleton(vmMain);

            //CvmSearchCars vmSearchCars = CvmSearchCars.CreateSingleton(vmSearchRes,appCarQueries);

            //CvmAddCar vmAddCar = CvmAddCar.CreateSingleton(appCarQueries, appCarCommands, vmMain);

            //CvmUpdateCar vmUpdateCar = CvmUpdateCar.CreateSingleton(appCarQueries, appCarCommands, vmMain);


            // Views
            //CviSearchResults viSearchResults = CviSearchResults.CreateSingleton(vmMain, vmSearchRes);

            //CviSearchCars viSearchCars = CviSearchCars.CreateSingleton(vmSearchCars, viSearchResults);

            //CviAddCar viAddCar = CviAddCar.CreateSingleton(vmAddCar);

            CviMain viMain = CviMain.CreateSingleton(vmMain);
            return viMain;
        }
    }
}
