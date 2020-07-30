using RentNScoot.Domain;
using System;
using System.Data.Common;

namespace RentNScoot
{
    public static class SExtendedPersistence
    {
        //liest scooter von datenbank
        public static void FromDbDataReaderScooter(this Scooter scooter, DbDataReader dbDataReader)
        {
            scooter.Id = Convert.ToString(dbDataReader[0]);
            scooter.Make = Convert.ToString(dbDataReader[1]);
            scooter.Model = Convert.ToString(dbDataReader[2]);
            scooter.Price = Convert.ToDouble(dbDataReader[3]);
        }

        //liest location von Datenbank
        public static void FromDbDataReaderLocation(this Location location, DbDataReader dbDataReader)
        {
            location.Id = Convert.ToString(dbDataReader[0]);
            location.City = Convert.ToString(dbDataReader[1]);
            location.Plz = Convert.ToString(dbDataReader[2]);
            location.Adress = Convert.ToString(dbDataReader[3]);
            location.AdressNr = Convert.ToDouble(dbDataReader[4]);
        }
    }
}