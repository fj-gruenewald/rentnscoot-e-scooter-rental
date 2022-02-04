using RentNScoot.Utils;
using System.Data.SQLite;

namespace RentNScoot.Persistence.Factories
{
    public abstract class AFactoryData
    {
        //Fake
        public static IDataRead Create_ReadInstanceFake()
        {
            Log.D("AFactoryData", "Create_ReadCarFake()", "");
            return new CDataReadFake();
        }

        public static IDataWrite Create_WriteInstanceFake()
        {
            Log.D("AFactoryData", "Create_WriteFake()", "");
            return new CDataWriteFake();
        }

        //SQLITE
        public static IDataRead Create_ReadInstanceSqlite(string connectionString)
        {
            Log.D("AFactoryData", "Create_ReadSqlite()", connectionString);
            var dbProviderFactory = SQLiteFactory.Instance;
            return new CDataReadSqlite(dbProviderFactory, connectionString);
        }

        public static IDataWrite Create_WriteInstanceSqlite(string connectionString)
        {
            Log.D("AFactoryData", "Create_WriteSqlite()", connectionString);
            var dbProviderFactory = SQLiteFactory.Instance;
            return new CDataWriteSqlite(dbProviderFactory, connectionString);
        }
    }
}