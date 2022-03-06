using System.Collections.Generic;
using RentNScoot.Utils;

namespace RentNScoot.Application
{
    internal class CAppQueries : IAppQueries
    {
        #region Fields

        private IDataRead _dataRead;

        #endregion Fields

        #region ctor

        private static volatile CAppQueries? instance = null;

        private static readonly object padlock = new object();

        internal static CAppQueries CreateSingleton(IDataRead dataRead)
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new CAppQueries(dataRead);
                return instance;
            }
        }

        internal CAppQueries(IDataRead dataRead)
        {
            Log.D(this, "Ctor()", "");
            _dataRead = dataRead;
        }

        #endregion ctor

        #region Location Methods

        public virtual List<Location> GetLocationListFromDB()
        {
            var LocationListFromDB = _dataRead.GetLocationListFromDB();
            return LocationListFromDB;
        }

        public virtual Location GetLocationFromDbById(string locationId)
        {
            var location = _dataRead.GetLocationFromDbById(locationId);
            return location;
        }

        #endregion Location Methods

        #region Scooter Methods

        public virtual List<Scooter> GetScooterListFromDbByObject(Location location)
        {
            var ScooterListFromDB = _dataRead.GetScooterListFromDbByObject(location);
            return ScooterListFromDB;
        }

        public virtual Scooter GetScooterFromDbById(string scooterId)
        {
            var scooter = _dataRead.GetScooterFromDbById(scooterId);
            return scooter;
        }

        #endregion Scooter Methods

        #region Rental Methods

        public virtual Rental GetRentableFromDbById(string rentableId)
        {
            var rentable = _dataRead.GetRentableFromDbById(rentableId);
            return rentable;
        }

        #endregion Rental Methods

        #region Customer Methods

        public virtual Customer GetCustomerFromDbById(string customerId)
        {
            var customer = _dataRead.GetCustomerFromDbById(customerId);
            return customer;
        }

        #endregion Customer Methods
    }
}