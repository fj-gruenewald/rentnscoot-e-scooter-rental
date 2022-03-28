using System.Collections.Generic;

namespace RentNScoot
{
    public interface IAppQueries
    {
        List<Location> GetLocationListFromDB();

        List<Scooter> GetScooterListFromDbByObject(Location location);

        Scooter GetScooterFromDbById(string locationId);

        Rental GetRentableFromDbById(string rentableId);

        Customer GetCustomerFromDbById(string customerId);

        Location GetLocationFromDbById(string locationId);
    }
}