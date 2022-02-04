using System;
using System.Data.Common;

namespace RentNScoot
{
    public static class SExtendPersistence
    {
        //Format Location Data from DB
        public static void LocationFromDbDataReader(this Location location, DbDataReader dbDataReader)
        {
            location.LocationID = Convert.ToString(dbDataReader[0]);
            location.City = Convert.ToString(dbDataReader[1]);
            location.Postal = Convert.ToInt32(dbDataReader[2]);
            location.State = Convert.ToString(dbDataReader[3]);
            location.Street = Convert.ToString(dbDataReader[4]);
            location.StreetNr = Convert.ToString(dbDataReader[5]);
        }

        //Format Scooter Data from DB
        public static void ScooterFromDbDataReader(this Scooter scooter, DbDataReader dbDataReader)
        {
            scooter.ScooterID = Convert.ToInt32(dbDataReader[0]);
            scooter.Location = Convert.ToInt32(dbDataReader[1]);
            scooter.Rentable = Convert.ToInt32(dbDataReader[2]);
            scooter.Manufacturer = Convert.ToString(dbDataReader[3]);
            scooter.Model = Convert.ToString(dbDataReader[4]);
        }

        //Format Rental Data from DB
        public static void RentalFromDbDataReader(this Rental rental, DbDataReader dbDataReader)
        {
            rental.RentalID = Convert.ToString(dbDataReader[0]);
            rental.CustomerID = Convert.ToString(dbDataReader[1]);
            rental.LocationID = Convert.ToString(dbDataReader[2]);
            rental.ScooterID = Convert.ToInt32(dbDataReader[3]);
            rental.RentalStart = Convert.ToString(dbDataReader[4]);
            rental.RentalEnd = Convert.ToString(dbDataReader[5]);
        }

        //Format Customer Data from DB
        public static void CustomerFromDbDataReader(this Customer customer, DbDataReader dbDataReader)
        {
            customer.CustomerID = Convert.ToString(dbDataReader[0]);
            customer.CustomerName = Convert.ToString(dbDataReader[1]);
            customer.CustomerAddress = Convert.ToString(dbDataReader[2]);
            customer.CustomerPayment = Convert.ToString(dbDataReader[3]);
        }

        //Format Customer Parameters to push to DB
        public static void AddCustomerInsertParameters(this Customer customer, DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            AddParameter(dbCommand, "CustomerID", customer.CustomerID);
            AddParameter(dbCommand, "CustomerName", customer.CustomerName);
            AddParameter(dbCommand, "CustomerAddress", customer.CustomerAddress);
            AddParameter(dbCommand, "CustomerPayment", customer.CustomerPayment);
        }

        //Format Rental Parameters to push to DB
        public static void AddRentalInsertParameters(this Rental rental, DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            AddParameter(dbCommand, "RentalID", rental.RentalID);
            AddParameter(dbCommand, "CustomerID", rental.CustomerID);
            AddParameter(dbCommand, "LocationID", rental.LocationID);
            AddParameter(dbCommand, "ScooterID", rental.ScooterID);
            AddParameter(dbCommand, "RentalStart", rental.RentalStart);
            AddParameter(dbCommand, "RentalEnd", rental.RentalEnd);
        }

        //
        private static void AddParameter(DbCommand dbCommand, string name, object value)
        {
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.Value = value;
            dbCommand.Parameters.Add(dbParameter);
        }

        //
        public static void AddScooterUpdateParameters(this Scooter scooter, DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            AddParameter(dbCommand, "Rentable", scooter.Rentable);
            AddParameter(dbCommand, "ScooterID", scooter.ScooterID);
        }
    }
}