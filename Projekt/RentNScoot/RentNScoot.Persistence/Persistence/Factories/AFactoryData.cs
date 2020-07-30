using MySql.Data.MySqlClient;
using RentNScoot.Persistence.Read;
using RentNScoot.Persistence.Write;

namespace RentNScoot.Persistence.Factories
{
    public abstract class AFactoryData
    {
        //lesen
        public static IDataRead Create_ReadSql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataReadConnector(dbProviderFactory, connectionString);
        }

        //schreiben
        public static IDataWrite Create_WriteSql(string connectionString)
        {
            var dbProviderFactory = MySqlClientFactory.Instance;
            return new CDataWriteConnector(dbProviderFactory, connectionString);
        }
    }
}