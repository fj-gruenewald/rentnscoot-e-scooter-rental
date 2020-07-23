using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Presentation.ViewModels
{
    internal class CvmMain
    {
        //
        private IAppCommands _appCommands;
        private IAppQueries _appQueries;

        //
        public string nScooters { get; } = String.Empty;

        //
        private static volatile CvmMain? instance = null;

        //
        private static readonly object padlock = new object();

        //
        internal static CvmMain CreateSingleton(IAppCommands appCarCommands, IAppQueries appCarQueries)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CvmMain(appCarCommands,
                    appCarQueries);
                return instance;
            }
        }

        //
        private CvmMain(IAppCommands appCommands, IAppQueries appQueries)
        {
            _appCommands = appCommands;
            _appQueries = appQueries;

            nScooters = $"Insgesamt {_appQueries.CountScooters()} Roller zu vermieten";
        }
    }
}
