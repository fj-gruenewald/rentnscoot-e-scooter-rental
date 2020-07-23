using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Persistence.Read
{
    internal abstract class ADataRead : AData, IDataRead
    {
        protected ADataRead(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory, connectionString)
        {
        }

        #region interface IDataCarRead methods
        public virtual int CountScooters()
        {
            int nScooters = -1;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.CommandText = GetSqlCountCars();
                var records = _dbCommand.ExecuteScalar();
                nScooters = Convert.ToInt32(records);
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return nScooters;
        }


        public virtual int CountScooters(string make)
        {
            int nCars = -1;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.CommandText = GetSqlCountCarsMake();
                _dbCommand.Parameters.Clear();
                AddParameter(_dbCommand, "make", make);
                var records = _dbCommand.ExecuteScalar();
                nCars = Convert.ToInt32(records);
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return nCars;
        }


        public virtual int CountScooters(string make, string model)
        {
            int nCars = -1;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.CommandText = GetSqlCountCarsMakeModel();
                _dbCommand.Parameters.Clear();
                AddParameter(_dbCommand, "maker", make);
                AddParameter(_dbCommand, "model", model);
                var records = _dbCommand.ExecuteScalar();
                nCars = Convert.ToInt32(records);
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return nCars;
        }
        
        #endregion

        #region Car SQL Query Commands
        protected virtual string GetSqlCountCars()
        {
            return "SELECT COUNT(scooterId) FROM scootertable;";
        }

        protected string GetSqlCountCarsMake()
        {
            return "SELECT COUNT(scooterId) FROM scootertable WHERE make=?;";
        }

        protected virtual string GetSqlSelectMakes()
        {
            return "SELECT DISTINCT make FROM scootertable ORDER BY make;";
        }

        protected virtual string GetSqlSelectModels()
        {
            return "SELECT DISTINCT model FROM scootertable WHERE make = ? ORDER BY model;";
        }

        protected virtual string GetSqlCountCarsMakeModel()
        {
            return "SELECT COUNT(pk) FROM scootertable WHERE make=? AND model=?;";
        }

        protected virtual string GetSqlCountCarsToSearch()
        {
            return "SELECT COUNT(pk) FROM scootertable WHERE " +
                   "make     =  ? AND model    =  ? AND " +
                   "price    >= ? AND price    <= ? AND " +
                   "firstreg >= ? AND firstreg <= ? AND " +
                   "km       >= ? AND km       <= ? ;";
        }

        protected virtual string GetSqlSelectCarsToSearch()
        {
            return "SELECT * FROM scootertable WHERE " +
                   "make     =  ? AND model    =  ? AND " +
                   "price    >= ? AND price    <= ? AND " +
                   "firstreg >= ? AND firstreg <= ? AND " +
                   "km       >= ? AND km       <= ? ;";
        }

        protected virtual string GetSqlSelectCar()
        {
            return "SELECT * FROM scootertable WHERE pk = ?;";
        }

        protected virtual string GetSqlSelectAllCars()
        {
            return "SELECT * FROM scootertable;";
        }
        #endregion
    }
}
