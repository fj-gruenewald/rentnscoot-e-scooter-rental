using RentNScoot.Persistence.Read;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using RentNScoot.Persistence.Write;

namespace RentNScoot.Persistence.Factories
{
    public abstract class AFactoryData
    {
        //READ
        public static IDataRead Create_ReadSql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataReadConnector(dbProviderFactory, connectionString);
        }

        //WRITE
        public static IDataWrite Create_WriteSql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataWriteConnector(dbProviderFactory, connectionString);
        }

    }
}