using System;
using System.Data;
using System.Data.Common;
using RentNScoot.Utils;

namespace RentNScoot.Persistence
{
    internal abstract class ADataWrite : AData, IDataWrite
    {
        protected ADataWrite(DbProviderFactory dbProviderFactory, string connectionString) : base(dbProviderFactory, connectionString)
        {
        }

        #region Customer Methods

        public virtual int InsertCustomer(Customer customer)
        {
            Log.D(this, "InsertCustomer()", "");

            _dbConnection.Open();

            try
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.CommandText = GetSqlInsertCustomer();
                    customer.AddCustomerInsertParameters(_dbCommand);

                    _dbTransaction = _dbConnection.BeginTransaction();
                    _dbCommand.Transaction = _dbTransaction;
                    var result = _dbCommand.ExecuteNonQuery();
                    _dbTransaction.Commit();
                }
            }
            catch (Exception e)
            {
                Err.D(this, $"InsertCustomer()", e.Message);
                _dbTransaction?.Rollback();
                return 0;
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            return 1;
        }

        #endregion Customer Methods

        #region Rental Methods

        public int InsertRental(Rental rental)
        {
            Log.D(this, "InsertRental()", "");

            _dbConnection.Open();

            try
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.CommandText = GetSqlInsertRental();
                    rental.AddRentalInsertParameters(_dbCommand);

                    _dbTransaction = _dbConnection.BeginTransaction();
                    _dbCommand.Transaction = _dbTransaction;
                    var result = _dbCommand.ExecuteNonQuery();
                    _dbTransaction.Commit();
                }
            }
            catch (Exception e)
            {
                Err.D(this, $"InsertRental()", e.Message);
                _dbTransaction?.Rollback();
                return 0;
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            return 1;
        }

        public int DeleteRental(Rental rental)
        {
            Log.D(this, "DeleteRental()", "");

            _dbConnection.Open();

            try
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.CommandText = GetSqlDeleteRental(rental.RentalID);
                    _dbCommand.Parameters.Clear();
                    rental.AddRentalInsertParameters(_dbCommand);

                    _dbTransaction = _dbConnection.BeginTransaction();
                    _dbCommand.Transaction = _dbTransaction;
                    var result = _dbCommand.ExecuteNonQuery();
                    _dbTransaction.Commit();
                }
            }
            catch (Exception e)
            {
                Err.D(this, $"DeleteRentalErr()", e.Message);
                _dbTransaction?.Rollback();
                return 0;
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            return 1;
        }

        #endregion Rental Methods

        #region Scooter Methods

        public int UpdateScooter(Scooter scooter)
        {
            Log.D(this, "UpdateScooter()", "");
            _dbConnection.Open();

            try
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.CommandText = GetSqlUpdateScooter();
                    scooter.AddScooterUpdateParameters(_dbCommand);

                    _dbTransaction = _dbConnection.BeginTransaction();
                    _dbCommand.Transaction = _dbTransaction;
                    var result = _dbCommand.ExecuteNonQuery();
                    _dbTransaction.Commit();
                }
            }
            catch (Exception e)
            {
                Err.D(this, $"UpdateScooter()", e.Message);
                _dbTransaction?.Rollback();
                return 0;
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            return 1;
        }

        #endregion Scooter Methods

        #region SQL Commands

        protected virtual string GetSqlInsertCustomer()
        {
            return "INSERT INTO Customer " +
                   "(CustomerID, CustomerName, CustomerAddress, CustomerPayment)" +
                   " VALUES (?, ?, ?, ?);";
        }

        protected virtual string GetSqlInsertRental()
        {
            return "INSERT INTO Rentals " +
                   "(RentalID, CustomerID, LocationID, ScooterID, RentalStart, RentalEnd)" +
                   " VALUES (?, ?, ?, ?, ?, ?);";
        }

        protected virtual string GetSqlUpdateScooter()
        {
            return "UPDATE Scooter " +
                   "SET Rentable = ? " +
                   "WHERE ScooterID = ?;"; ;
        }

        protected virtual string GetSqlDeleteRental(string rentalId)
        {
            return $"DELETE FROM Rentals WHERE RentalID='{rentalId}';";
        }

        #endregion SQL Commands
    }
}