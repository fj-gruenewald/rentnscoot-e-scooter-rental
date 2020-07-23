using System;
using System.Data;
using System.Data.Common;
using RentNScoot.Persistence.Read;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RentNScoot.Persistence.Factories
{
    public static class FactoryDataRead
    {
        public static IDataRead CreateInstance(string dataSourcePath)
        {
            var providerFactory = DbProviderFactories.GetFactory("System.Data.SqlClient") ?? throw new ApplicationException("Could not create System.Data.OleDb.");
            var connectionString = $"Data Source=DESKTOP-T6LLR5B;Initial Catalog=RNSDB;Integrated Security=True;Pooling=False";

            return new CDataReadSQL(providerFactory, connectionString) ?? throw new ApplicationException("Could not create DataReader.");
        }
    }
}