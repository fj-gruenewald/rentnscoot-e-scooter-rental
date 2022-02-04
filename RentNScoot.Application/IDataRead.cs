using System.Collections.Generic;

namespace RentNScoot
{
    public interface IDataRead
    {
        //Database Functions

        void InitDb();

        void DisposeDb();

        //List of all Locations

        List<Location> GetLocationListFromDB();

        //List of Scooters to Location

        List<Scooter> GetScooterListFromDbByObject(Location location);

        //Data needed for the Rental Return

        Scooter GetScooterFromDbById(string locationId);

        Rental GetRentableFromDbById(string rentableId);

        Customer GetCustomerFromDbById(string customerId);

        Location GetLocationFromDbById(string locationId);
    }
}