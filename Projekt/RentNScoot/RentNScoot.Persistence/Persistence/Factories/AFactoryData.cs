using RentNScoot.Persistence.Read;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RentNScoot.Persistence.Factories
{
    public abstract class AFactoryData
    {
        //
        public static IDataRead Create_ReadSql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataReadConnector(dbProviderFactory, connectionString);
        }

    }
}