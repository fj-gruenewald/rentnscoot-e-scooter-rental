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
        public static IDialog CreateSingleton(IAppCommands appCommands, IAppQueries appQueries)
        {
            CvmMain vmMain = new CvmMain(appCommands, appQueries);
            CviMain viMain = new CviMain(vmMain);
            return viMain;
        }
    }
}
