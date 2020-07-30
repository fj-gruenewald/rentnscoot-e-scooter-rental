using RentNScoot.Domain;
using System.ComponentModel;

namespace RentNScoot.Presentation.ViewModels
{
    internal class CvmCustomerData : INotifyPropertyChanged
    {
        private readonly Customer _customer = new Customer();
        private readonly IAppQueries _appQueries;
        private readonly IAppCommands _appCommands;
        private readonly CvmMain _vmMain;

        #region ctor
        //wenn eigenschaft verändert
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        // Singleton C#
        private static volatile CvmCustomerData? instance = null;

        private static readonly object padlock = new object();

        internal static CvmCustomerData CreateSingleton(IAppQueries appCarQueries,
            IAppCommands appCarCommands,
            CvmMain vmMain)
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new CvmCustomerData(appCarQueries, appCarCommands, vmMain);
                return instance;
            }
        }

        private CvmCustomerData(IAppQueries appCarQueries,
            IAppCommands appCarCommands,
            CvmMain vmMain)
        {
            _appQueries = appCarQueries;
            _appCommands = appCarCommands;
            _vmMain = vmMain;
        }

        #endregion ctor
    }
}