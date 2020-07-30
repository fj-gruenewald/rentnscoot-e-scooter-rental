using RentNScoot.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RentNScoot.Persistence.Read
{
    internal abstract class ADataRead : AData, IDataRead
    {
        //Konstruktor
        protected ADataRead(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory, connectionString)
        {
        }

        #region interface IDataRead methods

        public virtual int CountScooters()
        {
            int nScooters = -1;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.CommandText = GetSqlCountScooters();
                var records = _dbCommand.ExecuteScalar();
                nScooters = Convert.ToInt32(records);
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return nScooters;
        }

        public virtual ICollection<Scooter> SelectAllScooters()
        {
            ICollection<Scooter> scooters = new List<Scooter>();
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlSelectAllScooters();
                var dbDataReader = _dbCommand.ExecuteReader();
                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Scooter scooter = new Scooter();
                        scooter.FromDbDataReaderScooter(dbDataReader);
                        scooters.Add(scooter);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return scooters;
        }

        public virtual ICollection<Location> SelectAllLocations()
        {
            ICollection<Location> locations = new List<Location>();
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlSelectAllLocations();
                var dbDataReader = _dbCommand.ExecuteReader();
                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Location location = new Location();
                        location.FromDbDataReaderLocation(dbDataReader);
                        locations.Add(location);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return locations;
        }

        #endregion interface IDataRead methods

        #region Car SQL Query Commands

        protected virtual string GetSqlCountScooters()
        {
            return "SELECT COUNT(scooterId) FROM scootertable;";
        }
        
        protected virtual string GetSqlSelectAllScooters()
        {
            return "SELECT * FROM scootertable;";
        }

        protected virtual string GetSqlSelectAllLocations()
        {
            return "SELECT * FROM scooterlocations;";
        }

        #endregion Car SQL Query Commands
    }
}