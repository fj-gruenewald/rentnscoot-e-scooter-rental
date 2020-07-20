using RentNScoot.Persistence.Read;
using System.Data.SqlClient;
using System.Data.SQLite;
using MySql.Data.MySqlClient;


namespace RentNScoot.Persistence.Factories
{
    public abstract class AFactoryData
    {
        //
        public static IDataRead Create_ReadCarMySql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataCarReadMySql(dbProviderFactory, connectionString);
        }

        //
        public static IDataWrite Create_CarWriteMySql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataCarWriteMySql(dbProviderFactory, connectionString);
        }
    }
}