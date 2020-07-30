//
using RentNScoot.Domain;
using System.Collections.Generic;

namespace RentNScoot
{
    public interface IAppQueries
    {
        //anzahl scooter
        int CountScooters();

        //alle scooter
        ICollection<Scooter> GetAllScooters();

        //alle locations
        ICollection<Location> GetAllLocations();
    }
}