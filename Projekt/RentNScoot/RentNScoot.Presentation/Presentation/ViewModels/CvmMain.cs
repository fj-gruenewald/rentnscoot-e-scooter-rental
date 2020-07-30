using System;

namespace RentNScoot.Presentation.ViewModels
{
    internal class CvmMain
    {
        //fremdklassen initialisieren
        private IAppCommands _appCommands;

        private IAppQueries _appQueries;

        //anz. scooter
        public string nScooters { get; } = String.Empty;

        //instanz der Seite
        private static volatile CvmMain? instance = null;

        private static readonly object padlock = new object();

        //Konstruktor
        internal static CvmMain CreateSingleton(IAppCommands appCarCommands, IAppQueries appCarQueries)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CvmMain(appCarCommands,
                    appCarQueries);
                return instance;
            }
        }

        //Konstruktor
        private CvmMain(IAppCommands appCommands, IAppQueries appQueries)
        {
            _appCommands = appCommands;
            _appQueries = appQueries;

            nScooters = $"Insgesamt {_appQueries.CountScooters()} Roller zu vermieten";
        }
    }
}