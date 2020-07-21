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
            var providerFactory = DbProviderFactories.GetFactory("System.Data.OleDb") ?? throw new ApplicationException("Could not create System.Data.OleDb.");
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dataSourcePath};";

            return new CDataReadSQL(providerFactory, connectionString); ?? throw new ApplicationException("Could not create DataReader.");

        }
}