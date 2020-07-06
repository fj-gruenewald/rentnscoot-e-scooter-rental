using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Presentation.ViewModels
{
    public class CvmMain
    {
        //
        private IAppCommands _appCommands;
        private IAppQueries _appQueries;

        //
        public string NCars { get; }

        //
        public CvmMain(IAppCommands appCommands, IAppQueries appQueries)
        {
            _appCommands = appCommands;
            _appQueries = appQueries;
            NCars = $"Insgesamt {_appQueries.CountScooters()} Roller";
        }
    }
}
