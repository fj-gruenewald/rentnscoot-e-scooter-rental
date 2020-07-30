//
using RentNScoot.Domain;
using System.Collections.Generic;

namespace RentNScoot
{
    public interface IDataRead
    {
        //datenbank initialisieren
        void InitDb();

        //datenbank schließen
        void DisposeDb();

        //Scooter zählen
        int CountScooters();

        //Alle Scooter ausgeben
        ICollection<Scooter> SelectAllScooters();

        //Alle locations ausgeben
        ICollection<Location> SelectAllLocations();
    }
}