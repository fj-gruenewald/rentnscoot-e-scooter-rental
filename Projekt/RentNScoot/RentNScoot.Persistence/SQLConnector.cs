using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RentNScoot
{
    internal class SQLConnector
    {
        #region fields
        private readonly string _connectionString;
        private readonly DbProviderFactory _dbProviderFactory;
        protected readonly DbConnection _dbConnection;
        protected readonly DbCommand _dbCommand;
        protected DbTransaction? _dbTransaction;
        #endregion

        #region ctor
        protected SQLConnector(DbProviderFactory dbProviderFactory, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ApplicationException("ConnectionString ist leer");
            _dbProviderFactory = dbProviderFactory ??
                                 throw new ApplicationException("DbProviderFactory ist null");
            _connectionString = connectionString;

            // Create a DbConnection object
            _dbConnection = _dbProviderFactory.CreateConnection();
            if (_dbConnection == null)
                throw new ApplicationException("DbConnection konnte nicht erzeugen");
            // set connection string
            _dbConnection.ConnectionString = _connectionString;

            // Create a DbCommand object
            _dbCommand = _dbProviderFactory.CreateCommand();
            if (_dbCommand == null)
                throw new ApplicationException("DbCommand konnte nicht erzeugen");
            // setter injection of DbConnection object
            _dbCommand.Connection = _dbConnection;
        }
        #endregion

        public virtual void InitDb()
        {
            // Test Connection
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
            else
            {
                throw new ApplicationException(
                   $"Datenbank {_connectionString} konnte nicht geöffnet werden");
            }
        }

        public virtual void DisposeDb()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
            _dbCommand.Dispose();
            _dbConnection.Dispose();
        }

        protected virtual bool Open()
        {

            return false;
        }

        public static void AddParameter(DbCommand dbCommand, string parameterName, object value)
        {
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            dbCommand.Parameters.Add(dbParameter);
        }
    }
}
