using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using RentNScoot.Domain;

namespace RentNScoot.Persistence.Write
{
    internal abstract class ADataWrite : AData, IDataWrite
    {
        //
        protected ADataWrite(DbProviderFactory dbProviderFactory, string connectionString)
            : base(dbProviderFactory, connectionString)
        { }

        //
        public virtual int InsertCustomer(Customer customer)
        {
            int rowsAffected = 0;
            _dbConnection.Open();

            try
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbCommand.CommandType = CommandType.Text;
                    _dbCommand.Parameters.Clear();
                    _dbCommand.CommandText =
                        $"INSERT INTO customertable" +
                        $" (customerId, name, familyname, mail, iban, city, street, streetNr, plz )" +
                        $" VALUES " +
                        $" (@customerId, @name, @familyname, @mail, @iban, @city, @street, @streetNr, @plz );";
                    AData.AddParameter(_dbCommand, "@customerId", customer.Id);
                    AData.AddParameter(_dbCommand, "@name", customer.Name);
                    AData.AddParameter(_dbCommand, "@familyname", customer.FamilyName);
                    AData.AddParameter(_dbCommand, "@mail", customer.EMail);
                    AData.AddParameter(_dbCommand, "@iban", customer.Iban);
                    AData.AddParameter(_dbCommand, "@city", customer.City);
                    AData.AddParameter(_dbCommand, "@street", customer.Street);
                    AData.AddParameter(_dbCommand, "@streetNr", customer.StreetNR);
                    AData.AddParameter(_dbCommand, "@plz", customer.Plz);

                    _dbTransaction = _dbConnection.BeginTransaction();
                    _dbCommand.Transaction = _dbTransaction;
                    rowsAffected = (int)_dbCommand.ExecuteNonQuery();
                    _dbTransaction.Commit();
                }
            }
            catch
            {
                _dbTransaction?.Rollback();
                rowsAffected = -1;
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open) _dbConnection.Close();
            }
            return rowsAffected;
        }
    }
}
