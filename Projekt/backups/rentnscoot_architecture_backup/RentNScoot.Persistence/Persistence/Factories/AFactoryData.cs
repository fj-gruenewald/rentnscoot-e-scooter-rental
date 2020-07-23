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
            var dbProviderFactory = SqlClientFactory.Instance;
            return new CDataReadSqlLocalDb(dbProviderFactory, connectionString);
        }

        //
        public static IDataWrite Create_CarWriteMySql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataCarWriteMySql(dbProviderFactory, connectionString);
        }
    }
}