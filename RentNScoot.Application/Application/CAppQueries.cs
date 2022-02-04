using System;
using System.Collections.Generic;
using RentNScoot.Utils;

namespace RentNScoot.Application
{
    internal class CAppQueries : IAppQueries
    {
        //dataread initialisieren
        private IDataRead _dataRead;

        //Konstruktor
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

        //Hand over Vars from IDataRead

        //List of all Locations
        public virtual List<Location> GetLocationListFromDB()
        {
            var LocationListFromDB = _dataRead.GetLocationListFromDB();
            return LocationListFromDB;
        }

        //List of Scooters to Location
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

        public virtual Rental GetRentableFromDbById(string rentableId)
        {
            var rentable = _dataRead.GetRentableFromDbById(rentableId);
            return rentable;
        }

        public virtual Customer GetCustomerFromDbById(string customerId)
        {
            var customer = _dataRead.GetCustomerFromDbById(customerId);
            return customer;
        }

        public virtual Location GetLocationFromDbById(string locationId)
        {
            var location = _dataRead.GetLocationFromDbById(locationId);
            return location;
        }
    }
}