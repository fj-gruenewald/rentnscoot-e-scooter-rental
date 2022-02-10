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

        internal static RentalData rentalData = new RentalData();

        //Renting Process Variables

        internal static Location rentingLocation;
        internal static Scooter rentingScooter;
        internal static Customer rentingCustomer;
        internal static RentingTime rentingTime;
        internal static Rental rental;

        #region Instance

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

            //List<Location> locations = _appQueries.GetLocationListFromDB() ?? new List<Location>();
            //locationList = locations;
        }

        #endregion Ctor

        #region Methods

        //Get Locations List
        public List<Location> LocationList()
        {
            List<Location> locations = _appQueries.GetLocationListFromDB() ?? new List<Location>();
            return locations;
        }

        //Get Scooter List to Location
        public List<Scooter> ScooterList(Location location)
        {
            List<Scooter> scooters = _appQueries.GetScooterListFromDbByObject(location) ?? new List<Scooter>();
            return scooters;
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
                    try
                    {
                        var rental = _appQueries.GetRentableFromDbById(rentalId);
                        var scooter = _appQueries.GetScooterFromDbById(rental.ScooterID.ToString());
                        var customer = _appQueries.GetCustomerFromDbById(rental.CustomerID);
                        var location = _appQueries.GetLocationFromDbById(rental.LocationID);

                        rentalData = null;
                        rentalData = new RentalData(rental, customer, scooter, location);

                        hasFinished = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(Properties.Resources.CvmMain_Err_RentalCodeError);
                        throw;
                    }
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