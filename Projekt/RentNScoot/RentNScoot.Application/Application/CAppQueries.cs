//
using RentNScoot.Domain;
using System.Collections.Generic;

namespace RentNScoot.Application
{
    internal class CAppQueries : IAppQueries
    {
        //dataread initialisieren
        private IDataRead _dataRead;

        //Konstruktor
        internal CAppQueries(IDataRead dataRead)
        {
            _dataRead = dataRead;
        }

        //Anzahl Scooter
        public int CountScooters()
        {
            int nScooters = _dataRead.CountScooters();
            return nScooters;
        }

        //Alle Scooter
        public virtual ICollection<Scooter> GetAllScooters()
        {
            var scooters = _dataRead.SelectAllScooters();
            return scooters;
        }

        //Alle Locations
        public virtual ICollection<Location> GetAllLocations()
        {
            var locations = _dataRead.SelectAllLocations();
            return locations;
        }
    }
}