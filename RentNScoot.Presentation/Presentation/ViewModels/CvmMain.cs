using System;
using System.Collections.Generic;
using System.Windows;

namespace RentNScoot.Presentation.ViewModels
{
    internal class CvmMain
    {
        //Fields

        private IAppQueries _appQueries;
        private IAppCommands _appCommands;

        public static List<Location> locationList = new List<Location>();
        public static List<Scooter> scooterList = new List<Scooter>();
        public static RentalData rentalData = new RentalData();

        //Renting Process Variables

        public static Location rentingLocation;
        public static Scooter rentingScooter;
        public static RentingTime rentingTimeFrame;
        public static Customer rentingCustomer;

        #region Instance

        //Instance
        private static volatile CvmMain? instance = null;

        private static readonly object padlock = new object();

        internal static CvmMain CreateSingleton(IAppQueries appQueries, IAppCommands appCommands)
        {
            lock (padlock)
            {
                if (instance == null) instance = new CvmMain(appQueries, appCommands);
                return instance;
            }
        }

        #endregion Instance

        #region Ctor

        //Ctor
        public CvmMain(IAppQueries appQueries, IAppCommands appCommands)
        {
            _appQueries = appQueries;
            _appCommands = appCommands;

            //Get the List of all Locations

            List<Location> locations = _appQueries.GetLocationListFromDB() ?? new List<Location>();
            locationList = locations;
        }

        #endregion Ctor

        #region Methods

        //Get Scooter List to Location
        public void GetScooterListToLocation(Location location)
        {
            List<Scooter> scooters = _appQueries.GetScooterListFromDbByObject(location) ?? new List<Scooter>();
            scooterList = scooters;
        }

        //Push Customer to DB
        public void PushCustomerToDb(Customer customer)
        {
            _appCommands.InsertCustomer(customer);
        }

        //Push Rental to DB and Update Scooter
        public void PushRentalToDb(Rental rental, Scooter scooter)
        {
            _appCommands.InsertRental(rental);
            _appCommands.UpdateScooter(scooter);
        }

        //Populate Rental Data for the Rental Return
        public bool ReadRentalDataFromDb(string rentalId)
        {
            bool hasFinished = false;

            try
            {
                if (rentalId.Length >= 20)
                {
                    var rental = _appQueries.GetRentableFromDbById(rentalId);
                    var scooter = _appQueries.GetScooterFromDbById(rental.ScooterID.ToString());
                    var customer = _appQueries.GetCustomerFromDbById(rental.CustomerID);
                    var location = _appQueries.GetLocationFromDbById(rental.LocationID);

                    rentalData = null;
                    rentalData = new RentalData(rental, customer, scooter, location);

                    hasFinished = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Properties.Resources.CvmMain_Err_RentalCodeNotExistent);
                throw;
            }
            return hasFinished;
        }

        //Delete Rental
        public void DeleterentalAfterReturn(Rental rental)
        {
            _appCommands.DeleteRental(rental);
        }

        #endregion Methods
    }
}