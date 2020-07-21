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
                //_dbCommand.CommandText = "SELECT COUNT(pk) AS NCars FROM CarTable;";
                _dbCommand.CommandText = GetSqlCountCars();
                var records = _dbCommand.ExecuteScalar();
                nScooters = Convert.ToInt32(records);
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return nScooters;
        }

        public virtual IEnumerable<string> SelectMakes()
        {
            ICollection<string> makes = new List<string>();
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                //          _dbCommand.CommandText = "SELECT DISTINCT make FROM CarTable ORDER BY make;";
                _dbCommand.CommandText = GetSqlSelectMakes();
                var dbDataReader = _dbCommand.ExecuteReader();
                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        makes.Add(dbDataReader[0]?.ToString() ?? "");
                    }
                    if (!dbDataReader!.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return makes;
        }

        public virtual int CountScooters(string make)
        {
            int nCars = -1;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                // VORSICHT: SQL Injection !!!
                // _dbCommand.CommandText =
                //    $"SELECT COUNT (pk) FROM CarTable WHERE make='{make}';";
                // SQL-Injection bezeichnet das Ausnutzen einer Sicherheitslücke in SQL-Datenbanken, 
                // die durch mangelnde Maskierung/Metazeichen in Benutzereingaben entsteht.
                // CommandText = "SELECT COUNT(Id) FROM CarTable WHERE Make='Opel'";
                // CommandText = "SELECT COUNT(Id) FROM CarTable WHERE Make='Opel';DELETE ...; ";                 
                // BESSER: Dynamic SQL with parameter
                // _dbCommand.CommandText =
                //     "SELECT COUNT(pk) FROM CarTable WHERE make = ?;";
                // DbParameter dbParameter = _dbCommand.CreateParameter();
                // dbParameter.ParameterName = "Maker";
                // dbParameter.Value         = maker;
                // _dbCommand.Parameters.Add(dbParameter);
                _dbCommand.CommandText = GetSqlCountCarsMake();
                _dbCommand.Parameters.Clear();
                AddParameter(_dbCommand, "make", make);
                var records = _dbCommand.ExecuteScalar();
                nCars = Convert.ToInt32(records);
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return nCars;
        }

        public virtual IEnumerable<string> SelectModels(string make)
        {
            ICollection<string> models = new List<string>();
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                //          _dbCommand.CommandText =
                //             "SELECT DISTINCT Model FROM CarTable WHERE make = ? ORDER BY model";
                _dbCommand.CommandText = GetSqlSelectModels();
                _dbCommand.Parameters.Clear();
                AddParameter(_dbCommand, "make", make);
                var dbDataReader = _dbCommand.ExecuteReader();
                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        models.Add(dbDataReader[0]?.ToString() ?? "");
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return models;
        }

        public virtual int CountScooters(string make, string model)
        {
            int nCars = -1;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                //_dbCommand.CommandText =
                //"SELECT COUNT(pk) FROM CarTable WHERE make = ? AND model = ?;";
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
        
        public virtual Scooter? SelectScooter(string pk)
        {
            Scooter? scooter = null;
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                //          _dbCommand.CommandText = "SELECT * FROM CarTable WHERE pk = ?;";
                _dbCommand.CommandText = GetSqlSelectCar();

                AddParameter(_dbCommand, "pk", pk);
                var dbDataReader = _dbCommand.ExecuteReader();
                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        scooter = new Scooter();
                        scooter.FromDbDataReader(dbDataReader);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return scooter;
        }

        public virtual ICollection<Scooter> SelectAllScooters()
        {
            ICollection<Scooter> scooters = new List<Scooter>();
            _dbConnection.Open();
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbCommand.CommandType = CommandType.Text;
                _dbCommand.Parameters.Clear();
                _dbCommand.CommandText = GetSqlSelectAllCars();
                var dbDataReader = _dbCommand.ExecuteReader();
                if (dbDataReader != null && dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        Scooter scooter = new Scooter();
                        scooter.FromDbDataReader(dbDataReader);
                        scooters.Add(scooter);
                    }
                    if (!dbDataReader.IsClosed) dbDataReader.Close();
                }
            }
            if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            return scooters;
        }
        #endregion

        #region Car SQL Query Commands
        protected virtual string GetSqlCountCars()
        {
            return "SELECT COUNT(pk) FROM CarTable;";
        }

        protected string GetSqlCountCarsMake()
        {
            return "SELECT COUNT(pk) FROM CarTable WHERE make=?;";
        }

        protected virtual string GetSqlSelectMakes()
        {
            return "SELECT DISTINCT make FROM CarTable ORDER BY make;";
        }

        protected virtual string GetSqlSelectModels()
        {
            return "SELECT DISTINCT model FROM CarTable WHERE make = ? ORDER BY model;";
        }

        protected virtual string GetSqlCountCarsMakeModel()
        {
            return "SELECT COUNT(pk) FROM CarTable WHERE make=? AND model=?;";
        }

        protected virtual string GetSqlCountCarsToSearch()
        {
            return "SELECT COUNT(pk) FROM CarTable WHERE " +
                   "make     =  ? AND model    =  ? AND " +
                   "price    >= ? AND price    <= ? AND " +
                   "firstreg >= ? AND firstreg <= ? AND " +
                   "km       >= ? AND km       <= ? ;";
        }

        protected virtual string GetSqlSelectCarsToSearch()
        {
            return "SELECT * FROM CarTable WHERE " +
                   "make     =  ? AND model    =  ? AND " +
                   "price    >= ? AND price    <= ? AND " +
                   "firstreg >= ? AND firstreg <= ? AND " +
                   "km       >= ? AND km       <= ? ;";
        }

        protected virtual string GetSqlSelectCar()
        {
            return "SELECT * FROM CarTable WHERE pk = ?;";
        }

        protected virtual string GetSqlSelectAllCars()
        {
            return "SELECT * FROM CarTable;";
        }
        #endregion
    }
}
