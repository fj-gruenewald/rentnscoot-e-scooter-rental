using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using RentNScoot.Utils;

namespace RentNScoot.Persistence
{
    internal abstract class ADataRead : AData, IDataRead
    {
        internal ADataRead(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory, connectionString)
        { }

        //Read List of all Locations
        public List<Location> GetLocationListFromDB()
        {
            List<Location> ListOfLocations = new List<Location>();

            try
            {
                //Get Data from Database
                _dbConnection.Open();

                //Extract Data
                if (_dbConnection?.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.CommandText = GetSqlLocations();
                    var dbDataReader = _dbCommand.ExecuteReader();
                    if (dbDataReader != null && dbDataReader.HasRows)
                    {
                        while (dbDataReader.Read())
                        {
                            Location location = new Location();
                            location.LocationFromDbDataReader(dbDataReader);
                            ListOfLocations.Add(location);
                        }
                        if (!dbDataReader.IsClosed) dbDataReader.Close();
                    }
                }
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException(Properties.Resources.ADataRead_LocationDatabaseAlert);
            }

            Log.D(this, "Locations() =", "GetLocations");
            return ListOfLocations;
        }

        public List<Scooter> GetScooterListFromDbByObject(Location location)
        {
            List<Scooter> ListOfScootersToLocation = new List<Scooter>();

            try
            {
                //Get Data from Database
                _dbConnection.Open();

                //Extract Data
                if (_dbConnection?.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.Parameters.Clear();
                    _dbCommand.CommandText = GetSqlScootersToLocation(location.LocationID);
                    var dbDataReader = _dbCommand.ExecuteReader();
                    if (dbDataReader != null && dbDataReader.HasRows)
                    {
                        while (dbDataReader.Read())
                        {
                            Scooter scooter = new Scooter();
                            scooter.ScooterFromDbDataReader(dbDataReader);
                            ListOfScootersToLocation.Add(scooter);
                        }
                        if (!dbDataReader.IsClosed) dbDataReader.Close();
                    }
                }
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ApplicationException("hello");
            }

            return ListOfScootersToLocation;
        }

        public Scooter? GetScooterFromDbById(string scooterId)
        {
            Log.D(this, "GetScooter", "");
            Scooter? scooter = null;

            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlScooterById(scooterId);

                AddParameter(_dbCommand, "ScooterID", scooterId);
                var dbDataReader = _dbCommand.ExecuteReader();

                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        scooter = new Scooter();
                        scooter.ScooterFromDbDataReader(dbDataReader);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return scooter;
        }

        public Rental? GetRentableFromDbById(string rentalId)
        {
            Log.D(this, "GetRental", "");
            Rental? rental = null;

            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlRentalById(rentalId);

                AddParameter(_dbCommand, "RentalID", rentalId);
                var dbDataReader = _dbCommand.ExecuteReader();

                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        rental = new Rental();
                        rental.RentalFromDbDataReader(dbDataReader);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return rental;
        }

        public Customer? GetCustomerFromDbById(string customerId)
        {
            Log.D(this, "GetCustomer", "");
            Customer? customer = null;

            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlCustomerById(customerId);

                AddParameter(_dbCommand, "CustomerID", customerId);
                var dbDataReader = _dbCommand.ExecuteReader();

                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        customer = new Customer();
                        customer.CustomerFromDbDataReader(dbDataReader);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return customer;
        }

        public Location? GetLocationFromDbById(string locationId)
        {
            Log.D(this, "GetLocation", "");
            Location? location = null;

            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlLocationById(locationId);

                AddParameter(_dbCommand, "LocationID", locationId);
                var dbDataReader = _dbCommand.ExecuteReader();

                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        location = new Location();
                        location.LocationFromDbDataReader(dbDataReader);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return location;
        }

        #region SQL Queries

        protected virtual string GetSqlLocations()
        {
            return "SELECT * FROM Locations;";
        }

        protected virtual string GetSqlScootersToLocation(string locationId)
        {
            return $"SELECT * FROM Scooter WHERE Location='{locationId}' AND Rentable='1';";
        }

        protected virtual string GetSqlScooterById(string scooterId)
        {
            return $"SELECT * FROM Scooter WHERE ScooterID='{scooterId}';";
        }

        protected virtual string GetSqlRentalById(string rentalId)
        {
            return $"SELECT * FROM Rentals WHERE RentalID='{rentalId}';";
        }

        protected virtual string GetSqlCustomerById(string customerId)
        {
            return $"SELECT * FROM Customer WHERE CustomerID='{customerId}';";
        }

        protected virtual string GetSqlLocationById(string locationId)
        {
            return $"SELECT * FROM Locations WHERE LocationID='{locationId}';";
        }

        #endregion SQL Queries
    }
}