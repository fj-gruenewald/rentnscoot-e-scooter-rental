using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Presentation.ViewModels
{
    public class CvmMain
    {
        //
        private IAppCommands _appCommands;
        private IAppQueries _appQueries;

        //
        public string nScooters { get; }

        //
        public CvmMain(IAppCommands appCommands, IAppQueries appQueries)
        {
            _appCommands = appCommands;
            _appQueries = appQueries;

            nScooters = $"Insgesamt {_appQueries.CountScooters()} Roller";
        }
    }
}
