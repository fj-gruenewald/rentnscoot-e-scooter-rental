using System;
using RentNScoot.Utils;

namespace RentNScoot.Application
{
    internal class CAppCommands : IAppCommands
    {
        #region Fields

        private IDataWrite _dataWrite;

        private static volatile CAppCommands? instance = null;
        private static readonly object padlock = new object();

        #endregion Fields

        #region ctor

        internal static CAppCommands CreateSingleton(IDataWrite dataWrite)
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new CAppCommands(dataWrite);
                return instance;
            }
        }

        internal CAppCommands(IDataWrite dataWrite)
        {
            Log.D(this, "Ctor()", "");
            _dataWrite = dataWrite;
        }

        #endregion ctor

        #region Customer Methods

        public int InsertCustomer(Customer customer)
        {
            Log.D(this, "InsertCustomer()", "sending command to _dataWrite...");
            var hasInserted = _dataWrite.InsertCustomer(customer);
            return hasInserted;
        }

        #endregion Customer Methods

        #region Rental Methods

        public int InsertRental(Rental rental)
        {
            Log.D(this, "InsertRental()", "sending command to _dataWrite...");
            var hasInserted = _dataWrite.InsertRental(rental);
            return hasInserted;
        }

        public int DeleteRental(Rental rental)
        {
            Log.D(this, "DeleteRental()", "sending command to _dataWrite...");
            var hasDeleted = _dataWrite.DeleteRental(rental);
            return hasDeleted;
        }

        #endregion Rental Methods

        #region Scooter Methods

        public int UpdateScooter(Scooter scooter)
        {
            Log.D(this, "UpdateScooter()", "sending command to _dataWrite...");
            var hasInserted = _dataWrite.UpdateScooter(scooter);
            return hasInserted;
        }

        #endregion Scooter Methods
    }
}